using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Id_nomi.My_IO
{
    /// <summary>
    /// Clase para cargar y guardar el archivo
    /// </summary>
    public class LoadSaveFile
    {      

        public static String ReadJSon(in string path)
        {
            string temp;

            try
            {
                temp = File.ReadAllText(path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                temp = null;
            }
            
            return temp;
        }

        
        public static bool SaveIntoCSV(in string contents, in string path, in string fileName)
        {
            try
            {
                File.WriteAllText(String.Concat(path, "\\", fileName, Program.FILE_SAVE_EXTENSION), contents);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }       
    }
}
