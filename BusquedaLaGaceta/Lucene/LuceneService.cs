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

namespace SimpleLuceneSearch
{
    public interface ILuceneService
    {
        void BuildIndex(IEnumerable<SampleDataFileRow> dataToIndex);
        IEnumerable<SampleDataFileRow> Search(string searchTerm);
    }

    public class LuceneService : ILuceneService
    {
        // Note there are many different types of Analyzer that may be used with Lucene, the exact one you use
        // will depend on your requirements
        private Analyzer analyzer = new WhitespaceAnalyzer(); 
        private Directory luceneIndexDirectory;
        private IndexWriter writer;
        //Lucene.Net.Index.ind indexFunctions;
        private string indexPath = @"E:\Trabajo\Aplika\La Gaceta\db_lucene\R341-21-03-1970-26-04-1970";

        public LuceneService()
        {
            InitialiseLucene();
        }

        private void InitialiseLucene()
        {
            if(System.IO.Directory.Exists(indexPath))
            {
                System.IO.Directory.Delete(indexPath,true);
            }

            luceneIndexDirectory = FSDirectory.GetDirectory(indexPath);
            writer = new IndexWriter(luceneIndexDirectory, analyzer, true);
        }

        public void BuildIndex(IEnumerable<SampleDataFileRow> dataToIndex)
        {
            foreach (var sampleDataFileRow in dataToIndex)
	        {
		        Document doc = new Document();
                doc.Add(new Field("LineNumber", sampleDataFileRow.LineNumber.ToString() , Field.Store.YES, Field.Index.UN_TOKENIZED));
                doc.Add(new Field("LineText", sampleDataFileRow.LineText, Field.Store.YES, Field.Index.TOKENIZED));
                writer.AddDocument(doc);
	        }
            writer.Optimize();
            writer.Flush();
            writer.Close();
            luceneIndexDirectory.Close();
        }

        public IEnumerable<SampleDataFileRow> Search(string searchTerm)
        {
           
            
            ManagerDirectory mg = new ManagerDirectory();
		List<SearchResult> result =  new ArrayList<SearchResult>(); 
	    for(int h=0;h<dbLucenePath.length;h++){
	    	//INDEX_PATH=dbLucenePath[h];
		    System.out.println("\n\n\nINDEX_PATH::"+INDEX_PATH+"\n\n\n");
		// result = new ArrayList<SearchResult>();
		Searcher searcher = new IndexSearcher(IndexReader.open(INDEX_PATH));
		
		//QueryParser queryParser = new QueryParser(DocumentFunctions.CONTENT, new StandardAnalyzer());
		QueryParser queryParser = new QueryParser(DocumentFunctions.CONTENT, indexFunctions.getAnalyzer(true));
		Query query = queryParser.parse(keyWord);		
		ScoreDoc[] scoreDoc = searcher.search(query, 20).scoreDocs;
		String pathTemp;
            
            
            
            
            
            
            
            
            
            IndexSearcher searcher = new IndexSearcher(luceneIndexDirectory);
            QueryParser parser = new QueryParser(DocumentFunctions.CONTENT, analyzer);

            Query query = parser.Parse(searchTerm);
            Hits hitsFound = searcher.Search(query);
            List<SampleDataFileRow> results = new List<SampleDataFileRow>();
            SampleDataFileRow sampleDataFileRow = null;

            for (int i = 0; i < hitsFound.Length(); i++)
            {
                sampleDataFileRow = new SampleDataFileRow();
                Document doc = hitsFound.Doc(i);
                sampleDataFileRow.LineNumber = int.Parse(doc.Get("LineNumber"));
                sampleDataFileRow.LineText = doc.Get("LineText");
                float score = hitsFound.Score(i);
                sampleDataFileRow.Score = score;

                results.Add(sampleDataFileRow);
            }
           
            return results.OrderByDescending(x => x.Score).ToList();
        }
    }
}
