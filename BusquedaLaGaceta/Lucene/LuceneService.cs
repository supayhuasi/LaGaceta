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
		void BuildIndex(IEnumerable<SampleDataFileRow> dataToIndex, string txtLucene);
		List<SearchResult> Search(string searchTerm, DateTime fechaDesde, DateTime fechaHasta, bool bDiario);
	}

	public class LuceneService : ILuceneService
	{
		// Note there are many different types of Analyzer that may be used with Lucene, the exact one you use
		// will depend on your requirements
	    private Analyzer analyzer = new WhitespaceAnalyzer(); 
		private ManejoRollos rollos { get; set; }
		private Directory luceneIndexDirectory{ get; set; }
		private IndexWriter writer{ get; set; }
		private IndexFunctions IndexFunctions { get; set; }
		System.Resources.ResourceManager RM = new System.Resources.ResourceManager("Resources", System.Reflection.Assembly.GetExecutingAssembly());        
		//Lucene.Net.Index.ind indexFunctions;
        private string indexPath = @"E:\\db_lucene\\R555-16-12-1999-15-01-2000";

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

		public void BuildIndex(IEnumerable<SampleDataFileRow> dataToIndex, string txtDir)
		{
            luceneIndexDirectory = FSDirectory.Open(txtDir);
            writer = new IndexWriter(luceneIndexDirectory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED);
            foreach (var sampleDataFileRow in dataToIndex)
            {
                Document doc = new Document();
                doc.Add(new Field(DocumentFunctions.NAME, sampleDataFileRow.NAME, Field.Store.YES, Field.Index.NOT_ANALYZED));
                doc.Add(new Field(DocumentFunctions.CONTENT, sampleDataFileRow.CONTENT, Field.Store.YES, Field.Index.ANALYZED));
                doc.Add(new Field(DocumentFunctions.PATH, sampleDataFileRow.PATH, Field.Store.YES, Field.Index.ANALYZED));
                writer.AddDocument(doc);
            }
            writer.Optimize();
            //writer.Flush()
            writer.Dispose();
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
				var indexPath = pathAplicacion + path.DB_Path.Replace("E:\\db_lucene\\", "");
				
				
		luceneIndexDirectory = FSDirectory.Open(indexPath);

		Searcher searcher = new IndexSearcher(luceneIndexDirectory);
		//Analyzer analyzer = new StandardAnalyzer(Version.LUCENE_24);
				//SpanishStemFilter
		//QueryParser queryParser = new QueryParser(DocumentFunctions.CONTENT, new StandardAnalyzer());
		//SpanishAnalyzer analyzer = new SpanishAnalyzer();
				QueryParser queryParser = new QueryParser(Version.LUCENE_24, DocumentFunctions.CONTENT, analyzer);
		Query query = queryParser.Parse(searchTerm);
			var a = searcher.Search(query,30).ScoreDocs;            
			for (int i=0;i < a.Length ;i++)
			{
				var document = searcher.Doc(a[i].Doc);
				SearchResult searchResult = new SearchResult();
                searchResult.Name = document.GetField(DocumentFunctions.NAME).StringValue.Replace("\\", "").Replace(".txt","");
				
                //searchResult.Path = rollos.FilePath(document.GetField(DocumentFunctions.PATH).StringValue);
                searchResult.Path = document.GetField(DocumentFunctions.PATH).StringValue;
                var listImagenes = searchResult.Path.Substring(21).Split('\\');
                searchResult.RollNumber = listImagenes[0];
                var ima= result.Find(x=>x.Name.Equals(searchResult.Name));
                
                if (ima == null)
                    result.Add(searchResult);
                //else
                //    ima = ;
			}
			}
			return result;
		}
	}
}
