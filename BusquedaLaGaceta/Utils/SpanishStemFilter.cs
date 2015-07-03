using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Analysis;

namespace BusquedaLaGaceta.Utils
{
    class SpanishStemFilter
    {
        private SpanishStemmer stemmer;
	private Token token = null;

	/**
	 * Constructor
	 * 
	 * @param in el <code>TokenStream</code> que se desea procesar
	 */
	public SpanishStemFilter(TokenStream in) 
	{
		super(in);
		stemmer = new SpanishStemmer();
	}
	
	/** Returns the next input Token, after being stemmed */
	@SuppressWarnings("deprecation")
	public final Token next() throws IOException 
	{
		if ((token = input.next()) == null) 
		{
			return null;
		}
		else 
		{
			stemmer.setCurrent(token.termText());
			stemmer.stem();
			String s = stemmer.getCurrent();
			if ( !s.equals( token.termText() ) ) 
			{
				return new Token(s, token.startOffset(), token.endOffset(), token.type());
			}
			return token;
		}
	}
	
	/**
	* Set a alternative/custom Stemmer for this filter.
	*/
	public void setStemmer(SpanishStemmer stemmer) 
	{
		if ( stemmer != null ) 
		{
			this.stemmer = stemmer;
		}
	}
    }
}
