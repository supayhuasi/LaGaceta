using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusquedaLaGaceta.Properties;

namespace BusquedaLaGaceta.Utils
{
    class Table_StopWordFunctions
    {
        Table_StopWordTransaction stopWordTransaction;

        /**
         * Constructor. Genera una instancia de <code>Table_StopWordFunctions</code>
         */
        public Table_StopWordFunctions()
        {
            stopWordTransaction = new Table_StopWordTransaction();
        }

        /**
         * Obtiene una lista de StopWords de un idioma determinado.
         * 
         * @return un vector con la lista de StopWords
         */
        public String[] getStopWordList()
        {
            String[] stopWordList = { };
            List<Table_StopWord> stopWords = null;

            try
            {
                stopWords = stopWordTransaction.queryAllRecords();
            }
            catch (Exception e)
            {
                //e.printStackTrace();
               // Resources.logError(e, null);
            }

            stopWordList = new String[stopWords.size()];

            for (int i = 0; i != stopWords.size(); i++)
            {
                stopWordList[i] = stopWords.get(i).getStopWord_Word();
            }

            return stopWordList;
        }

    }
}
