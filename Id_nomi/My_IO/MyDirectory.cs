using System.IO;
using System;

namespace Id_nomi.My_IO
{
    public class MyDirectory
    {
        public static bool CheckDirectory(in string path)
        {
            return Directory.Exists(path);
        }

        public static bool CheckFileExist(in string path)
        {
            return File.Exists(path);
        }

        public static string[] GetFiles(in string path)
        {
            string[] files;
            try
            {
                files = Directory.GetFiles(path, "*.json", SearchOption.TopDirectoryOnly);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                files = null;
            }
            return files;
        }

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
