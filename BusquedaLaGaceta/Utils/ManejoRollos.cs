using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaLaGaceta.Utils
{
    public class ManejoRollos
    {
        private AIEntities db = new AIEntities();

        public ManejoRollos()
        {
            
        }

        public IQueryable<Table_LuceneDBIndexAddress> DbPath(DateTime fechaDesde,DateTime fechaHasta)
        {
            var resultado =
                db.Table_LuceneDBIndexAddress.Where(x => x.Date_From >= fechaDesde && x.Date_To <= fechaHasta);
            return resultado;            
        }
    }
}
