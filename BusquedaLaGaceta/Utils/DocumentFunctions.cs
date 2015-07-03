using System.IO;
using BusquedaLaGaceta.Properties;
using Lucene.Net.Documents;
using Lucene.Net.Index;

namespace BusquedaLaGaceta.Utils
{
    public class DocumentFunctions
    {
        public static string CONTENT = "document_content";
    public static string PATH = "document_path";
    public static string NAME = "document_name";
    
    private  static string tempPath;

    
  
    public static string gettempPath() {
		return tempPath;
	}

	public static void settempPath(string tempPath) {
		DocumentFunctions.tempPath = tempPath;
	}

	/**
     * Constructor. Genera una nueva instancia de <code>DocumentFunctions</code>.
     */
    public DocumentFunctions()
	{
  //  	this.settempPath(AUTOINDEXING_PROPERTIES.getstring("tempPath"));
	}
    
    /**
     * De acuerdo al valor del parámetro <code>fileType</code> ejecuta un método dedicado
     * a ese tipo de archivo, siendo hasta ahora los tipos:<br><br>
     * 
     * <b>1</b>: Archivo de Texto (TXT)<br>
     * <b>2</b>: Archivo de Microsoft Word 97 - 2003 (DOC)<br>
     * <b>3</b>: Archivo de Microsoft Excel 97 - 2003 (XLS)<br>
     * <b>4</b>: Archivo de Microsoft PowerPoint 97 - 2003 (PPT)<br>
     * <b>5</b>: Archivo de Portable Document Format (PDF)
     * <b>0</b>: Todos <br>
     * @param fileDocument la ruta de la carpeta que se desea indexar
     * @param writer el índice al que se agregarán los objetos <code>Document</code>
     * @param fileType el código del tipo de archivo
     * 
     * @throws Exception the exception
     */
//    public void generateDocumentFromFS(File fileDocument, IndexWriter writer, int fileType) 
//    {
    	
//        if (fileType == 1)
//            generateDocumentFromFSdotTXT(fileDocument, writer);
//        if (fileType == 2)
//            generateDocumentFromFSdotDOC(fileDocument, writer);  
//        if (fileType == 3)
//            generateDocumentFromFSdotXLS(fileDocument, writer);
//        if (fileType == 4)
//            generateDocumentFromFSdotPPT(fileDocument, writer);
//        if (fileType == 5)
//            generateDocumentFromFSdotPDF(fileDocument, writer);
//        if (fileType == 6) //NO OLVIDAR DE AGREGAR EL ELEMENTO HTML A TABLE_FILETYPE (Nuevo: orivas)
//            generateDocumentFromFSdotHTM(fileDocument, writer);    		
//        if (fileType == 7) //NO OLVIDAR DE AGREGAR EL ELEMENTO JPG A TABLE_FILETYPE (Nuevo: orivas)
//            generateDocumentFromFSdotJPG(fileDocument, writer);
//        if (fileType == 8) //NO OLVIDAR DE AGREGAR EL ELEMENTO BMP A TABLE_FILETYPE (Nuevo: orivas)
//            generateDocumentFromFSdotBMP(fileDocument, writer);
//        if (fileType == 9) //NO OLVIDAR DE AGREGAR EL ELEMENTO TIF A TABLE_FILETYPE (Nuevo: orivas)
//            generateDocumentFromFSdotTIF(fileDocument, writer);
//        if (fileType == 10) 
//            generateDocumentFromFSAll(fileDocument, writer); 
//    }
    
//    /**
//     * Genera una colección de objetos <code>File</code> a partir de una ubicación del FS.
//     * Se tendrán en cuenta los archivos con extensión <code>TXT</code>.
//     * El objeto generado contendrá los datos de la carpeta que se indexará, y luego será
//     * añadida al índice. Por medio de un ciclo, se crean objetos <code>Document</code> con 
//     * los datos del archivo que se encuentra en proceso, que luego se agregan al índice.
//     * El ciclo finaliza cuando no queden más archivos que indexar.
//     * 
//     * @param fileDocument la ruta de la carpeta que se desea indexar
//     * @param writer el índice al que se agregarán los objetos <code>Document</code>
//     * 
//     * @throws Exception la excepcion
//     * 
//     */
//    private void generateDocumentFromFSdotTXT(File fileDocument, IndexWriter writer) 
//    {
//        File[] files = fileDocument.listFiles();
//        bool flag = false;

//        try
//        {
//            for (File file : files)
//            {
//                if (file.isFile() && file.canRead() && file.getName().toLowerCase().endsWith(".txt"))
//                {
//                    Document document = new Document();
					
//                    //System.out.println("Indexando el archivo: " + file.getAbsolutePath());
//                    Resources.logEvent("Indexando el archivo: " + file.getAbsolutePath());
					
//                    document.add(new Field(CONTENT, new FileReader(file)));
//                    document.add(new Field(PATH, file.getPath(), Field.Store.YES, Field.Index.NO));
//                    document.add(new Field(NAME, file.getName(), Field.Store.YES, Field.Index.ANALYZED));
//                    flag = true;
					
//                    writer.addDocument(document);
//                    writer.commit();
//                }		
//            }
//            if (!flag)
//                Resources.logEvent("**No hay archivos TXT");
//                //System.out.println("**No hay archivos TXT");
//        }
//        catch (Exception e)
//        {
//            // TODO Auto-generated catch block
//            //e.printStackTrace();
//            Resources.logError(e, null);
//        }
//    }
	
//    /**
//     * Genera una colección de objetos <code>File</code> a partir de una ubicación del FS.
//     * Se tendrán en cuenta los archivos con extensión <code>DOC</code>.
//     * El objeto generado contendrá los datos de la carpeta que se indexará, y luego será
//     * añadida al índice. Por medio de un ciclo, se crean objetos <code>Document</code> con 
//     * los datos del archivo que se encuentra en proceso, que luego se agregan al índice.
//     * El ciclo finaliza cuando no queden más archivos que indexar.
//     * 
//     * @param fileDocument la ruta de la carpeta que se desea indexar
//     * @param writer el índice al que se agregarán los objetos <code>Document</code>
//     * 
//     * @throws Exception la excepcion
//     * 
//     */
//    private void generateDocumentFromFSdotDOC(File fileDocument, IndexWriter writer) throws Exception
//    {
//        File[] files = fileDocument.listFiles();
//        boolean flag = false;
		
//        try
//        {
//            for (File file : files)
//            {
//                if (file.isFile() && file.canRead() && file.getName().toLowerCase().endsWith(".doc"))
//                {
//                    Document document = new Document();
		
//                    //System.out.println("Indexando el archivo: " + file.getAbsolutePath());
//                    Resources.logEvent("Indexando el archivo: " + file.getAbsolutePath());
					
//                    //Uso POI para crear un nuevo FileStream para procesar el archivo DOC
//                    POIFSFileSystem poiFileSystem = new POIFSFileSystem(new FileInputStream(file.getAbsolutePath()));
//                    //Creo un WordExtractor para extraer los datos del DOC
//                    WordExtractor extractor = new WordExtractor(poiFileSystem);
								    
//                    //Guardo el texto del DOC en un stringReader para pasarlo al Field del Document
//                    stringReader wordText = new stringReader(extractor.getText());
				    
//                    document.add(new Field(CONTENT, wordText));
//                    document.add(new Field(PATH, file.getPath(), Field.Store.YES, Field.Index.NO));
//                    document.add(new Field(NAME, file.getName(), Field.Store.YES, Field.Index.ANALYZED));
				    
//                    flag = true;
				    
//                    writer.addDocument(document);
//                    writer.commit();
//                }
//            }
//            if (!flag)
//                Resources.logEvent("**No hay archivos DOC");
//                //System.out.println("**No hay archivos DOC");
//        }
//        catch (Exception e)
//        {
//            // TODO Auto-generated catch block
//            //e.printStackTrace();
//            Resources.logError(e, null);
//        }
//    }
	
//    /**
//     * Genera una colección de objetos <code>File</code> a partir de una ubicación del FS.
//     * Se tendrán en cuenta los archivos con extensión <code>XLS</code>.
//     * El objeto generado contendrá los datos de la carpeta que se indexará, y luego será
//     * añadida al índice. Por medio de un ciclo, se crean objetos <code>Document</code> con 
//     * los datos del archivo que se encuentra en proceso, que luego se agregan al índice.
//     * El ciclo finaliza cuando no queden más archivos que indexar.
//     * 
//     * @param fileDocument la ruta de la carpeta que se desea indexar
//     * @param writer el índice al que se agregarán los objetos <code>Document</code>
//     * 
//     * @throws Exception la excepcion
//     * 
//     */
//    private void generateDocumentFromFSdotXLS(File fileDocument, IndexWriter writer) throws Exception
//    {
//        File[] files = fileDocument.listFiles();
//        boolean flag = false;
		
//        try
//        {	
	
//            for (File file : files)
//            {
//                if (file.isFile() && file.canRead() && file.getName().toLowerCase().endsWith(".xls"))
//                {
//                    Document document = new Document();
					
//                    //System.out.println("Indexando el archivo: " + file.getAbsolutePath());
//                    Resources.logEvent("Indexando el archivo: " + file.getAbsolutePath());
					
//                    //Uso POI para crear un nuevo FileStream para procesar el archivo XLS
//                    POIFSFileSystem poiFileSystem = new POIFSFileSystem(new FileInputStream(file.getAbsolutePath()));
//                    //Creo un ExcelExtractor para extraer los datos del XLS
//                    ExcelExtractor extractor = new ExcelExtractor(poiFileSystem);
				    
//                    //Guardo el texto del XLS en un stringReader para pasarlo al Field del Document
//                    stringReader excelText = new stringReader(extractor.getText());
				    
//                    document.add(new Field(CONTENT, excelText));
//                    document.add(new Field(PATH, file.getPath(), Field.Store.YES, Field.Index.NO));
//                    document.add(new Field(NAME, file.getName(), Field.Store.YES, Field.Index.ANALYZED));
				    
//                    flag = true;
				    
//                    writer.addDocument(document);
//                    writer.commit();
//                }
//            }
//            if (!flag)
//                Resources.logEvent("**No hay archivos XLS");
//                //System.out.println("**No hay archivos XLS");

//        }
//        catch (Exception e)
//        {
//            // TODO Auto-generated catch block
//            //e.printStackTrace();
//            Resources.logError(e, null);
//        }
//    }
	
//    /**
//     * Genera una colección de objetos <code>File</code> a partir de una ubicación del FS.
//     * Se tendrán en cuenta los archivos con extensión <code>PPT</code>.
//     * El objeto generado contendrá los datos de la carpeta que se indexará, y luego será
//     * añadida al índice. Por medio de un ciclo, se crean objetos <code>Document</code> con 
//     * los datos del archivo que se encuentra en proceso, que luego se agregan al índice.
//     * El ciclo finaliza cuando no queden más archivos que indexar.
//     * 
//     * @param fileDocument la ruta de la carpeta que se desea indexar
//     * @param writer el índice al que se agregarán los objetos <code>Document</code>
//     * 
//     * @throws Exception la excepcion
//     * 
//     */
//    private void generateDocumentFromFSdotPPT(File fileDocument, IndexWriter writer) throws Exception
//    {
//        File[] files = fileDocument.listFiles();
//        boolean flag = false;
		
//        try
//        {
//            for (File file : files)
//            {
//                if (file.isFile() && file.canRead() && file.getName().toLowerCase().endsWith(".ppt"))
//                {
//                    Document document = new Document();
					
//                    //System.out.println("Indexando el archivo: " + file.getAbsolutePath());
//                    Resources.logEvent("Indexando el archivo: " + file.getAbsolutePath());
					
//                    //Uso POI para crear un nuevo FileStream para procesar el archivo PPT
//                    POIFSFileSystem poiFileSystem = new POIFSFileSystem(new FileInputStream(file.getAbsolutePath()));
//                    //Creo un PowerPointExtractor para extraer los datos del PPT
//                    PowerPointExtractor extractor = new PowerPointExtractor(poiFileSystem);
				    
//                    //Guardo el texto del PPT en un stringReader para pasarlo al Field del Document
//                    stringReader powerText = new stringReader(extractor.getText());
				    
//                    document.add(new Field(CONTENT, powerText));
//                    document.add(new Field(PATH, file.getPath(), Field.Store.YES, Field.Index.NO));
//                    document.add(new Field(NAME, file.getName(), Field.Store.YES, Field.Index.ANALYZED));
				    
//                    flag = true;
				    
//                    writer.addDocument(document);
//                    writer.commit();
//                }
//            }
//            if (!flag)
//                Resources.logEvent("**No hay archivos PPT");
//                //System.out.println("**No hay archivos PPT");
//        }
//        catch (Exception e)
//        {
//            // TODO Auto-generated catch block
//            //e.printStackTrace();
//            Resources.logError(e, null);
//        }
//    }
	
//    /**
//     * Genera una colección de objetos <code>File</code> a partir de una ubicación del FS.
//     * Se tendrán en cuenta los archivos con extensión <code>PDF</code>.
//     * El objeto generado contendrá los datos de la carpeta que se indexará, y luego será
//     * añadida al índice. Por medio de un ciclo, se crean objetos <code>Document</code> con 
//     * los datos del archivo que se encuentra en proceso, que luego se agregan al índice.
//     * El ciclo finaliza cuando no queden más archivos que indexar.
//     * 
//     * @param fileDocument la ruta de la carpeta que se desea indexar
//     * @param writer el índice al que se agregarán los objetos <code>Document</code>
//     * 
//     * @throws Exception la excepcion
//     * 
//     */
//    private void generateDocumentFromFSdotPDF(File fileDocument, IndexWriter writer) throws Exception
//    {
//        File[] files = fileDocument.listFiles();
//        boolean flag = false;
		
//        try
//        {
//            for (File file : files)
//            {
//                if (file.isFile() && file.canRead() && file.getName().toLowerCase().endsWith(".pdf"))
//                {
//                    Document document = new Document();
					
//                    //System.out.println("Indexando el archivo: " + file.getAbsolutePath());
//                    Resources.logEvent("Indexando el archivo: " + file.getAbsolutePath());
					
//                    //Uso PDFBox para crear un nuevo FileStream para procesar el archivo PDF
//                    FileInputStream fileInputStream = new FileInputStream(new File(file.getAbsolutePath()));
//                    //Creo un PDF Parser para procesar el contenido del PDF
//                    PDFParser pdfParser = new PDFParser(fileInputStream);
//                    pdfParser.parse();
//                    //PDF en memoria 
//                    COSDocument cosDocument = pdfParser.getDocument();
//                    //Extrae el texto, ignorando el formato
//                    PDFTextStripper pdfStripper = new PDFTextStripper();
				    
//                    try
//                    {					
//                        //Guardo el texto del PDF en un stringReader para pasarlo al Field del Document
//                        stringReader powerText = new stringReader(pdfStripper.getText(new PDDocument(cosDocument)));
					    
//                        document.add(new Field(CONTENT, powerText));
//                        document.add(new Field(PATH, file.getPath(), Field.Store.YES, Field.Index.NO));
//                        document.add(new Field(NAME, file.getName(), Field.Store.YES, Field.Index.ANALYZED));
					
//                        flag = true;
					    
//                        writer.addDocument(document);
//                        writer.commit();
//                    }
//                    catch (NoClassDefFoundError e)
//                    {
//                        // TODO Auto-generated catch block
//                        //e.printStackTrace();
//                        Resources.logError(e, "NoClassDefFoundError");
//                    }	
//                    finally
//                    {
//                        //Libero la memoria
//                        cosDocument.close();					    
//                    }
//                }
//            }
//            if (!flag)
//                Resources.logEvent("**No hay archivos PDF");
//                //System.out.println("**No hay archivos PDF");
//        }
//        catch (Exception e)
//        {
//            // TODO Auto-generated catch block
//            //e.printStackTrace();
//            Resources.logError(e, "Excepcion al parsear PDF");
//        }
//    }
	
	
//    /**
//     * Genera una colección de objetos <code>File</code> a partir de una ubicación del FS.
//     * Se tendrán en cuenta los archivos con extensión <code>HTML</code>.
//     * El objeto generado contendrá los datos de la carpeta que se indexará, y luego será
//     * añadida al índice. Por medio de un ciclo, se crean objetos <code>Document</code> con 
//     * los datos del archivo que se encuentra en proceso, que luego se agregan al índice.
//     * El ciclo finaliza cuando no queden más archivos que indexar.
//     * 
//     * @param fileDocument la ruta de la carpeta que se desea indexar
//     * @param writer el índice al que se agregarán los objetos <code>Document</code>
//     * 
//     * @throws Exception la excepcion
//     * 
//     */
//    private void generateDocumentFromFSdotHTM(File fileDocument, IndexWriter writer) throws Exception
//    {
//        File[] files = fileDocument.listFiles();
//        boolean flag = false;
//        string TEXTO_LET= "abcdefghijklmnñopqrstuvwxyzáéíóúABCDEFGHIJKLMNÑOPQRSTUVWXYZÁÉÍÓÚ ";
//        string TEXTO_NUM= "0123456789";
//        string TEXTO_SYM= "¡!'¿?;:.,-_\\/=+*%<>(){}&#°@";

//        try
//        {
//            for (File file : files)
//            {			
//                if (file.isFile() && file.canRead() && (file.getName().toLowerCase().endsWith(".htm") || file.getName().toLowerCase().endsWith(".html")))
//                {
//                    Document document = new Document();
					
//                    //System.out.println("Indexando el archivo: " + file.getAbsolutePath());
//                    Resources.logEvent("Indexando el archivo: " + file.getAbsolutePath());
					
//                    //Uso swing.text.html.parser para traer el texto, a futuro puede emplearse
//                    //algo mas complejo como Jericho HTML Parser (VER AQUI)
//                    URL toRead;
//                    toRead = new URL("FILE:/" + file.getAbsolutePath());
//                    BufferedReader in = new BufferedReader(
//                    new InputStreamReader(toRead.openStream()));
//                    htmlParser d = new htmlParser(in);
//                    d.parse();
//                    in.close();		
//                    string htmlText= d.tostring();
//                    for(int i= 0; i< htmlText.length(); i++) 
//                    {
//                        char x = htmlText.charAt(i); 
									
//                        //Si no lo encuentra en ninguna de las cadenas de control...
//                        if (TEXTO_LET.indexOf(x)== -1)
//                            if (TEXTO_NUM.indexOf(x)== -1)
//                                if (TEXTO_SYM.indexOf(x)== -1)		
//                                    htmlText= htmlText.replace(x, ' ');
//                    }  			    			
	
//                    //Guardo el texto del HTML en un stringReader para pasarlo al Field del Document
//                    stringReader finalHtmlText = new stringReader(htmlText);
				    
//                    document.add(new Field(CONTENT, finalHtmlText));
//                    document.add(new Field(PATH, file.getPath(), Field.Store.YES, Field.Index.NO));
//                    document.add(new Field(NAME, file.getName(), Field.Store.YES, Field.Index.ANALYZED));
				    
//                    flag = true;			   
				    
//                    writer.addDocument(document);
//                    writer.commit();
//                }
//            }
//            if (!flag)
//                Resources.logEvent("**No hay archivos HTML");
//                //System.out.println("**No hay archivos HTML");
//        }
//        catch (Exception e)
//        {
//            // TODO Auto-generated catch block
//            //e.printStackTrace();
//            Resources.logError(e, null);
//        }
//    }
	

//    /**
//     * Genera una colección de objetos <code>File</code> a partir de una ubicación del FS.
//     * Se tendrán en cuenta los archivos con extensión <code>JPG</code>.
//     * El objeto generado contendrá los datos de la carpeta que se indexará, y luego será
//     * añadida al índice. Por medio de un ciclo, se crean objetos <code>Document</code> con 
//     * los datos del archivo que se encuentra en proceso, que luego se agregan al índice.
//     * El ciclo finaliza cuando no queden más archivos que indexar.
//     * 
//     * @param fileDocument la ruta de la carpeta que se desea indexar
//     * @param writer el índice al que se agregarán los objetos <code>Document</code>
//     * 
//     * @throws Exception la excepcion
//     * 
//     */
	
//    private void generateDocumentFromFSdotJPG(File fileDocument, IndexWriter writer) throws Exception
//    {
//            File[] files = fileDocument.listFiles();
//            boolean flag = false;
//            string TEXTO_LET= "abcdefghijklmnñopqrstuvwxyzáéíóúABCDEFGHIJKLMNÑOPQRSTUVWXYZÁÉÍÓÚ ";
//            string TEXTO_NUM= "0123456789";
//            string TEXTO_SYM= "¡!'¿?;:.,-_\\/=+*%<>(){}&#°@";
//            string tempPath= AUTOINDEXING_PROPERTIES.getstring("tempPath");        
//            string executionPath = System.getProperty("user.dir");
		      
//            try
//            {
//            for (File file : files)
//            {			
//                if (file.isFile() && file.canRead() && (file.getName().toLowerCase().endsWith(".jpg") || file.getName().toLowerCase().endsWith(".jpeg")))
//                {
//                    Document document = new Document();
					
//                    System.out.println("\n\n debug Indexando el archivo: " + file.getAbsolutePath()+"\n\n");							
//                    System.out.println("\n\nexecutionPath : " + executionPath+"\n\n");
//                    string nameFile= file.getAbsolutePath().substring( file.getAbsolutePath().lastIndexOf("\\")+1);
			
//                    Resources.logEvent("Indexando el archivo: " + file.getAbsolutePath());
//                    //contador++;
//                    //System.out.println("\n DEBUGnameFile:: "+nameFile);
//                    nameFile=nameFile.substring(0,nameFile.indexOf("."));
				
//                    //System.out.println("\n DEBUGnameFile  + txt :: "+nameFile + ".txt");
//                    ////////////////////////////////////////////////////////////////////////
//                    //Elimina los archivos anteriores
//                    boolean exists1 = true;
//                    boolean success1 = true;
//                    if (exists1)				
//                        success1 =true;
					
//                    boolean exists2 = true;
//                    boolean success2 = true;
									
//                    //	success2 = (new File(tempPath + "\\imgtemp.txt")).delete();
									
//                    if ((success1) && (success2)) 
//                    {
//                    //	System.out.println("teoria comprobada 1");
//                        //////////////////////////////////////////////////////////////////////
//                        // Elimino Ok archivos
//                        //Primeramente convierte el archivo de JPG a TIFF sin compresion (que es lo que espera el OCR Tesseract)
//                    /* ANDRES DESCOMENTAR LUEGO
//                        try 
//                        { */
//                             // get runtime environment and execute child process 
//                           //  Runtime systemShell = Runtime.getRuntime(); 
						  
							
//                            //   System.out.println(executionPath + "\\utils\\convert \"" + file.getAbsolutePath() + "\" -compress none \"" + tempPath + "\\imgtemp.tif\" ");
//                           //  Process output = systemShell.exec(executionPath + "\\utils\\convert \"" + file.getAbsolutePath() + "\" -compress none \"" + tempPath + "\\imgtemp.tif\" ");			     
						  
						     
						     
//                             // get process exit value
//                           //  int exitVal = output.waitFor();
//                        //     int exitVal = doWaitFor(output);
//                             int exitVal=2;
//                           //  System.out.println("aca crea el archivo .tif que recibira como parametro, exitVal ::");
//                           //  System.out.println("Process Exit Value : "+ exitVal);
//                           //  Resources.logEvent("Process Exit Value : "+ exitVal);
//                    /*	} 
//                         ANDRES::  DESCONMMENTAR LUEGO 
//                        catch (IOException ioe)
//                        { 
//                             //System.err.println(ioe);
//                            Resources.logError(ioe, null);
//                        } */

//                        ///////////////////////////////////////////////////////////////////
//                        //Chequea si pudo crear el nuevo archivo TIF
//                        //exists1 = (new File(tempPath + "\\imgtemp.tif")).exists();
//                        //ANDRESLA SIGUEINTE LINEA FUE AGREGADA TAMBEIN 
//                        exists1=true;
//                        //boolean exists1 = (new File(tempPath + "\\imgtemp" + contador + ".tif")).exists();
//                        if (exists1)
//                        {  //System.out.println("teoria  comprobada2");
//                            //System.out.println(" se creo el tempPath  :::  "+tempPath + "\\imgtemp.tif");
//                            //Segunda realiza el ocr sobre el tif generado
//                        /*	try 
//                            { */
//                                 // get runtime environment and execute child process 
//                                 Runtime systemShell = Runtime.getRuntime(); 
//                                 Resources r = new Resources();
//                                string cadena =  r.getNowHour().replace(":","_");
//                                 //NOTA POR AHORA EN ESPAÑOL, VER COMO CONFIGURAR EL OCR (VER AQUI)
//                                //System.out.println(executionPath + "\\utils\\tesseract \"" + tempPath + "\\imgtemp.tif\" \"" + tempPath + "\\imgtemp\" -l spa");
//                                 //esta sl al linea original ANDRES Process output = systemShell.exec(executionPath + "\\utils\\tesseract \"" + tempPath + "\\imgtemp.tif\" \"" + tempPath + "\\imgtemp\" -l spa");
//                            //    Process   output = systemShell.exec("C:\\Program Files\\Tesseract-OCR\\tesseract \"" + "O:\\Aplika\\AutoIndexing\\Test_IndexDir_tmp\\imgtemp.tif\" \"" +  "O:\\Aplika\\AutoIndexing\\Test_IndexDir_tmp\\imgtemp\" -l spa");
							    
							    
//                                 // get process exit value
//                                 //int exitVal = output.waitFor();   
//                                /*int Andres esto va desconetado luego de traer los TRY CATCH anteriores*/
//                              //   exitVal = doWaitFor(output);
		
//                              //  System.out.println("teoria  comprobada3");
//                    /*		} 
//                            catch (IOException ioe)
//                            { 
//                                //System.err.println(ioe);
//                                Resources.logError(ioe, null);
//                            }		*/	
						
//                            ///////////////////////////////////////////////////////////////////
//                            //Chequea si pudo crear el nuevo archivo TXT
//                                 exists2=true;
//                              System.out.println("verifica :  "+tempPath + "\\"+nameFile+".txt");
//                            exists2 = (new File(tempPath + "\\"+nameFile+".txt")).exists();
//                              System.out.println("verifica :  "+tempPath + "\\"+nameFile+".txt    = "+exists2);
//                            //System.out.println("\n\n\nimgJPG , exist2 =="+exists2+"\n\n\n");
//                            //exists2= true;
//                            // andres  la anterior  linea tambien esta agregada
//                            //boolean exists2 = (new File(tempPath + "\\imgtemp" + contador + ".txt")).exists();
//                            if (exists2)
//                            {					
//                                //Obtiene el archivo de texto generado				
//                                byte[] buffer = new byte[(int) new File(tempPath + "\\"+nameFile+".txt").length()];
//                                //byte[] buffer = new byte[(int) new File(tempPath + "\\imgtemp" + contador + ".txt").length()];							
//                                BufferedInputStream f = new BufferedInputStream(new FileInputStream(tempPath + "\\"+nameFile+".txt"));
//                                //BufferedInputStream f = new BufferedInputStream(new FileInputStream(tempPath + "\\imgtemp" + contador + ".txt"));
//                                f.read(buffer);
//                                string textJPG= new string(buffer);
				
//                                //Saca caracteres no texto
//                                for(int i= 0; i< textJPG.length(); i++) 
//                                {
//                                    char x = textJPG.charAt(i); 
												
//                                    //Si no lo encuentra en ninguna de las cadenas de control...
//                                    if (TEXTO_LET.indexOf(x)== -1)
//                                        if (TEXTO_NUM.indexOf(x)== -1)
//                                            if (TEXTO_SYM.indexOf(x)== -1)		
//                                                textJPG= textJPG.replace(x, ' ');
//                                } 
//                                // agrega elnombre del archivo al indexado
//                                textJPG += " "+  nameFile;
							    
//                                f.close();
				
//                                //Guardo el texto del JPG en un stringReader para pasarlo al Field del Document
//                                stringReader finalJPGText = new stringReader(textJPG);
//                                document.add(new Field(CONTENT, finalJPGText));			    
//                                document.add(new Field(PATH, file.getPath(), Field.Store.YES, Field.Index.NO));
//                                document.add(new Field(NAME, file.getName(), Field.Store.YES, Field.Index.ANALYZED));
								
//                                flag = true;			   
							
//                                writer.addDocument(document);
//                                writer.commit();
//                            }
//                            else
//                            {
//                                System.out.println("\n\nERROR si llega hasta la linea 672\n\n");
//                                Table_ErrorImageTransaction te = new Table_ErrorImageTransaction();
//                                Table_ErrorImage table = new Table_ErrorImage();
//                                table.setName(nameFile+".jpg");
//                                table.setPath( file.getAbsolutePath());

//                                try {
//                                    te.insertFile(table);
//                                    System.out.println("se inserto nameFile: "+nameFile+" - path : "+ file.getAbsolutePath());
//                                } catch (Exception e) {
//                                    System.out.println("NO SE INSERTO nameFile: "+nameFile+" - path : "+ file.getAbsolutePath());
//                                    // TODO Auto-generated catch block
//                                    e.printStackTrace();
//                                }
//                                //System.err.println("Sucedio un error al tratar de hacer OCR");
//                                //Resources.logEvent("Sucedio un error al tratar de hacer OCR");
//                            }
//                        }
//                        else
//                        {
//                            //System.err.println("Sucedio un error al tratar de crear el archivo tif sin compresion - para ocr -");
//                            Resources.logEvent("Sucedio un error al tratar de crear el archivo tif sin compresion - para ocr -");
//                        }
//                    }
//                    else
//                    {
//                        //System.err.println("Sucedio un error al tratar de eliminar los archivos temporales");
//                        Resources.logEvent("Sucedio un error al tratar de eliminar los archivos temporales");
//                    }
//                }
//            }
//            if (!flag)
//                Resources.logEvent("**No hay archivos JPG");
//                //System.out.println("**No hay archivos JPG");
//            }
//            catch (Exception e)
//            {
//                // TODO Auto-generated catch block
//                //e.printStackTrace();
//                Resources.logError(e, null);
//            }		
//        }
	
//    private void generateDocumentFromFSdotJPG_original(File fileDocument, IndexWriter writer) throws Exception
//    {
//        File[] files = fileDocument.listFiles();
//        boolean flag = false;
//        string TEXTO_LET= "abcdefghijklmnñopqrstuvwxyzáéíóúABCDEFGHIJKLMNÑOPQRSTUVWXYZÁÉÍÓÚ ";
//        string TEXTO_NUM= "0123456789";
//        string TEXTO_SYM= "¡!'¿?;:.,-_\\/=+*%<>(){}&#°@";
//        string tempPath= this.gettempPath();
		
//        string executionPath = System.getProperty("user.dir");
	      
//        try
//        {
//        for (File file : files)
//        {			
//            if (file.isFile() && file.canRead() && (file.getName().toLowerCase().endsWith(".jpg") || file.getName().toLowerCase().endsWith(".jpeg")))
//            {
//                string nameFile= file.getAbsolutePath().substring( file.getAbsolutePath().lastIndexOf("\\")+1);
//                Document document = new Document();
				
//                //System.out.println("Indexando el archivo: " + file.getAbsolutePath());							
//                //System.out.println("User dir: " + executionPath);
				
//                Resources.logEvent("Indexando el archivo: " + file.getAbsolutePath());
//                //contador++;
				
//                ////////////////////////////////////////////////////////////////////////
//                //Elimina los archivos anteriores
//                boolean exists1 = (new File(tempPath + "\\imgtemp.tif")).exists();
//                boolean success1 = true;
//                if (exists1)				
//                    success1 = (new File(tempPath + "\\imgtemp.tif")).delete();
				
//                boolean exists2 = (new File(tempPath + "\\imgtemp.txt")).exists();
//                boolean success2 = true;
//                if (exists2)				
//                    success2 = (new File(tempPath + "\\imgtemp.txt")).delete();
								
//                if ((success1) && (success2)) 
//                {
//                    //////////////////////////////////////////////////////////////////////
//                    // Elimino Ok archivos
//                    //Primeramente convierte el archivo de JPG a TIFF sin compresion (que es lo que espera el OCR Tesseract)
//                    try 
//                    { 
//                         // get runtime environment and execute child process 
//                         Runtime systemShell = Runtime.getRuntime(); 
//                         Process output = systemShell.exec(executionPath + "\\utils\\convert \"" + file.getAbsolutePath() + "\" -compress none \"" + tempPath + "\\imgtemp.tif\" ");			     
//                         //Process output = systemShell.exec(executionPath + "\\utils\\convert \"" + file.getAbsolutePath() + "\" -compress none \"" + tempPath + "\\imgtemp" + contador + ".tif\" ");
					     
					     
//                         // get process exit value
//                         //int exitVal = output.waitFor();
//                         int exitVal = doWaitFor(output);
					     
//                         //System.out.println("Process Exit Value : "+ exitVal);
//                         Resources.logEvent("Process Exit Value : "+ exitVal);
//                    } 
//                    catch (IOException ioe)
//                    { 
//                         //System.err.println(ioe);
//                        Resources.logError(ioe, null);
//                    }

//                    ///////////////////////////////////////////////////////////////////
//                    //Chequea si pudo crear el nuevo archivo TIF
//                    exists1 = (new File(tempPath + "\\imgtemp.tif")).exists();
//                    //boolean exists1 = (new File(tempPath + "\\imgtemp" + contador + ".tif")).exists();
//                    if (exists1)
//                    {
//                        //Segunda realiza el ocr sobre el tif generado
//                        try 
//                        { 
//                             // get runtime environment and execute child process 
//                             Runtime systemShell = Runtime.getRuntime(); 
//                             //NOTA POR AHORA EN ESPAÑOL, VER COMO CONFIGURAR EL OCR (VER AQUI)
//                            Process output = systemShell.exec(executionPath+"\\Tesseract-OCR\\tesseract \"" + tempPath+"\\imgtemp.tif\" \"" + tempPath+"\\imgtemp\" -l spa");
						 
//                             //Process output = systemShell.exec(executionPath + "\\utils\\tesseract " + tempPath + "\\imgtemp" + contador + ".tif " + tempPath + "\\imgtemp" + contador + " -l spa"); //no se coloca la extension .txt porque tesseract lo hace por defecto
						     
//                             // get process exit value
//                             //int exitVal = output.waitFor();              
//                             int exitVal = doWaitFor(output);
						     
//                             //System.out.println("Process Exit Value : "+ exitVal);
//                             Resources.logEvent("Process Exit Value : "+ exitVal);
//                        } 
//                        catch (IOException ioe)
//                        { 
//                            //System.err.println(ioe);
//                            Resources.logError(ioe, null);
//                        }			
					
//                        ///////////////////////////////////////////////////////////////////
//                        //Chequea si pudo crear el nuevo archivo TXT
//                        exists2 = (new File(tempPath + "\\imgtemp.txt")).exists();
//                        //boolean exists2 = (new File(tempPath + "\\imgtemp" + contador + ".txt")).exists();
//                        if (exists2)
//                        {					
//                            //Obtiene el archivo de texto generado				
//                            byte[] buffer = new byte[(int) new File(tempPath + "\\imgtemp.txt").length()];
//                            //byte[] buffer = new byte[(int) new File(tempPath + "\\imgtemp" + contador + ".txt").length()];							
//                            BufferedInputStream f = new BufferedInputStream(new FileInputStream(tempPath + "\\imgtemp.txt"));
//                            //BufferedInputStream f = new BufferedInputStream(new FileInputStream(tempPath + "\\imgtemp" + contador + ".txt"));
//                            f.read(buffer);
//                            string textJPG= new string(buffer);
			
//                            //Saca caracteres no texto
//                            for(int i= 0; i< textJPG.length(); i++) 
//                            {
//                                char x = textJPG.charAt(i); 
											
//                                //Si no lo encuentra en ninguna de las cadenas de control...
//                                if (TEXTO_LET.indexOf(x)== -1)
//                                    if (TEXTO_NUM.indexOf(x)== -1)
//                                        if (TEXTO_SYM.indexOf(x)== -1)		
//                                            textJPG= textJPG.replace(x, ' ');
//                            }  			
//                            textJPG += " "+  nameFile;
//                            f.close();
			
//                            //Guardo el texto del JPG en un stringReader para pasarlo al Field del Document
//                            stringReader finalJPGText = new stringReader(textJPG);
//                            document.add(new Field(CONTENT, finalJPGText));			    
//                            document.add(new Field(PATH, file.getPath(), Field.Store.YES, Field.Index.NO));
//                            document.add(new Field(NAME, file.getName(), Field.Store.YES, Field.Index.ANALYZED));
							
//                            flag = true;			   
						    
//                            writer.addDocument(document);
//                            writer.commit();
//                        }
//                        else
//                        {
//                            //System.err.println("Sucedio un error al tratar de hacer OCR");
//                            Resources.logEvent("Sucedio un error al tratar de hacer OCR");
//                        }
//                    }
//                    else
//                    {
//                        //System.err.println("Sucedio un error al tratar de crear el archivo tif sin compresion - para ocr -");
//                        Resources.logEvent("Sucedio un error al tratar de crear el archivo tif sin compresion - para ocr -");
//                    }
//                }
//                else
//                {
//                    //System.err.println("Sucedio un error al tratar de eliminar los archivos temporales");
//                    Resources.logEvent("Sucedio un error al tratar de eliminar los archivos temporales");
//                }
//            }
//        }
//        if (!flag)
//            Resources.logEvent("**No hay archivos JPG");
//            //System.out.println("**No hay archivos JPG");
//        }
//        catch (Exception e)
//        {
//            // TODO Auto-generated catch block
//            //e.printStackTrace();
//            Resources.logError(e, null);
//        }		
//    }
	
//    /**
//     * Genera una colección de objetos <code>File</code> a partir de una ubicación del FS.
//     * Se tendrán en cuenta los archivos con extensión <code>JPG</code>.
//     * El objeto generado contendrá los datos de la carpeta que se indexará, y luego será
//     * añadida al índice. Por medio de un ciclo, se crean objetos <code>Document</code> con 
//     * los datos del archivo que se encuentra en proceso, que luego se agregan al índice.
//     * El ciclo finaliza cuando no queden más archivos que indexar.
//     * 
//     * @param fileDocument la ruta de la carpeta que se desea indexar
//     * @param writer el índice al que se agregarán los objetos <code>Document</code>
//     * 
//     * @throws Exception la excepcion
//     * 
//     */
//    public string generateDocumentFromFSdotJPG2(string fileDocument) throws Exception
//    {
//        File file= new File(fileDocument);
//        boolean flag = false;
//        string TEXTO_LET= "abcdefghijklmnñopqrstuvwxyzáéíóúABCDEFGHIJKLMNÑOPQRSTUVWXYZÁÉÍÓÚ ";
//        string TEXTO_NUM= "0123456789";
//        string TEXTO_SYM= "¡!'¿?;:.,-_\\/=+*%<>(){}&#°@";
//        string tempPath= AUTOINDEXING_PROPERTIES.getstring("tempPath2");
		
//        string executionPath = System.getProperty("user.dir");
	    
		
//        string retorno=null;
//        try
//        {
		
//            if (file.isFile() && file.canRead() && (file.getName().toLowerCase().endsWith(".jpg") || file.getName().toLowerCase().endsWith(".jpeg")))
//            {
//                Document document = new Document();
				
//                //System.out.println("Indexando el archivo: " + file.getAbsolutePath());							
//                //System.out.println("User dir: " + executionPath);
				
//                Resources.logEvent("Indexando el archivo: " + file.getAbsolutePath());
//                //contador++;
				
//                ////////////////////////////////////////////////////////////////////////
//                //Elimina los archivos anteriores
//                boolean exists1 = (new File(tempPath + "\\selecction_imgtemp.tif")).exists();
//                boolean success1 = true;
//                if (exists1)				
//                    success1 = (new File(tempPath + "\\selecction_imgtemp.tif")).delete();
				
//                boolean exists2 = (new File(tempPath + "\\selecction_imgtemp.txt")).exists();
//                boolean success2 = true;
//                if (exists2)				
//                    success2 = (new File(tempPath + "\\selecction_imgtemp.txt")).delete();
								
//                if ((success1) && (success2)) 
//                {
//                    //////////////////////////////////////////////////////////////////////
//                    // Elimino Ok archivos
//                    //Primeramente convierte el archivo de JPG a TIFF sin compresion (que es lo que espera el OCR Tesseract)
//                    try 
//                    { 
//                         // get runtime environment and execute child process 
//                         Runtime systemShell = Runtime.getRuntime(); 
//                         Process output = systemShell.exec(executionPath + "\\utils\\convert \"" + file.getAbsolutePath() + "\" -compress none \"" + tempPath + "\\selecction_imgtemp.tif\" ");			     
//                         //Process output = systemShell.exec(executionPath + "\\utils\\convert \"" + file.getAbsolutePath() + "\" -compress none \"" + tempPath + "\\imgtemp" + contador + ".tif\" ");
					     
					     
//                         // get process exit value
//                         //int exitVal = output.waitFor();
//                         int exitVal = doWaitFor(output);
					     
//                         //System.out.println("Process Exit Value : "+ exitVal);
//                         Resources.logEvent("Process Exit Value : "+ exitVal);
//                    } 
//                    catch (IOException ioe)
//                    { 
//                         //System.err.println(ioe);
//                        Resources.logError(ioe, null);
//                    }

//                    ///////////////////////////////////////////////////////////////////
//                    //Chequea si pudo crear el nuevo archivo TIF
//                    exists1 = (new File(tempPath + "\\selecction_imgtemp.tif")).exists();
//                    //boolean exists1 = (new File(tempPath + "\\imgtemp" + contador + ".tif")).exists();
//                    if (exists1)
//                    {
//                        //Segunda realiza el ocr sobre el tif generado
//                        try 
//                        { 
//                             // get runtime environment and execute child process 
//                             Runtime systemShell = Runtime.getRuntime(); 
//                             //NOTA POR AHORA EN ESPAÑOL, VER COMO CONFIGURAR EL OCR (VER AQUI)
//                            Process output = systemShell.exec(executionPath+"\\Tesseract-OCR\\tesseract \"" + tempPath+"\\selecction_imgtemp.tif\" \"" + tempPath+"\\selecction_imgtemp\" -l spa");
//                            System.out.println(executionPath+"\\Tesseract-OCR\\tesseract \"" + tempPath+"\\selecction_imgtemp.tif\" \"" + tempPath+"\\selecction_imgtemp\" -l spa");
//                             //Process output = systemShell.exec(executionPath + "\\utils\\tesseract " + tempPath + "\\imgtemp" + contador + ".tif " + tempPath + "\\imgtemp" + contador + " -l spa"); //no se coloca la extension .txt porque tesseract lo hace por defecto
						     
//                             // get process exit value
//                             //int exitVal = output.waitFor();              
//                             int exitVal = doWaitFor(output);
						     
//                             //System.out.println("Process Exit Value : "+ exitVal);
//                             Resources.logEvent("Process Exit Value : "+ exitVal);
//                        } 
//                        catch (IOException ioe)
//                        { 
//                            //System.err.println(ioe);
//                            Resources.logError(ioe, null);
//                        }			
					
//                        ///////////////////////////////////////////////////////////////////
//                        //Chequea si pudo crear el nuevo archivo TXT
//                        exists2 = (new File(tempPath + "\\selecction_imgtemp.txt")).exists();
//                        //boolean exists2 = (new File(tempPath + "\\imgtemp" + contador + ".txt")).exists();
//                        if (exists2)
//                        {					
//                            //Obtiene el archivo de texto generado				
//                            byte[] buffer = new byte[(int) new File(tempPath + "\\selecction_imgtemp.txt").length()];
//                            //byte[] buffer = new byte[(int) new File(tempPath + "\\imgtemp" + contador + ".txt").length()];							
//                            BufferedInputStream f = new BufferedInputStream(new FileInputStream(tempPath + "\\selecction_imgtemp.txt"));
//                            //BufferedInputStream f = new BufferedInputStream(new FileInputStream(tempPath + "\\imgtemp" + contador + ".txt"));
//                            f.read(buffer);
//                            string textJPG= new string(buffer);
			
//                            //Saca caracteres no texto
//                            for(int i= 0; i< textJPG.length(); i++) 
//                            {
//                                char x = textJPG.charAt(i); 
											
//                                //Si no lo encuentra en ninguna de las cadenas de control...
//                                if (TEXTO_LET.indexOf(x)== -1)
//                                    if (TEXTO_NUM.indexOf(x)== -1)
//                                        if (TEXTO_SYM.indexOf(x)== -1)		
//                                            textJPG= textJPG.replace(x, ' ');
//                            }  			
//                            retorno=textJPG;
//                            f.close();
			
//                            //Guardo el texto del JPG en un stringReader para pasarlo al Field del Document
//                            stringReader finalJPGText = new stringReader(textJPG);
//                            document.add(new Field(CONTENT, finalJPGText));			    
//                            document.add(new Field(PATH, file.getPath(), Field.Store.YES, Field.Index.NO));
//                            document.add(new Field(NAME, file.getName(), Field.Store.YES, Field.Index.ANALYZED));
							
//                            flag = true;			
						    
						
						    
//                        /*    writer.addDocument(document);
//                            writer.commit();*/
//                        }
//                        else
//                        {
//                            //System.err.println("Sucedio un error al tratar de hacer OCR");
//                            Resources.logEvent("Sucedio un error al tratar de hacer OCR");
//                               return null;
//                        }
//                    }
//                    else
//                    {
//                        //System.err.println("Sucedio un error al tratar de crear el archivo tif sin compresion - para ocr -");
//                        Resources.logEvent("Sucedio un error al tratar de crear el archivo tif sin compresion - para ocr -");
//                    }
//                }
//                else
//                {
//                    //System.err.println("Sucedio un error al tratar de eliminar los archivos temporales");
//                    Resources.logEvent("Sucedio un error al tratar de eliminar los archivos temporales");
//                }
//            }
		
		
		
//        if (!flag)
//            Resources.logEvent("**No hay archivos JPG");
//            //System.out.println("**No hay archivos JPG");
//        }
//        catch (Exception e)
//        {
//            // TODO Auto-generated catch block
//            //e.printStackTrace();
//            Resources.logError(e, null);
//        }
//        return retorno;
//    }

	
//    /**
//     * Genera una colección de objetos <code>File</code> a partir de una ubicación del FS.
//     * Se tendrán en cuenta los archivos con extensión <code>BMP</code>.
//     * El objeto generado contendrá los datos de la carpeta que se indexará, y luego será
//     * añadida al índice. Por medio de un ciclo, se crean objetos <code>Document</code> con 
//     * los datos del archivo que se encuentra en proceso, que luego se agregan al índice.
//     * El ciclo finaliza cuando no queden más archivos que indexar.
//     * 
//     * @param fileDocument la ruta de la carpeta que se desea indexar
//     * @param writer el índice al que se agregarán los objetos <code>Document</code>
//     * 
//     * @throws Exception la excepcion
//     * 
//     */
//    private void generateDocumentFromFSdotBMP(File fileDocument, IndexWriter writer) throws Exception
//    {
//        File[] files = fileDocument.listFiles();
//        boolean flag = false;
//        string TEXTO_LET= "abcdefghijklmnñopqrstuvwxyzáéíóúABCDEFGHIJKLMNÑOPQRSTUVWXYZÁÉÍÓÚ ";
//        string TEXTO_NUM= "0123456789";
//        string TEXTO_SYM= "¡!'¿?;:.,-_\\/=+*%<>(){}&#°@";
//        string tempPath= this.gettempPath();

//        string executionPath = System.getProperty("user.dir");
	      
//        try
//        {
//        for (File file : files)
//        {			
//            if (file.isFile() && file.canRead() && file.getName().toLowerCase().endsWith(".bmp"))
//            {
//                Document document = new Document();

//                //System.out.println("Indexando el archivo: " + file.getAbsolutePath());							
//                //System.out.println("User dir: " + executionPath);
				
//                Resources.logEvent("Indexando el archivo: " + file.getAbsolutePath());
//                //contador++;

//                ////////////////////////////////////////////////////////////////////////
//                //Elimina los archivos anteriores
//                boolean exists1 = (new File(tempPath + "\\imgtemp.tif")).exists();
//                boolean success1 = true;
//                if (exists1)				
//                    success1 = (new File(tempPath + "\\imgtemp.tif")).delete();
				
//                boolean exists2 = (new File(tempPath + "\\imgtemp.txt")).exists();
//                boolean success2 = true;
//                if (exists2)				
//                    success2 = (new File(tempPath + "\\imgtemp.txt")).delete();
								
//                if ((success1) && (success2)) 
//                {
//                    //////////////////////////////////////////////////////////////////////
//                    // Elimino Ok archivos	
//                    //Primeramente convierte el archivo de BMP a TIFF sin compresion (que es lo que espera el OCR Tesseract)
//                    try 
//                    { 
//                         // get runtime environment and execute child process 
//                         Runtime systemShell = Runtime.getRuntime(); 
//                         Process output = systemShell.exec(executionPath + "\\utils\\convert \"" + file.getAbsolutePath() + "\" -compress none \"" + tempPath + "\\imgtemp.tif\" ");			     
//                         //Process output = systemShell.exec(executionPath + "\\utils\\convert \"" + file.getAbsolutePath() + "\" -compress none \"" + tempPath + "\\imgtemp" + contador + ".tif\" ");
			     
//                         // get process exit value
//                         //int exitVal = output.waitFor();
//                         int exitVal = doWaitFor(output);
					     
//                         //System.out.println("Process Exit Value : "+ exitVal);
//                         Resources.logEvent("Process Exit Value : "+ exitVal);
//                    } 
//                    catch (IOException ioe)
//                    { 
//                         //System.err.println(ioe);
//                        Resources.logError(ioe, null);
//                    }

//                    ///////////////////////////////////////////////////////////////////
//                    //Chequea si pudo crear el nuevo archivo TIF
//                    exists1 = (new File(tempPath + "\\imgtemp.tif")).exists();
//                    //boolean exists1 = (new File(tempPath + "\\imgtemp" + contador + ".tif")).exists();					
//                    if (exists1)
//                    {
//                        //Segunda realiza el ocr sobre el tif generado
//                        try 
//                        { 
//                             // get runtime environment and execute child process 
//                             Runtime systemShell = Runtime.getRuntime();
//                             //NOTA POR AHORA EN ESPAÑOL, VER COMO CONFIGURAR EL OCR (VER AQUI)						     
//                             Process 	output = systemShell.exec(executionPath+"\\Tesseract-OCR\\tesseract \"" + tempPath+"\\imgtemp.tif\" \"" + tempPath+"\\imgtemp\" -l spa"); 
//                             //output = systemShell.exec(executionPath + "\\utils\\tesseract \"" + tempPath + "\\imgtemp.tif\" \"" + tempPath + "\\imgtemp\" -l spa"); //no se coloca la extension .txt porque tesseract lo hace por de fecto
//                             //Process output = systemShell.exec(executionPath + "\\utils\\tesseract " + tempPath + "\\imgtemp" + contador + ".tif " + tempPath + "\\imgtemp" + contador + " -l spa"); //no se coloca la extension .txt porque tesseract lo hace por defecto
						     
						  
//                             // get process exit value
//                             //int exitVal = output.waitFor();
//                             int exitVal = doWaitFor(output);
						     
//                             //System.out.println("Process Exit Value : "+ exitVal);
//                             Resources.logEvent("Process Exit Value : "+ exitVal);
//                        } 
//                        catch (IOException ioe)
//                        { 
//                            //System.err.println(ioe);
//                            Resources.logError(ioe, null);
//                        }			
						
//                        ///////////////////////////////////////////////////////////////////
//                        //Chequea si pudo crear el nuevo archivo TXT
//                        exists2 = (new File(tempPath + "\\imgtemp.txt")).exists();
//                        //boolean exists2 = (new File(tempPath + "\\imgtemp" + contador + ".txt")).exists();
//                        if (exists2)
//                        {
//                            //Obtiene el archivo de texto generado				
//                            byte[] buffer = new byte[(int) new File(tempPath + "\\imgtemp.txt").length()];
//                            //byte[] buffer = new byte[(int) new File(tempPath + "\\imgtemp" + contador + ".txt").length()];
//                            BufferedInputStream f = new BufferedInputStream(new FileInputStream(tempPath + "\\imgtemp.txt"));
//                            //BufferedInputStream f = new BufferedInputStream(new FileInputStream(tempPath + "\\imgtemp" + contador + ".txt"));						    
//                            f.read(buffer);
//                            string textBMP= new string(buffer);
			
//                            //Saca caracteres no texto
//                            for(int i= 0; i< textBMP.length(); i++) 
//                            {
//                                char x = textBMP.charAt(i); 
											
//                                //Si no lo encuentra en ninguna de las cadenas de control...
//                                if (TEXTO_LET.indexOf(x)== -1)
//                                    if (TEXTO_NUM.indexOf(x)== -1)
//                                        if (TEXTO_SYM.indexOf(x)== -1)		
//                                            textBMP= textBMP.replace(x, ' ');
//                            } 
						    
//                            f.close();
			
//                            //Guardo el texto del BMP en un stringReader para pasarlo al Field del Document
//                            stringReader finalBMPText = new stringReader(textBMP);
//                            document.add(new Field(CONTENT, finalBMPText));			    
//                            document.add(new Field(PATH, file.getPath(), Field.Store.YES, Field.Index.NO));
//                            document.add(new Field(NAME, file.getName(), Field.Store.YES, Field.Index.ANALYZED));
							
//                            flag = true;			   
						    
//                            writer.addDocument(document);
//                            writer.commit();
//                        }
//                        else
//                        {
//                            //System.err.println("Sucedio un error al tratar de hacer OCR");
//                            Resources.logEvent("Sucedio un error al tratar de hacer OCR");
//                        }
//                    }
//                    else
//                    {
//                        //System.err.println("Sucedio un error al tratar de crear el archivo tif sin compresion - para ocr -");
//                        Resources.logEvent("Sucedio un error al tratar de crear el archivo tif sin compresion - para ocr -");
//                    }
//                }
//                else
//                {
//                    //System.err.println("Sucedio un error al tratar de eliminar los archivos temporales");
//                    Resources.logEvent("Sucedio un error al tratar de eliminar los archivos temporales");
//                }
//            }
//        }
//        if (!flag)
//            Resources.logEvent("**No hay archivos BMP");
//            //System.out.println("**No hay archivos BMP");
//        }
//        catch (Exception e)
//        {
//            // TODO Auto-generated catch block
//            //e.printStackTrace();
//            Resources.logError(e, null);
//        }
//    }

	
//    /**
//     * Genera una colección de objetos <code>File</code> a partir de una ubicación del FS.
//     * Se tendrán en cuenta los archivos con extensión <code>TIF</code>.
//     * El objeto generado contendrá los datos de la carpeta que se indexará, y luego será
//     * añadida al índice. Por medio de un ciclo, se crean objetos <code>Document</code> con 
//     * los datos del archivo que se encuentra en proceso, que luego se agregan al índice.
//     * El ciclo finaliza cuando no queden más archivos que indexar.
//     * 
//     * @param fileDocument la ruta de la carpeta que se desea indexar
//     * @param writer el índice al que se agregarán los objetos <code>Document</code>
//     * 
//     * @throws Exception la excepcion
//     * 
//     */
//    private void generateDocumentFromFSdotTIF(File fileDocument, IndexWriter writer) throws Exception
//    {
//        File[] files = fileDocument.listFiles();
//        boolean flag = false;
//        string TEXTO_LET= "abcdefghijklmnñopqrstuvwxyzáéíóúABCDEFGHIJKLMNÑOPQRSTUVWXYZÁÉÍÓÚ ";
//        string TEXTO_NUM= "0123456789";
//        string TEXTO_SYM= "¡!'¿?;:.,-_\\/=+*%<>(){}&#°@";
//        string tmpPath= this.gettempPath();
//        string executionPath = System.getProperty("user.dir");
	      
//        try
//        {
//        for (File file : files)
//        {			
//            if (file.isFile() && file.canRead() && file.getName().toLowerCase().endsWith(".tif"))
//            {
				
//                Document document = new Document();
				
//                System.out.println("\n\n debug Indexando el archivo: " + file.getAbsolutePath()+"\n\n");							
//                System.out.println("\n\nexecutionPath : " + executionPath+"\n\n");
//                string nameFile= file.getAbsolutePath().substring( file.getAbsolutePath().lastIndexOf("\\")+1);
		
//                Resources.logEvent("Indexando el archivo: " + file.getAbsolutePath());
//                //contador++;
//                System.out.println("\n DEBUGnameFile:: "+nameFile);
//                nameFile=nameFile.substring(0,nameFile.indexOf("."));
			
//                System.out.println("\n DEBUGnameFile  + txt :: "+nameFile + ".txt");
		
//                ////////////////////////////////////////////////////////////////////////
//                //Elimina los archivos anteriores
//                boolean exists1 = true;
//                boolean success1 = true;
//                if (exists1)				
//                    success1 =true;
				
//                boolean exists2 = true;
//                boolean success2 = true;
								
//                if ((success1) && (success2)) 
//                {
//                    //////////////////////////////////////////////////////////////////////
//                    // Elimino Ok archivos
//                    //Primeramente convierte el archivo de TIFF (prob. con compresion) a TIFF sin compresion (que es lo que espera el OCR Tesseract)
//                    //OJO, ESTO POR AHORA FUNCIONA PARA UNA PAGINA... VER BIEN COMO HACER PARA MULTIPAGINA (VER AQUI)
//                        /* ANDRES DESCOMENTAR LUEGO
//                    try 
//                    { */
//                         // get runtime environment and execute child process 
//                       //  Runtime systemShell = Runtime.getRuntime(); 
//                         //Process output = systemShell.exec(executionPath + "\\utils\\convert \"" + file.getAbsolutePath() + "\" -compress none \"" + tmpPath + "\\imgtemp.tif\" ");			     
//                         //Process output = systemShell.exec(executionPath + "\\utils\\convert \"" + file.getAbsolutePath() + "\" -compress none \"" + tmpPath + "\\imgtemp" + contador + ".tif\" ");					     
//                         // get process exit value
//                         //int exitVal = output.waitFor();
//                         //int exitVal = doWaitFor(output);
//                           int exitVal = 2;
					     
//                         //System.out.println("Process Exit Value : "+ exitVal);
//                         Resources.logEvent("Process Exit Value : "+ exitVal);
//                    /*	} 
//                     ANDRES::  DESCONMMENTAR LUEGO 
//                    catch (IOException ioe)
//                    { 
//                         //System.err.println(ioe);
//                        Resources.logError(ioe, null);
//                    } */

//                    ///////////////////////////////////////////////////////////////////
//                    //Chequea si pudo crear el nuevo archivo TIF
//                    exists1 = (new File(tmpPath + "\\imgtemp.tif")).exists();
//                    //ANDRESLA SIGUEINTE LINEA FUE AGREGADA TAMBEIN 
//                    exists1 = true;
//                    //boolean exists1 = (new File(tmpPath + "\\imgtemp" + contador + ".tif")).exists();
//                    if (exists1)
//                    {					
//                        /////////////////////////////////////////////////////////////////////
//                        //Segunda realiza el ocr sobre el tif generado
//                    /*	try 
//                        { */
//                             // get runtime environment and execute child process 
//                             Runtime systemShell = Runtime.getRuntime(); 
//                             //NOTA POR AHORA EN ESPAÑOL, VER COMO CONFIGURAR EL OCR (VER AQUI)						     
//                             //ATENCION SE ENCONTRO UN BUG CON IMAGENES COMO Comprobante de Pago.tif CUANDO SE HACE -l spa, POR ELLO SE SACO EL ENVIO DE ESTA PARAMETRO PARA TIF (VER AQUI)
//                             //Process output = systemShell.exec(executionPath + "\\utils\\tesseract \"" + tmpPath + "\\imgtemp.tif\" \"" + tmpPath + "\\imgtemp\""); //-l spa"); //no se coloca la extension .txt porque tesseract lo hace por defecto
						     
//                             // la linea a continuacion es la linea que corresponde a "output" 10-12-2012 (andres)
//                             //Process 	output = systemShell.exec(executionPath+"\\Tesseract-OCR\\tesseract \"" + tempPath+"\\imgtemp.tif\" \"" + tempPath+"\\imgtemp\" -l spa");
						     
//                             //Process output = systemShell.exec(executionPath + "\\utils\\tesseract " + tmpPath + "\\imgtemp" + contador + ".tif " + tmpPath + "\\imgtemp" + contador + " -l spa"); //no se coloca la extension .txt porque tesseract lo hace por defecto						     
	
//                             // get process exit value
//                             //int exitVal = output.waitFor();
//                          //   int exitVal = doWaitFor(output);
	
//                             //System.out.println("Process Exit Value : "+ exitVal);
//                             Resources.logEvent("Process Exit Value : "+ exitVal);
//                    /*	} 
//                        catch (IOException ioe)
//                        {
//                            // TODO Auto-generated catch block
//                            //System.err.println(ioe);
//                            Resources.logError(ioe, null);
//                        }
//                    */
						
//                        ///////////////////////////////////////////////////////////////////
//                        //Chequea si pudo crear el nuevo archivo TXT
//                        //exists2 = (new File(tmpPath + "\\imgtemp.txt")).exists();
						
//                             exists2=true;
//                             System.out.println("verifica :  "+tempPath + "\\"+nameFile+".txt");
//                        exists2 = (new File(tempPath + "\\"+nameFile+".txt")).exists();
						
//                        System.out.println("\n\n\nimgTIFF, exist2 =="+exists2+"\n\n\n");
				
//                        //boolean exists2 = (new File(tmpPath + "\\imgtemp" + contador +".txt")).exists();						
//                        if (exists2)
//                        {
//                            //Obtiene el archivo de texto generado				
//                            //byte[] buffer = new byte[(int) new File(tmpPath + "\\imgtemp.txt").length()];
//                            byte[] buffer = new byte[(int) new File(tempPath + "\\"+nameFile+".txt").length()];
//                            //byte[] buffer = new byte[(int) new File(tmpPath + "\\imgtemp" + contador + ".txt").length()];							
//                             BufferedInputStream f = new BufferedInputStream(new FileInputStream(tempPath + "\\"+nameFile+".txt"));
//                            //BufferedInputStream f = new BufferedInputStream(new FileInputStream(tmpPath + "\\imgtemp" + contador + ".txt"));
//                            f.read(buffer);
//                            string textTIF= new string(buffer);
		
//                            //Saca caracteres no texto
//                            for(int i= 0; i< textTIF.length(); i++) 
//                            {
//                                char x = textTIF.charAt(i); 
											
//                                //Si no lo encuentra en ninguna de las cadenas de control...
//                                if (TEXTO_LET.indexOf(x)== -1)
//                                    if (TEXTO_NUM.indexOf(x)== -1)
//                                        if (TEXTO_SYM.indexOf(x)== -1)		
//                                            textTIF= textTIF.replace(x, ' ');
//                            }  	
//                            textTIF += " "+  nameFile;

//                            f.close();
		
//                            //Guardo el texto del TIF en un stringReader para pasarlo al Field del Document
//                            stringReader finalTIFText = new stringReader(textTIF);
//                            document.add(new Field(CONTENT, finalTIFText));			    
//                            document.add(new Field(PATH, file.getPath(), Field.Store.YES, Field.Index.NO));
//                            document.add(new Field(NAME, file.getName(), Field.Store.YES, Field.Index.ANALYZED));
							
//                            flag = true;			   
						    
//                            writer.addDocument(document);
//                            writer.commit();
//                        }
//                        else
//                        {
//                            System.out.println("\nentraElse-\nentraElse-\nentraElse-\nentraElse-\nentraElse-\nentraElse-\nentraElse-\nentraElse-\nentraElse-\nentraElse-\nentraElse-\nentraElse-" +
//                            "\nentraElse-\nentraElse-\nentraElse-\nentraElse-\nentraElse-\nentraElse-\nentraElse-");
//                    Table_ErrorImageTransaction te = new Table_ErrorImageTransaction();
//                    Table_ErrorImage table = new Table_ErrorImage();
//                    table.setName(nameFile+".tif");
//                    table.setPath( file.getAbsolutePath());

//                    try {
//                        te.insertFile(table);
//                        System.out.println("se inserto nameFile: "+nameFile+" - path : "+ file.getAbsolutePath());
//                    } catch (Exception e) {
//                        System.out.println("NO SE INSERTO nameFile: "+nameFile+" - path : "+ file.getAbsolutePath());
//                        // TODO Auto-generated catch block
//                        e.printStackTrace();
//                    }


//                        }
//                    }
//                    else
//                    {
//                        //System.err.println("Sucedio un error al tratar de crear el archivo tif sin compresion - para ocr -");
//                        Resources.logEvent("Sucedio un error al tratar de crear el archivo tif sin compresion - para ocr -");
//                    }
//                }
//                else
//                {
//                    //System.err.println("Sucedio un error al tratar de eliminar los archivos temporales");
//                    Resources.logEvent("Sucedio un error al tratar de eliminar los archivos temporales");
//                }				
//            }
//        }
//        if (!flag)
//            Resources.logEvent("**No hay archivos TIF");
//            //System.out.println("**No hay archivos TIF");
//        }
//        catch (Exception e)
//        {
//            // TODO Auto-generated catch block
//            //e.printStackTrace();
//            Resources.logError(e, null);
//        }
//    }
//    private void generateDocumentFromFSdotTIF_original(File fileDocument, IndexWriter writer) throws Exception
//    {
//        File[] files = fileDocument.listFiles();
//        boolean flag = false;
//        string TEXTO_LET= "abcdefghijklmnñopqrstuvwxyzáéíóúABCDEFGHIJKLMNÑOPQRSTUVWXYZÁÉÍÓÚ ";
//        string TEXTO_NUM= "0123456789";
//        string TEXTO_SYM= "¡!'¿?;:.,-_\\/=+*%<>(){}&#°@";
//        string tmpPath= this.gettempPath();
       
//        string executionPath = System.getProperty("user.dir");
	      
//        try
//        {
//        for (File file : files)
//        {			
//            if (file.isFile() && file.canRead() && file.getName().toLowerCase().endsWith(".tif"))
//            {
//                string nameFile= file.getAbsolutePath().substring( file.getAbsolutePath().lastIndexOf("\\")+1);
//                Document document = new Document();

//                //System.out.println("Indexando el archivo: " + file.getAbsolutePath());							
//                //System.out.println("User dir: " + executionPath);
				
//                Resources.logEvent("Indexando el archivo: " + file.getAbsolutePath());
//                //contador++;
			
//                ////////////////////////////////////////////////////////////////////////
//                //Elimina los archivos anteriores
//                boolean exists1 = (new File(tmpPath + "\\imgtemp.tif")).exists();
//                boolean success1 = true;
//                if (exists1)				
//                    success1 = (new File(tmpPath + "\\imgtemp.tif")).delete();
				
//                boolean exists2 = (new File(tmpPath + "\\imgtemp.txt")).exists();
//                boolean success2 = true;
//                if (exists2)				
//                    success2 = (new File(tmpPath + "\\imgtemp.txt")).delete();
								
//                if ((success1) && (success2)) 
//                {
//                    //////////////////////////////////////////////////////////////////////
//                    // Elimino Ok archivos
//                    //Primeramente convierte el archivo de TIFF (prob. con compresion) a TIFF sin compresion (que es lo que espera el OCR Tesseract)
//                    //OJO, ESTO POR AHORA FUNCIONA PARA UNA PAGINA... VER BIEN COMO HACER PARA MULTIPAGINA (VER AQUI)
//                    try 
//                    { 
//                         // get runtime environment and execute child process 
//                         Runtime systemShell = Runtime.getRuntime(); 
//                         Process output = systemShell.exec(executionPath + "\\utils\\convert \"" + file.getAbsolutePath() + "\" -compress none \"" + tmpPath + "\\imgtemp.tif\" ");			     
//                         //Process output = systemShell.exec(executionPath + "\\utils\\convert \"" + file.getAbsolutePath() + "\" -compress none \"" + tmpPath + "\\imgtemp" + contador + ".tif\" ");					     
//                         // get process exit value
//                         //int exitVal = output.waitFor();
//                         int exitVal = doWaitFor(output);
					     
//                         //System.out.println("Process Exit Value : "+ exitVal);
//                         Resources.logEvent("Process Exit Value : "+ exitVal);
//                    } 
//                    catch (IOException ioe)
//                    { 
//                        //System.err.println(ioe);
//                        Resources.logError(ioe, null);
//                    }

//                    ///////////////////////////////////////////////////////////////////
//                    //Chequea si pudo crear el nuevo archivo TIF
//                    exists1 = (new File(tmpPath + "\\imgtemp.tif")).exists();
//                    //boolean exists1 = (new File(tmpPath + "\\imgtemp" + contador + ".tif")).exists();
//                    if (exists1)
//                    {					
//                        /////////////////////////////////////////////////////////////////////
//                        //Segunda realiza el ocr sobre el tif generado
//                        try 
//                        { 
//                             // get runtime environment and execute child process 
//                             Runtime systemShell = Runtime.getRuntime(); 
//                             //NOTA POR AHORA EN ESPAÑOL, VER COMO CONFIGURAR EL OCR (VER AQUI)						     
//                             //ATENCION SE ENCONTRO UN BUG CON IMAGENES COMO Comprobante de Pago.tif CUANDO SE HACE -l spa, POR ELLO SE SACO EL ENVIO DE ESTA PARAMETRO PARA TIF (VER AQUI)
//                             //Process output = systemShell.exec(executionPath + "\\utils\\tesseract \"" + tmpPath + "\\imgtemp.tif\" \"" + tmpPath + "\\imgtemp\""); //-l spa"); //no se coloca la extension .txt porque tesseract lo hace por defecto
//                             Process 	output = systemShell.exec(executionPath+"\\Tesseract-OCR\\tesseract \"" + tempPath+"\\imgtemp.tif\" \"" + tempPath+"\\imgtemp\" -l spa");
//                             //Process output = systemShell.exec(executionPath + "\\utils\\tesseract " + tmpPath + "\\imgtemp" + contador + ".tif " + tmpPath + "\\imgtemp" + contador + " -l spa"); //no se coloca la extension .txt porque tesseract lo hace por defecto						     
	
//                             // get process exit value
//                             //int exitVal = output.waitFor();
//                             int exitVal = doWaitFor(output);
	
//                             //System.out.println("Process Exit Value : "+ exitVal);
//                             Resources.logEvent("Process Exit Value : "+ exitVal);
//                        } 
//                        catch (IOException ioe)
//                        {
//                            // TODO Auto-generated catch block
//                            //System.err.println(ioe);
//                            Resources.logError(ioe, null);
//                        }
						
//                        ///////////////////////////////////////////////////////////////////
//                        //Chequea si pudo crear el nuevo archivo TXT
//                        exists2 = (new File(tmpPath + "\\imgtemp.txt")).exists();
//                        //boolean exists2 = (new File(tmpPath + "\\imgtemp" + contador +".txt")).exists();						
//                        if (exists2)
//                        {
//                            //Obtiene el archivo de texto generado				
//                            byte[] buffer = new byte[(int) new File(tmpPath + "\\imgtemp.txt").length()];
//                            //byte[] buffer = new byte[(int) new File(tmpPath + "\\imgtemp" + contador + ".txt").length()];							
//                            BufferedInputStream f = new BufferedInputStream(new FileInputStream(tmpPath + "\\imgtemp.txt"));
//                            //BufferedInputStream f = new BufferedInputStream(new FileInputStream(tmpPath + "\\imgtemp" + contador + ".txt"));
//                            f.read(buffer);
//                            string textTIF= new string(buffer);
		
//                            //Saca caracteres no texto
//                            for(int i= 0; i< textTIF.length(); i++) 
//                            {
//                                char x = textTIF.charAt(i); 
											
//                                //Si no lo encuentra en ninguna de las cadenas de control...
//                                if (TEXTO_LET.indexOf(x)== -1)
//                                    if (TEXTO_NUM.indexOf(x)== -1)
//                                        if (TEXTO_SYM.indexOf(x)== -1)		
//                                            textTIF= textTIF.replace(x, ' ');
//                            }  	
//                            textTIF += " "+  nameFile;

//                            f.close();
		
//                            //Guardo el texto del TIF en un stringReader para pasarlo al Field del Document
//                            stringReader finalTIFText = new stringReader(textTIF);
//                            document.add(new Field(CONTENT, finalTIFText));			    
//                            document.add(new Field(PATH, file.getPath(), Field.Store.YES, Field.Index.NO));
//                            document.add(new Field(NAME, file.getName(), Field.Store.YES, Field.Index.ANALYZED));
							
//                            flag = true;			   
						    
//                            writer.addDocument(document);
//                            writer.commit();
//                        }
//                        else
//                        {
//                            //System.err.println("Sucedio un error al tratar de hacer OCR");
//                            Resources.logEvent("Sucedio un error al tratar de hacer OCR");
//                        }
//                    }
//                    else
//                    {
//                        //System.err.println("Sucedio un error al tratar de crear el archivo tif sin compresion - para ocr -");
//                        Resources.logEvent("Sucedio un error al tratar de crear el archivo tif sin compresion - para ocr -");
//                    }
//                }
//                else
//                {
//                    //System.err.println("Sucedio un error al tratar de eliminar los archivos temporales");
//                    Resources.logEvent("Sucedio un error al tratar de eliminar los archivos temporales");
//                }				
//            }
//        }
//        if (!flag)
//            Resources.logEvent("**No hay archivos TIF");
//            //System.out.println("**No hay archivos TIF");
//        }
//        catch (Exception e)
//        {
//            // TODO Auto-generated catch block
//            //e.printStackTrace();
//            Resources.logError(e, null);
//        }
//    }
	

	
//    public static int doWaitFor(Process p) {

//        int cont= 1;
		
//          int exitValue = -1;  // returned to caller when p is finished

//          try {

//             InputStream in  = p.getInputStream();
//             InputStream err = p.getErrorStream();

//             boolean finished = false; // Set to true when p is finished

//             while( !finished) {
	        	
//                 //System.out.print("Contador Ejecucion " + cont); 
//                 cont++;
//                 if (cont> 500)
//                 {
//                     Resources.logEvent("Demasiado tiempo en tratar de procesar. Exit.");
//                     return -1;
//                 }
	        	 
//                try {

//                   while( in.available() > 0) {

//                      // Print the output of our system call
//                      Character c = new Character( (char) in.read());
//                      //System.out.print(c);
//                   }

//                   while( err.available() > 0) {

//                      // Print the output of our system call
//                      Character c = new Character( (char) err.read());
//                      //System.out.print(c);
//                   }

//                   // Ask the process for its exitValue. If the process
//                   // is not finished, an IllegalThreadStateException
//                   // is thrown. If it is finished, we fall through and
//                   // the variable finished is set to true.

//                   exitValue = p.exitValue();
//                   finished  = true;

//                } 
//                   catch (IllegalThreadStateException e) {

//                      // Process is not finished yet;
//                      // Sleep a little to save on CPU cycles
//                      Thread.currentThread().sleep(500);
//                   }
//             }


//          } 
//             catch (Exception e) {

//                // unexpected exception!  print it out for debugging...
//                //System.err.println( "doWaitFor(): unexpected exception - " + e.getMessage());
//                 Resources.logError(e, "doWaitFor(): unexpected exception");
//             }

//          // return completion status to caller
//          return exitValue;
//    }

	
//    /**
//     * Genera una colección de objetos <code>File</code> a partir de una ubicación del FS.
//     * Se tendrán en cuenta todos los archivos soportados.
//     * El objeto generado contendrá los datos de la carpeta que se indexará, y luego será
//     * añadida al índice. Por medio de un ciclo, se crean objetos <code>Document</code> con 
//     * los datos del archivo que se encuentra en proceso, que luego se agregan al índice.
//     * El ciclo finaliza cuando no queden más archivos que indexar.
//     * 
//     * @param fileDocument la ruta de la carpeta que se desea indexar
//     * @param writer el índice al que se agregarán los objetos <code>Document</code>
//     * 
//     * @throws Exception la excepcion
//     * 
//     */
//    private void generateDocumentFromFSAll(File fileDocument, IndexWriter writer) throws Exception
//    {
//        generateDocumentFromFSdotDOC(fileDocument, writer);
//        generateDocumentFromFSdotPDF(fileDocument, writer);
//        generateDocumentFromFSdotPPT(fileDocument, writer);
//        generateDocumentFromFSdotTXT(fileDocument, writer);
//        generateDocumentFromFSdotXLS(fileDocument, writer);
//        generateDocumentFromFSdotHTM(fileDocument, writer);
//        generateDocumentFromFSdotJPG(fileDocument, writer);
//        generateDocumentFromFSdotBMP(fileDocument, writer);
//        generateDocumentFromFSdotTIF(fileDocument, writer);
//    }
	
//}

/**
 * La clase <code>htmlParser</code> define los métodos que manejarán a los objetos 
 * <code>HTML</code> para ser parseados (por ahora, luego se implementara algo mas complejo).
 * 
 * @author Omar Rivas
 * @version 2.0
 * 
 */
//class htmlParser extends HTMLEditorKit.ParserCallback 
//{

//  stringBuffer txt;
//  Reader reader;

//  // empty default constructor
//  public htmlParser() {}

//  // more convienient constructor
//  public htmlParser(Reader r) {
//    setReader(r);
//  }

//  public void setReader(Reader r) { reader = r; }

//  public void parse() throws IOException {
//    txt = new stringBuffer();
//    ParserDelegator parserDelegator = new ParserDelegator();
//    parserDelegator.parse(reader, this, true);
//  }

//  public void handleText(char[] text, int pos) {
//    txt.append(text);
//  }

//  public string tostring() {
//    return txt.tostring();
//  }     
}
}