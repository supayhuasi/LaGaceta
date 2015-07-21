using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Analysis;
using SF.Snowball.Ext;

namespace BusquedaLaGaceta.Utils
{
    class SpanishStemFilter : TokenFilter
    {
        private SpanishStemmer stemmer;
	    private Token token = null;

	/**
	 * Constructor
	 * 
	 * @param in el <code>TokenStream</code> que se desea procesar
	 */
    //public SpanishStemFilter()
    //{	   
    //    //base(tokenStream)
    //    //;
    //    stemmer = new SpanishStemmer();
    //}
		
	public Token next() 
	{
        //if ((token = input.next()) == null) 
        //{
        //    return null;
        //}
        //else 
        //{
	    stemmer.SetCurrent(token.Term);
			stemmer.Stem();
	        string s = stemmer.GetCurrent();
			if ( !s.Equals(token.Term)) 
			{
				return new Token(s, token.StartOffset, token.EndOffset, token.Type);
			}
			return token;
	//	}
	}
	
	/**
	* Set a alternative/custom Stemmer for this filter.
	*/

        public SpanishStemFilter(TokenStream input) : base(input)
        {
            stemmer = new SpanishStemmer();
        }

        public override bool IncrementToken()
        {
            throw new NotImplementedException();
        }
    }
}
