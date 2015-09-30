using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusquedaLaGaceta.Utils;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Version = Lucene.Net.Util.Version;

namespace SimpleLuceneSearch
{
	public interface ILuceneService
	{
		void BuildIndex(IEnumerable<SampleDataFileRow> dataToIndex);
		List<SearchResult> Search(string searchTerm, DateTime fechaDesde, DateTime fechaHasta, bool bDiario);
	}

	public class LuceneService : ILuceneService
	{
		// Note there are many different types of Analyzer that may be used with Lucene, the exact one you use
		// will depend on your requirements
	   // private Analyzer analyzer = new WhitespaceAnalyzer(); 
		private ManejoRollos rollos { get; set; }
		private Directory luceneIndexDirectory{ get; set; }
		private IndexWriter writer{ get; set; }
		private IndexFunctions IndexFunctions { get; set; }
		System.Resources.ResourceManager RM = new System.Resources.ResourceManager("Resources", System.Reflection.Assembly.GetExecutingAssembly());        
		//Lucene.Net.Index.ind indexFunctions;
		//private string indexPath = @"O:\Trabajo\Aplika\La Gaceta\db_lucene\R340-06-02-1970-20-03-1970";

		public LuceneService()
		{
			InitialiseLucene();
		}

		private void InitialiseLucene()
		{
			//if(System.IO.Directory.Exists(indexPath))
			//{
			//    System.IO.Directory.Delete(indexPath,true);
			//}

		
			IndexFunctions = new IndexFunctions();
			rollos = new ManejoRollos();            
		}

		public void BuildIndex(IEnumerable<SampleDataFileRow> dataToIndex)
		{
			foreach (var sampleDataFileRow in dataToIndex)
			{
				Document doc = new Document();
				//doc.Add(new Field("LineNumber", sampleDataFileRow.LineNumber.ToString() , Field.Store.YES, Field.Index.UN_TOKENIZED));
				//doc.Add(new Field("LineText", sampleDataFileRow.LineText, Field.Store.YES, Field.Index.TOKENIZED));
				writer.AddDocument(doc);
			}
			writer.Optimize();
			//writer.Flush();
			//writer.Close();
			luceneIndexDirectory.Dispose();
		}

		public List<SearchResult> Search(string searchTerm, DateTime fechaDesde, DateTime fechaHasta, bool bDiario)
		{
		   
			
			ManagerDirectory mg = new ManagerDirectory();
		List<SearchResult> result =  new List<SearchResult>();
		var paths = rollos.DbPath(fechaDesde, fechaHasta);
			foreach (var path in paths)
			{
				
				string pathAplicacion = BusquedaLaGaceta.Properties.Resources.IndexPath;
				var indexPath = pathAplicacion + path.DB_Path.Replace("O:\\db_lucene\\", "");
				
				
		luceneIndexDirectory = FSDirectory.Open(indexPath);

		Searcher searcher = new IndexSearcher(luceneIndexDirectory);
		Analyzer analyzer = new StandardAnalyzer(Version.LUCENE_24);
		//QueryParser queryParser = new QueryParser(DocumentFunctions.CONTENT, new StandardAnalyzer());
		QueryParser queryParser = new QueryParser(Version.LUCENE_24, DocumentFunctions.CONTENT, analyzer);
		Query query = queryParser.Parse(searchTerm);
			var a = searcher.Search(query,20).ScoreDocs;            
			for (int i=0;i < a.Length ;i++)
			{
				var document = searcher.Doc(a[i].Doc);
				SearchResult searchResult = new SearchResult();
				searchResult.Name = document.GetField(DocumentFunctions.NAME).StringValue;
				searchResult.Path = rollos.FilePath(document.GetField(DocumentFunctions.PATH).StringValue);                
				result.Add(searchResult);
			}
			}
			return result;
		}
	}
}
