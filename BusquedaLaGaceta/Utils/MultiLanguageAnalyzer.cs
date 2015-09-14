using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Version = Lucene.Net.Util.Version;

namespace BusquedaLaGaceta.Utils
{
    class MultiLanguageAnalyzer : Analyzer
    {
        //private ISet<string> stopTable { get; set; }
                            

        /**
	 * Constructor. Genera una nueva intancia de <code>MultiLanguageAnalyzer</code>
	 */
	
	public MultiLanguageAnalyzer(string[] stopWords)
	{
		//stopTable = StopFilter.MakeStopSet(stopWords);
	}


    public override TokenStream TokenStream(string fieldName, TextReader reader)
	{
		TokenStream result = new StandardTokenizer(Version.LUCENE_20, reader);
		result = new StandardFilter(result);
		result = new LowerCaseFilter(result);
		//result = new StopFilter(false,result, stopTable);
		result = new SpanishStemFilter(result);
		
		return result;
	}

        
    }
}

