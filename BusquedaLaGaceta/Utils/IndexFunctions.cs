using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusquedaLaGaceta.Properties;
using Lucene.Net.Index;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Store;
using Directory = Lucene.Net.Store.Directory;


namespace BusquedaLaGaceta.Utils
{
    class IndexFunctions
    {
        private AIEntities db = new AIEntities();
	    //Table_StopWordFunctions tableStopWordFunctions;
	    DocumentFunctions documentFunctions;
	    private IndexWriter writer { get; set; }
        private static string indexPath { get; set; }
			
	/**
	 * Constructor.
	 */
	public IndexFunctions()
	{ 				
		documentFunctions = new DocumentFunctions();
		
		//this.setIndexPath(AUTOINDEXING_PROPERTIES.getString("IndexPath"));
		//INDEX_PATH = AUTOINDEXING_PROPERTIES.getString("indexPath");
	}
	
	public IndexFunctions(String mode)
	{
	
	}
	
	/**
	 * Crea un nuevo índice.
	 * 
	 * @return el objeto <code>IndexWriter</code> con el nuevo índice generado.
	 * 
	 * @throws IOException Signals that an I/O exception has occurred.
	 */
	public IndexWriter createIndex() 
	{	 
		try
		{              
			writer = new IndexWriter(getDirectory(indexPath), getAnalyzer(true));
			//System.out.println("ADNRES getDirectory(this.getIndexPath())  "+getDirectory(this.getIndexPath()));
			//setWriter(new IndexWriter(getDirectory(INDEX_PATH), getAnalyzer(true), IndexWriter.MaxFieldLength.UNLIMITED));
		}
		catch (Exception e)
		{		
		}

		return writer;
	}
	
	/**
	 * Cierra un índice.
	 */
	public void closeIndex()
	{
		try
		{
			writer.Close();
		}
		catch (CorruptIndexException e)
		{
			// TODO Auto-generated catch block
			//e.printStackTrace();
			//Resources.logError(e, null);
		}
		catch (IOException e)
		{
			// TODO Auto-generated catch block
			//e.printStackTrace();
			//Resources.logError(e, null);
		}
	}
	
	/**
	 * Obtiene un objeto del tipo <code>Directory</code> a partir de una ruta del sistema de archivos.
	 * 
	 * @param path la ruta
	 * 
	 * @return el objeto <code>Directory</code>
	 * 
	 * @throws Exception la excepción
	 */
	protected FSDirectory getDirectory(string path)
	{
	    return FSDirectory.GetDirectory(path);
	}
		
	/**
	 * Obtiene un analizador de acuerdo al valor del parámetro <code>type</code>: si es <code>true</code>
	 * devuelve un <code>MultiLanguageAnalyzer</code>, si es <code>false</code> devuelve un
	 * <code>StandardAnalyzer</code>.
	 * 
	 * @param type el tipo de analizador requerido
	 * 
	 * @return el objeto <code>Analyzer</code>
	 */
	public Analyzer getAnalyzer(bool tipo)
	{
		Analyzer analyzer;
		if (tipo)
		{
			analyzer =  getMultiLanguageAnalyzer();
			//System.out.println("Analizador cargado.");
			//Resources.logEvent("Analizador cargado.");
		}
		else
		{
			analyzer = getStandardAnalyzer();
			//System.out.println("Analizador cargado.");
		//	Resources.logEvent("Analizador cargado.");
		}
		
		return analyzer;
	}
	
	/**
	 * Obtiene el analizador, que se encarga del trabajo de <code>StopWords</code> y <code>Stemming</code>.
	 * La lista de <code>StopWords</code> la obtiene de la base de datos
	 * 
	 * @return el analizador
	 */	
	private Analyzer getStandardAnalyzer() 
	{
	    StandardAnalyzer standardAnalyzer;
	    string[] stopWordList = {};
	    stopWordList = db.Table_StopWord.Select(x => x.StopWord_Word).ToArray();
            //tableStopWordFunctions.getStopWordList();
	    standardAnalyzer = new StandardAnalyzer(stopWordList);
		
	    return standardAnalyzer;
	}
	
	/**
	 * Obtiene el analizador multilenguage, que se encarga del trabajo de <code>StopWords</code> 
	 * y <code>Stemming</code>.
	 * La lista de <code>StopWords</code> la obtiene de la base de datos
	 * 
	 * @return el analizador
	 */
	private Analyzer getMultiLanguageAnalyzer() 
	{
	    MultiLanguageAnalyzer multiLanguageAnalyzer;
	    String[] stopWordList = {};
	    
	   // stopWordList = tableStopWordFunctions.getStopWordList();
	    multiLanguageAnalyzer = new MultiLanguageAnalyzer(stopWordList);
		
	    return multiLanguageAnalyzer;
	}
	
	/**
	 * Indexa el contenido de la carpeta que se le pasa como parámetro, agregándo sus
	 * archivos al índice creado por <code>createIndex()</code>.
	 * 
	 * @param directoryToIndex la carpeta cuyos documents se desea indexar.
	 * 
	 * @throws IOException Signals that an I/O exception has occurred.
	 */
    //public void documentIndexer(File directoryToIndex, int fileType)
    //{	
    //    try
    //    {
    //        //System.out.println("documentIndexer::"+"directoryToIndex : "+directoryToIndex+" - fileType : "+fileType);
    //        documentFunctions.generateDocumentFromFS(directoryToIndex, getWriter(), fileType);
    //        writer.optimize();
    //        //writer.close();
    //    }
    //    catch (Exception e)
    //    {
    //        //e.printStackTrace();
    //        Resources.logError(e, null);
    //    }
    //    finally
    //    {
    //        //writer.close();
    //    }
    //}	

    }
}
