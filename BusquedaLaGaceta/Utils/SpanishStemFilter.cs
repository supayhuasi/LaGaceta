using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Analysis;
using SF.Snowball.Ext;

namespace BusquedaLaGaceta.Utils
{
    public class SpanishStemFilter : TokenFilter { 
     
    private SpanishStemmer stemmer; 
    private Token token = null; 
     
    public SpanishStemFilter(TokenStream inTokenStream) : base (inTokenStream) {     	
        
        stemmer = new SpanishStemmer(); 
    } 
     
    /** Returns the next input Token, after being stemmed */ 
    //public Token next() { 
        
    //    if ((token = Input) == null) { 
    //        return null; 
    //    } 
    //    else { 
    //        stemmer.SetCurrent(token.); 
    //        stemmer.Stem(); 
    //        String s = stemmer.GetCurrent();
    //        if ( !s.Equals(token.Term())) { 
    //            return new Token( s, token.startOffset(), 
    //            token.endOffset(), token.type() ); 
    //        } 
    //        return token; 
    //    } 
    //} 
     
    /** 
     * Set a alternative/custom Stemmer for this filter. 
     */ 
    public void setStemmer(SpanishStemmer stemmer) { 
        if ( stemmer != null ) { 
            this.stemmer = stemmer; 
        } 
    }

    public override bool IncrementToken()
    {
        if (!input.IncrementToken()) return false;
        return true;
    }
    }
}
