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
        public Table_User buscarUsuario(int idUsuario)
        {
            var usuario = db.Table_User.Where(x => x.ID_User == idUsuario).FirstOrDefault();
                return usuario;
        }
        public bool AgregarUsuario(string userName, string userPassword, string userPasswordComprobar)
        {
            if (userPassword.Equals(userPasswordComprobar))
            {
                var table_User = new Table_User();
                table_User.User_Name = userName;
                table_User.User_Password = userPassword;
                var resultado =
                db.Table_User.Add(table_User);
                db.SaveChanges();
                return true;
            }
            else
                return false;
            
        }
        public bool ModificarUsuario(int idUsuario, string userName, string userPassword, string userPasswordComprobar)
        {
            if (userPassword.Equals(userPasswordComprobar))
            {
                var table_User = db.Table_User.Where(x => x.ID_User == idUsuario).FirstOrDefault();
                table_User.User_Name = userName;
                table_User.User_Password = userPassword;
                                
                db.Entry(table_User).State = System.Data.Entity.EntityState.Modified;                     
                db.SaveChanges();                
                return true;
            }
            else
                return false;

        }
        public bool EliminarUsuario(int idUser)
        {
            try { 
            var usuario = db.Table_User.Where(x=>x.ID_User==idUser).FirstOrDefault();
                //var resultado =
                db.Table_User.Remove(usuario);
                db.SaveChanges();
                return true;          
                }    
            catch(Exception ex)
            {
                return false;
            }

        }
    }
}
