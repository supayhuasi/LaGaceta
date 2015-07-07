using System.IO;

namespace BusquedaLaGaceta.Utils
{
    public class ManagerDirectory
    {
        string path { get; set; }
        
        public void DirectoryList()
        {
            string namef = "";
            int counter = 0;
            
		    if (Directory.Exists(path)) 
            {	    
			    var ficheros = 
			for (int x = 0; x < ficheros.length; x++) {
				namef = ficheros[x].getName();
				counter = this.characterCounter(namef, "-");
				if (counter == 6) {
					System.out.println("File Name : " + namef);
				}
			}
		}

		else {
			System.out.println("the directory doesn't exists !!");
		}
            }
	



        public int characterCounter(string string1, string string2)
        {

            string sTexto = string1;
            // Texto que vamos a buscar
            string sTextoBuscado = string2;
            // Contador de ocurrencias
            int contador = 0;

            while (sTexto.indexOf(sTextoBuscado) > -1)
            {
                sTexto = sTexto.substring(sTexto.indexOf(sTextoBuscado)
                        + sTextoBuscado.length(), sTexto.length());
                contador++;
            }

            return contador;
        }

        public boolean changeIndexFileDirectory(string indexFileDirectory, string newIndexDirectory) {
         
		boolean returnVar=false;
		int a = indexFileDirectory.indexOf(".");
		string tail = indexFileDirectory.substring(a);
		string header = indexFileDirectory.substring(0, a);
		string tempDirectory = header + "2" + tail;

		//System.out.println("tempDirectory : " + tempDirectory);

		/*
		 * variables relacionadas con la lectura y modificacion de una line
		 * dentro del archivo
		 */
		// Lectura del fichero
		string line;
		string modifiedLine;
		string headerPath = "";
		string tailPath = "";
		int assignmentPoint = -1;
		/* variables booleanas utizadas en la funcion */

		boolean stringChecker = false;

		/*
		 * first declare the necessary objects to read the configuration file
		 * primero, declaro los objetos necesarios,para leer el archivo de
		 * configuracion
		 */
		File archivo = null;
		FileReader fr = null;
		BufferedReader br = null;

		/*
		 * declaro los Objectos necesarios,para escribir el archivo de
		 * configuracion declare the Object needed to write the configuration
		 * file
		 */

		FileWriter fichero = null;
		PrintWriter pw = null;

		try {
			// Apertura del fichero y creacion de BufferedReader para poder
			// hacer una lectura comoda (disponer del metodo readLine()).
			archivo = new File(indexFileDirectory);
			fr = new FileReader(archivo);
			br = new BufferedReader(fr);

			/*
			 * aca creo el archivo de salida pasando por parametro el camino de
			 * salida
			 */
			fichero = new FileWriter(tempDirectory);
			pw = new PrintWriter(fichero);
			
           int counterLine=0;
			while ((line = br.readLine()) != null) {

				//System.out.println("leyendo   linea numero : " +counterLine);


				stringChecker = line.startsWith("IndexPath");

				if (stringChecker) {
					
					System.out.println("leyendo IndexPath  linea numero : " +counterLine);

					
					assignmentPoint = line.indexOf("=");
					headerPath = line.substring(0, assignmentPoint + 1);
					tailPath = line.substring(assignmentPoint + 1);
					modifiedLine = headerPath + " " + newIndexDirectory;
					System.out.println("ModifiedLine : "+ modifiedLine);
					pw.println(modifiedLine);
				

				} else {
					System.out.println("Line numero : "+counterLine +  ",  LINE:  "+ line);
					pw.println(line);
				}
				counterLine++;
				returnVar=  true;
			}

		} catch (Exception e) {
			e.printStackTrace();
			returnVar= false;
		}
		finally {
            // En el finally cerramos el fichero, para asegurarnos
            // que se cierra tanto si todo va bien como si salta
            // una excepcion.
            try {
                if (null != fr) {
                    fr.close();
                }
            } catch (Exception e2) {
                e2.printStackTrace();
            }

            try {
                // Nuevamente aprovechamos el finally para
                // asegurarnos que se cierra el fichero.
                if (null != fichero) {
                    fichero.close();
                }
            } catch (Exception e2) {
                e2.printStackTrace();
            }

        }
		
		/*ahora elimino el viejo archivo convirtiendo al archivo modificadocomo definitivo*/
		
	     File f = new File(indexFileDirectory);
	     File f2= new File(tempDirectory);

         if (f.delete()) {
             System.out.println("El fichero " + indexFileDirectory + " ha sido borrado correctamente");
             
             if(f2.renameTo(f)){
                 System.out.println("El fichero " + indexFileDirectory + "ya esta actualziado correctamente");    	 
             }
             else{
            	   System.out.println("El fichero " + indexFileDirectory + "no se actualizado correctamente");
             }
             
         } else {
            // System.out.println("El fichero " + indexFileDirectory + " no se ha podido borrar");
         }

		return returnVar;

	}

