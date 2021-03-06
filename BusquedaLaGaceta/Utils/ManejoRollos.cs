﻿using System;
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
                db.Table_LuceneDBIndexAddress.Where(x => x.Date_From <= fechaDesde && x.Date_To >= fechaHasta);
            return resultado;            
        }        
        public string FilePath(string fileName)
        {
            //var nombreArchivo = fileName.IndexOf(".txt");
            //fileName = fileName.Remove(0, nombreArchivo);
            if (fileName.Contains(".JPG"))
            {
                var resultado =
                   db.Table_File_Names.Where(x => x.File_Name.Contains(fileName)).FirstOrDefault();
                if (resultado != null)
                    return resultado.Directory.Replace("O:\\", Properties.Resources.DiscoImagenes).TrimEnd() + "\\" + resultado.File_Rename.TrimEnd();
                else
                    return "imagen vacia";
            }
            else
            {
                var resultado =
                db.Table_File_Names.Where(x => x.File_Name.Contains(fileName + ".JPG")).FirstOrDefault();
                if (resultado != null)
                    return resultado.Directory.Replace("O:\\", Properties.Resources.DiscoImagenes).TrimEnd() + "\\" + resultado.File_Rename.TrimEnd();
                else
                    return "imagen vacia";
            }

        }
        public string nombreArchivoPagina(string fileName)
        {
            ////var nombreArchivo = fileName.IndexOf(".txt");
            //fileName = fileName.Replace(".txt", "");// Remove(nombreArchivo, fileName.Count());
            try
            {
                var resultado =
                    db.Table_File_Names.Where(x => x.File_Name.Contains(fileName)).FirstOrDefault();
                return resultado.File_Rename.TrimEnd();
            }
            catch (Exception ex)
            { return ""; }
        }
        public string FileRenamePath(string fileName)
        {                        
            var resultado =
                db.Table_File_Names.Where(x => x.File_Rename.Contains(fileName)).FirstOrDefault();
            return resultado.Directory.Replace("O:\\", Properties.Resources.DiscoImagenes).TrimEnd() + "\\" + resultado.File_Rename.TrimEnd();
        }
        public bool InsertFileNames(string directorio, string fileName, string fileRename)
        {
            try { 
            var file_names= new Table_File_Names();
            file_names.Directory= directorio;
            file_names.File_Name= fileName;
            file_names.File_Rename= fileRename;
            db.Table_File_Names.Add(file_names);
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
