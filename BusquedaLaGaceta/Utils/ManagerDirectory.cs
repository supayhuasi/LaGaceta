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
		        var ficheros = Directory.GetFiles(path);
			    foreach(string fileName in ficheros)
                {
				namef = fileName;
				counter = this.characterCounter(namef, "-");
				if (counter == 6) {
					//System.out.println("File Name : " + namef);
				}
			}
		}

		else {
			//System.out.println("the directory doesn't exists !!");
		}
            }
	



        public int characterCounter(string string1, string string2)
        {

            string sTexto = string1;
            // Texto que vamos a buscar
            string sTextoBuscado = string2;
            // Contador de ocurrencias
            int contador = 0;

            while (sTexto.IndexOf(sTextoBuscado) > -1)
            {
                sTexto = sTexto.Substring(sTexto.IndexOf(sTextoBuscado)
                        + sTextoBuscado.Length, sTexto.Length);
                contador++;
            }

            return contador;
        }

 //       public bool changeIndexFileDirectory(string indexFileDirectory, string newIndexDirectory) {
         
        //bool returnVar=false;
        //int a = indexFileDirectory.IndexOf(".");
        //string tail = indexFileDirectory.Substring(a);
        //string header = indexFileDirectory.Substring(0, a);
        //string tempDirectory = header + "2" + tail;

        ////System.out.println("tempDirectory : " + tempDirectory);

        ///*
        // * variables relacionadas con la lectura y modificacion de una line
        // * dentro del archivo
        // */
        //// Lectura del fichero
        //string line;
        //string modifiedLine;
        //string headerPath = "";
        //string tailPath = "";
        //int assignmentPoint = -1;
        ///* variables booleanas utizadas en la funcion */

        //bool stringChecker = false;

        ///*
        // * first declare the necessary objects to read the configuration file
        // * primero, declaro los objetos necesarios,para leer el archivo de
        // * configuracion
        // */
        //File archivo = null;
        //FileReader fr = null;
        //BufferedReader br = null;

        ///*
        // * declaro los Objectos necesarios,para escribir el archivo de
        // * configuracion declare the Object needed to write the configuration
        // * file
        // */

        //FileWriter fichero = null;
        //PrintWriter pw = null;

        //try {
        //    // Apertura del fichero y creacion de BufferedReader para poder
        //    // hacer una lectura comoda (disponer del metodo readLine()).
        //    archivo = new File(indexFileDirectory);
        //    fr = new FileReader(archivo);
        //    br = new BufferedReader(fr);

        //    /*
        //     * aca creo el archivo de salida pasando por parametro el camino de
        //     * salida
        //     */
        //    fichero = new FileWriter(tempDirectory);
        //    pw = new PrintWriter(fichero);
			
        //   int counterLine=0;
        //    while ((line = br.readLine()) != null) {

        //        //System.out.println("leyendo   linea numero : " +counterLine);


        //        stringChecker = line.startsWith("IndexPath");

        //        if (stringChecker) {
					
        //            System.out.println("leyendo IndexPath  linea numero : " +counterLine);

					
        //            assignmentPoint = line.indexOf("=");
        //            headerPath = line.substring(0, assignmentPoint + 1);
        //            tailPath = line.substring(assignmentPoint + 1);
        //            modifiedLine = headerPath + " " + newIndexDirectory;
        //            System.out.println("ModifiedLine : "+ modifiedLine);
        //            pw.println(modifiedLine);
				

        //        } else {
        //            System.out.println("Line numero : "+counterLine +  ",  LINE:  "+ line);
        //            pw.println(line);
        //        }
        //        counterLine++;
        //        returnVar=  true;
        //    }

        //} catch (Exception e) {
        //    e.printStackTrace();
        //    returnVar= false;
        //}
        //finally {
        //    // En el finally cerramos el fichero, para asegurarnos
        //    // que se cierra tanto si todo va bien como si salta
        //    // una excepcion.
        //    try {
        //        if (null != fr) {
        //            fr.close();
        //        }
        //    } catch (Exception e2) {
        //        e2.printStackTrace();
        //    }

        //    try {
        //        // Nuevamente aprovechamos el finally para
        //        // asegurarnos que se cierra el fichero.
        //        if (null != fichero) {
        //            fichero.close();
        //        }
        //    } catch (Exception e2) {
        //        e2.printStackTrace();
        //    }

        //}
		
        ///*ahora elimino el viejo archivo convirtiendo al archivo modificadocomo definitivo*/
		
        // File f = new File(indexFileDirectory);
        // File f2= new File(tempDirectory);

        // if (f.delete()) {
        //     System.out.println("El fichero " + indexFileDirectory + " ha sido borrado correctamente");
             
        //     if(f2.renameTo(f)){
        //         System.out.println("El fichero " + indexFileDirectory + "ya esta actualziado correctamente");    	 
        //     }
        //     else{
        //           System.out.println("El fichero " + indexFileDirectory + "no se actualizado correctamente");
        //     }
             
        // } else {
        //    // System.out.println("El fichero " + indexFileDirectory + " no se ha podido borrar");
        // }

        //return returnVar;

	//}

   
        public string[] checkNameDir(string dir)
        {
            string[] vector = new string[3];
            int counter = this.characterCounter(dir, "-");

            if (counter == 6)
            {
                string a = dir.Substring(0, dir.IndexOf("-")); // nombre de rollo
                string b = dir.Substring(dir.IndexOf("-") + 1, dir.IndexOf("-") + 11);// fecha desde
                string c = dir.Substring(dir.IndexOf("-") + 12); // fecha hasta
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


      //  public static void visitAllDirs(File dir, int fileType) {
		
        //ManagerDirectory managerDirectory = new ManagerDirectory();
        // Table_FileTypeFunctions table_FileTypeFunctions = new Table_FileTypeFunctions();
        // Table_LuceneDBIndexAddressTransaction table_LuceneDBIndexAddressTransaction= new Table_LuceneDBIndexAddressTransaction();
        // string [] vector;
        // string rollNumber="";
		 
        //int contador=0;
        //string nameFile="";
        //if (dir.isDirectory()) { 		    	
	    	
        //        //process Dir
        //        //System.out.println("Indexando " + dir + "...");
        //        //Resources.logEvent("Indexando " + dir + "...");
        //        nameFile=dir.tostring().substring(dir.tostring().lastIndexOf("\\")+1);
	   			    		
        //        if(nameFile!=null){
	    			
        //                if(managerDirectory.characterCounter(nameFile, "-")==6){		    		
        //                 vector = managerDirectory.checkNameDir(nameFile);
        //                 rollNumber=vector[0];

				         
        //                    if(table_LuceneDBIndexAddressTransaction.insertVerifyNameFile(nameFile, "o:\\probando", dir.getAbsolutePath())>0){
        //                        contador++;
        //                        System.out.println("exito"+contador);
        //                    }
        //                    else{
        //                        System.out.println("fracasó!");
        //                    }
        //                    //indexFunctions.documentIndexer(dir, fileType);
        //                }
        //                else{					    		
        //        }
        //    }	
	    	


        //    string[] children = dir.list();
        //    for (int i=0; i<children.length; i++) {	        	        	
        //        File f=new File(dir, children[i]);
        //        System.out.println("nombre del archivo  : "+f);
        //        visitAllDirs(f, fileType);
	        
	        
        //         if (f.isDirectory()==false && f.tostring().indexOf(".")>1) {
        //                 string type=f.tostring().substring( f.tostring().indexOf(".")+1).toUpperCase();
        //                //	System.out.println("ANTESnameFile:: "+f.tostring());
        //                    string selectType=table_FileTypeFunctions.getFileTypeById(""+fileType);
        //                    //System.out.println("selectType:: "+selectType+ "  fileType : " + type);
		        			
        //                     if(type.trim().equals(selectType.trim())){
			        			 
        //                         Table_ProcessedFilesTransaction table_ProcessedFilesTransaction = new Table_ProcessedFilesTransaction();
			        			 
        //                            string nameFileSelected=f.tostring().substring(f.tostring().lastIndexOf("\\")+1);
        //                            table_ProcessedFilesTransaction.insertTable_ProcessedFilesByRoll(nameFileSelected, rollNumber);
					             
        //                            //System.out.println("LUEGOnameFile:: "+nameFileSelected);	      
					            	
        //                     }
        //        }
        //    }
	 //   }
	}

       
  //  }
}