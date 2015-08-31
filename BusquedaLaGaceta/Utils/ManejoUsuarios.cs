using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaLaGaceta.Utils
{
    public class ManejoUsuarios
    {
        private AIEntities db = new AIEntities();
        public ManejoUsuarios()
        {

        }
        public List<Table_Perfiles> listaPerfiles()
        {
            var resultados= db.Table_Perfiles.ToList();
            return resultados;
        }
        public bool AgregarUsuario(string userName, string userPassword)
        {
            var table_User = new Table_User();
            table_User.User_Name = userName;
            table_User.User_Password = userPassword;
            var resultado =
                db.Table_User.Add(table_User);
            return true;            
        }
    }
}
