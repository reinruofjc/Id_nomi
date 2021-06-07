using System.IO;
using System;

namespace Id_nomi.My_IO
{
    /// <summary>
    /// Clase para trabajar con todo lo relacionado con directorios y archivos.
    /// <remarks>
    /// Creo que es mejor que esto tenga su propia clase. Realmente podríamos ponerlo donde lo necesitemos,
    /// aún así, me parece más ordenado.
    /// </remarks>
    /// </summary>
    public class MyDirectory
    {
        private static string FILETYPE_TO_SEARCH = "*.json";
        /// <summary>
        /// Comprueba si existe un directorio
        /// </summary>
        /// <param name="path">Ruta del directorio</param>
        /// <returns>Existe el directorio?</returns>
        public static bool CheckDirectory(in string path)
        {
            return Directory.Exists(path);
        }

        /// <summary>
        /// Comprueba si existe un archivo en un directorio
        /// </summary>
        /// <param name="path">Directorio + archivo</param>
        /// <returns>Existe el arvhivo?</returns>
        public static bool CheckFileExist(in string path)
        {
            return File.Exists(path);
        }

        /// <summary>
        /// Devuelve las rutas de los archivos de tipo <see cref="FILETYPE_TO_SEARCH"/>; null si no existe ninguno
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string[] GetFiles(in string path)
        {
            string[] files;
            try
            {
                files = Directory.GetFiles(path, FILETYPE_TO_SEARCH, SearchOption.TopDirectoryOnly);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                files = null;
            }
            return files;
        }

        /// <summary>
        /// Pilla el nombre del archivo sin extensión
        /// </summary>
        /// <param name="path">ruta completa archivo</param>
        /// <returns>nombre del archivo</returns>
        public static string GetFileName(in string path)
        {
            string fileName = Path.GetFileName(path);
            string finalName = "";

            for (int i = 0; i < fileName.Length; i++)
            {
                if (fileName[i] != '.')
                {
                    finalName += fileName[i];
                }
                else
                {
                    break;
                }
            }

            return finalName;
        }

        /// <summary>
        /// Intenta crear un directorio en la ruta seleccionada
        /// </summary>
        /// <param name="path">Ruta carpeta</param>
        /// <returns>Se ha creado el directorio?</returns>
        public static bool TryCreateDirectory(in string path)
        {
            try
            {
                Directory.CreateDirectory(path);
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }



    }
}
