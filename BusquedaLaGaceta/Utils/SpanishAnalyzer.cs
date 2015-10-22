using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Version = Lucene.Net.Util.Version;

namespace BusquedaLaGaceta.Utils
{
    class SpanishAnalyzer : Analyzer { 
     
    /** An array containing some common Spanish words that are usually not 
     * useful for searching. Imported from http://www.unine.ch/info/clef/. 
     */ 
    // TODO: no pego en el tutorial el listado de stopWords utilizado para
    // no sobredimensionarlo, son 351 términos.
    public static  string[] SPANISH_STOP_WORDS = { "" };
    
    /**
     * Contains the stopwords used with the StopFilter.
     */
    private ISet<string> stopTable = new HashSet<string>();
    
    /**
     * Contains words that should be indexed but not stemmed.
     */
    private ISet<string> exclTable = new HashSet<string>();
    
    /**
     * Builds an analyzer with the default stop words.
     */
    public SpanishAnalyzer() {
        stopTable = StopFilter.MakeStopSet(SPANISH_STOP_WORDS);
    }
 
    /** Builds an analyzer with the given stop words. */
    public SpanishAnalyzer(String[] stopWords) {
        stopTable = StopFilter.MakeStopSet(stopWords);
    }
    
    /**
     * Builds an analyzer with the given stop words from file.
     * @throws IOException 
     */
    public SpanishAnalyzer(FileInfo stopWords) {
        stopTable = WordlistLoader.GetWordSet(stopWords);
    }
    
    /** Constructs a {@link StandardTokenizer} filtered by a {@link
     * StandardFilter}, a {@link LowerCaseFilter}, a {@link StopFilter}
     * and a {@link SpanishStemFilter}. */
    public override TokenStream TokenStream(string fieldName, TextReader reader)
    {
        TokenStream result = new StandardTokenizer(Version.LUCENE_24,reader);
        result = new StandardFilter(result);
        result = new LowerCaseFilter(result);
        result = new StopFilter(true,result, stopTable);
        result = new SpanishStemFilter(result);
        return result;
    }
    
    }
    }

