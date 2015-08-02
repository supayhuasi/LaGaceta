using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaLaGaceta.Seguridad
{
    public class SeguridadLogin
    {
        private AIEntities db = new AIEntities();
        public SeguridadLogin()
        {

        }
        public bool ValidarUsuario(string usuario,string clave)
        {
            var resultado = db.Table_User.Where(x => x.User_Name == usuario && x.User_Password == clave).FirstOrDefault();
            if (resultado != null)
                return true;
            else
                return false;
        }
    }
}
