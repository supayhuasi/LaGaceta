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
        void Search(string searchTerm, DateTime fechaDesde, DateTime fechaHasta, bool bDiario);
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
        private string indexPath = @"E:\Trabajo\Aplika\La Gaceta\db_lucene\R340-06-02-1970-20-03-1970";

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
            luceneIndexDirectory.Close();
        }

        public void Search(string searchTerm,DateTime fechaDesde,DateTime fechaHasta, bool bDiario)
        {
           
            
            ManagerDirectory mg = new ManagerDirectory();
		List<SearchResult> result =  new List<SearchResult>();

        luceneIndexDirectory = FSDirectory.Open(indexPath);

		Searcher searcher = new IndexSearcher(luceneIndexDirectory);
        Analyzer analyzer = new StandardAnalyzer(Version.LUCENE_24);
		//QueryParser queryParser = new QueryParser(DocumentFunctions.CONTENT, new StandardAnalyzer());
        QueryParser queryParser = new QueryParser(Version.LUCENE_24, DocumentFunctions.CONTENT, analyzer);
		Query query = queryParser.Parse(searchTerm);
            var a = searcher.Search(query,20).ScoreDocs;
            var pathTemp = rollos.DbPath(fechaDesde, fechaHasta);
            for (int i=0;i < a.Length ;i++)
            {
                var document = searcher.Doc(a[i].Doc);
			SearchResult searchResult = new SearchResult();
                searchResult.Name = document.GetField(DocumentFunctions.NAME).StringValue;
			    searchResult.Path = document.GetField(DocumentFunctions.PATH).StringValue;
            }        
           // IndexSearcher searcher = new IndexSearcher(luceneIndexDirectory);
            //QueryParser parser = new QueryParser(DocumentFunctions.CONTENT, analyzer);

            //Query query = parser.Parse(searchTerm);
            //Hits hitsFound = searcher.Search(query);
            //List<SampleDataFileRow> results = new List<SampleDataFileRow>();
            //SampleDataFileRow sampleDataFileRow = null;

            //for (int i = 0; i < hitsFound.Length(); i++)
            //{
            //    sampleDataFileRow = new SampleDataFileRow();
            //    Document doc = hitsFound.Doc(i);
            //    sampleDataFileRow.LineNumber = int.Parse(doc.Get("LineNumber"));
            //    sampleDataFileRow.LineText = doc.Get("LineText");
            //    float score = hitsFound.Score(i);
            //    sampleDataFileRow.Score = score;

            //    results.Add(sampleDataFileRow);
            //}
           
            //return results.OrderByDescending(x => x.Score).ToList();
        }
    }
}
