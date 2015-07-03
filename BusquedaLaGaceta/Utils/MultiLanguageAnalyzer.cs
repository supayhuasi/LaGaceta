using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;

namespace BusquedaLaGaceta.Utils
{
    class MultiLanguageAnalyzer
    {
        private Hashtable stopTable
        {
            get;
            set
            {
                this.stopTable = new Hashtable();
            }
        } 

        /**
	 * Constructor. Genera una nueva intancia de <code>MultiLanguageAnalyzer</code>
	 */
	
	public MultiLanguageAnalyzer(String[] stopWords)
	{
		stopTable = StopFilter.MakeStopSet(stopWords);
	}
	
	
	public TokenStream tokenStream(string fieldName, TextReader reader)
	{
		TokenStream result = new StandardTokenizer(reader);
		result = new StandardFilter(result);
		result = new LowerCaseFilter(result);
		result = new StopFilter(result, stopTable);
		result = new SpanishStemFilter(result);
		
		return result;
	}
    }
}

