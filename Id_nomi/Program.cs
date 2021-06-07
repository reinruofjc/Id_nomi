using System;
using System.Text;
using Id_nomi.My_IO;

namespace Id_nomi
{
    class Program
    {
        public static string FILE_SAVE_EXTENSION = ".cvs";
        
        
        /// <summary>
        /// proggrama
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Console.WriteLine(Messages.CREDITS);
            Console.WriteLine(Messages.VERSION);
            Console.WriteLine("\n");

            Console.WriteLine(Messages.WELCOME_MESS);
            string userPath;

            Input input = new Input();

            //preguntamos por el directorio
            userPath = input.GetPathFromInput(false, Messages.PATH_ADD_MESS);

            //primero pillamos el archivo
            string[] files = MyDirectory.GetFiles(userPath);

            //si no hay archivos json, malament rai, acabamos programa
            if(files.Length == 0)
            {
                Console.WriteLine(Messages.FILES_NOT_FOUN);
                Console.WriteLine(Messages.END);
                Console.ReadKey();
                return;
            }

            //metemos los string builders
            StringBuilder coordinates = new StringBuilder();
            StringBuilder rawJSon = new StringBuilder();

            //creamos coordinates
            Coordinates coord = new Coordinates();

            //creamos el header
            coordinates.Append(coord.CreateHeader());
            

            //por cada archivo metemos los valores
            foreach(string s in files)
            {
                //mostramos nombre del archivo que se lee
                Console.WriteLine(Messages.READING_MESS + s);
                
                rawJSon.Clear();

                //metemos coordenadas
                rawJSon.Append(LoadSaveFile.ReadJSon(s));
                coordinates.Append(String.Concat(MyDirectory.GetFileName(s), ';', coord.GetCoordenates(rawJSon.ToString()), "\n"));
                Console.WriteLine(Messages.READING_DONE_MESS + s);
            }

            //cadena en blanco para, bueno, separar un poco
            Console.WriteLine();
            

            //pillamos el path del nuevo archio
            userPath = input.GetPathFromInput(true, Messages.PATH_SAVE_MESS);

            Console.WriteLine(String.Format(Messages.PATH_SELECTED, userPath));

            //ahora vendría el filename
            string filename = input.GetFilename(userPath);

            //TODO: Esto hay que cambgiarlo

            Console.WriteLine(String.Format(Messages.FILE_SELECTED, filename, FILE_SAVE_EXTENSION));

            Console.WriteLine(String.Format(Messages.FILE_GENERATING, userPath, filename, FILE_SAVE_EXTENSION));

            //metemos unos puntos para separar y demás.
            //si vemos que el archivo tarda mucho, el save lo haremos async
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("\t..........");
            }

            if(LoadSaveFile.SaveIntoCSV(coordinates.ToString(), userPath, String.Concat(filename, FILE_SAVE_EXTENSION)))
            {
                Console.WriteLine(Messages.FILE_GENERATE);
            }
            else
            {
                Console.WriteLine(Messages.FILE_GENERATE_NOT);
            }

            Console.WriteLine(Messages.GOODBYE);
            Console.WriteLine(Messages.END);
            Console.ReadKey();
        }
       
    }
}
