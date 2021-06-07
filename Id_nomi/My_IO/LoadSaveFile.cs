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
        /// <summary>
        /// lee el json.
        /// TODO: Estaría bien que pillase el header o algo así para saber que este archivo es el que queremos
        /// </summary>
        /// <param name="path">ruta del archivo</param>
        /// <returns>una string con todo el contenido</returns>
        public static string ReadJSon(in string path)
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

        /// <summary>
        /// guarda una string en un archivo csv.
        /// OJU! La extensión la pasamos´en el propio argumento "fileName"; así que esto se puede utilizar
        /// realmente para grabar cualquier archivo de texto.
        /// </summary>
        /// <param name="contents">Contenido a grabar</param>
        /// <param name="path">Ruta archivo</param>
        /// <param name="fileName">Nomre archivo</param>
        /// <returns>se ha grabado?</returns>
        public static bool SaveIntoCSV(in string contents, in string path, in string fileName)
        {
            try
            {
                File.WriteAllText(String.Concat(path, "\\", fileName), contents);
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