        public void escribirProperties(string fichero, string key, string value)
    {
    	
                // Crear el objeto archivo
		File archivo = new File(fichero);
		//Crear el objeto properties

                System.out.println("este es el archivo  de configuracion"+archivo);

		Properties properties = new Properties();
		try {
			// Cargar las propiedades del archivo
			properties.load(new FileInputStream(archivo));
			properties.setProperty(key,value);
			// Escribier en el archivo los cambios
                     FileOutputStream fos=new FileOutputStream(archivo);

                        properties.store(fos,null);

                } catch (FileNotFoundException e) {
			System.out.println(e.getMessage());
		} catch (IOException e) {
			System.out.println(e.getMessage());
		}
    }
        /**
         * chequea que la forma de los nombres delos directirios sea la correcta
         *  y lo devuelve  en un vector de string [3], donde las ubicaciones son : <lu>
         *  <li><b>0</b> nombre de rollo</li>
         *  <li><b>1</b> fecha desde</li>
         *  <li><b>2</b></li>fecha hasta</lu>
         * @param dir nombre del directorio
         * 
         */
        public string[] checkNameDir(string dir)
        {
            string[] vector = new string[3];
            int counter = this.characterCounter(dir, "-");

            if (counter == 6)
            {
                string a = dir.substring(0, dir.indexOf("-")); // nombre de rollo
                string b = dir.substring(dir.indexOf("-") + 1, dir.indexOf("-") + 11);// fecha desde
                string c = dir.substring(dir.indexOf("-") + 12); // fecha hasta
                vector[0] = a;
                vector[1] = b;
                vector[2] = c;

                return vector;
                //System.out.println("a: "+a +" b: "+b + "  c : "+ c);


            }
            else
            {
                return null;
            }
        }


        public static void visitAllDirs(File dir, int fileType) {
		
    	ManagerDirectory managerDirectory = new ManagerDirectory();
		 Table_FileTypeFunctions table_FileTypeFunctions = new Table_FileTypeFunctions();
		 Table_LuceneDBIndexAddressTransaction table_LuceneDBIndexAddressTransaction= new Table_LuceneDBIndexAddressTransaction();
		 string [] vector;
		 string rollNumber="";
		 
		int contador=0;
		string nameFile="";
	    if (dir.isDirectory()) { 		    	
	    	
		        //process Dir
	    		System.out.println("Indexando " + dir + "...");
	    		Resources.logEvent("Indexando " + dir + "...");
	    		nameFile=dir.tostring().substring(dir.tostring().lastIndexOf("\\")+1);
	   			    		
	    		if(nameFile!=null){
	    			
				    	if(managerDirectory.characterCounter(nameFile, "-")==6){		    		
				         vector = managerDirectory.checkNameDir(nameFile);
				         rollNumber=vector[0];

				         
				    		if(table_LuceneDBIndexAddressTransaction.insertVerifyNameFile(nameFile, "o:\\probando", dir.getAbsolutePath())>0){
				    			contador++;
				    			System.out.println("exito"+contador);
				    		}
				    		else{
				    			System.out.println("fracasó!");
				    		}
				    		//indexFunctions.documentIndexer(dir, fileType);
						}
				    	else{					    		
	    		}
			}	
	    	


	        string[] children = dir.list();
	        for (int i=0; i<children.length; i++) {	        	        	
	        	File f=new File(dir, children[i]);
	        	System.out.println("nombre del archivo  : "+f);
	            visitAllDirs(f, fileType);
	        
	        
	        	 if (f.isDirectory()==false && f.tostring().indexOf(".")>1) {
		        		 string type=f.tostring().substring( f.tostring().indexOf(".")+1).toUpperCase();
		        		//	System.out.println("ANTESnameFile:: "+f.tostring());
		        			string selectType=table_FileTypeFunctions.getFileTypeById(""+fileType);
		        			//System.out.println("selectType:: "+selectType+ "  fileType : " + type);
		        			
			        		 if(type.trim().equals(selectType.trim())){
			        			 
			        			 Table_ProcessedFilesTransaction table_ProcessedFilesTransaction = new Table_ProcessedFilesTransaction();
			        			 
					            	string nameFileSelected=f.tostring().substring(f.tostring().lastIndexOf("\\")+1);
					            	table_ProcessedFilesTransaction.insertTable_ProcessedFilesByRoll(nameFileSelected, rollNumber);
					             
					            	//System.out.println("LUEGOnameFile:: "+nameFileSelected);	      
					            	
			        		 }
	            }
	        }
	    }
	}


        public static void main(string[] args) {
		ManagerDirectory mg = new ManagerDirectory();
		string path ="o:\\ssssss\\ssss\\ssss\\R2-09-02-1918-14-05-1918\\pepe.jpg";
		 path= path.substring(0,path.lastIndexOf("\\"));
		 path= path.substring(path.lastIndexOf("\\")+1);

		System.out.println("path2::  "+path);
		
		
		string [] a =mg.checkNameDir("R2-09-02-1918-14-05-1918");
		System.out.println("nombrederollo: "+a[0]);
		 File f = new File ("o:\\archivos\\");
		//mg.visitAllDirs(f, 1);
	/*	mg.setPath("o:\\archivos");
		mg.DirectoryList();
		string dir_current = System.getProperty("user.dir");
		dir_current = dir_current + "\\src\\config.properties";
		System.out.println("dir_current  :  " + dir_current);
		if(mg.changeIndexFileDirectory(dir_current, "nuevo camino")){
			System.out.println("exito");
		}
		else{
			System.out.println("fallido");
		}
		*/
		
		
	}
    }
}