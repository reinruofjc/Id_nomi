using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Id_nomi
{
    public class Messages
    {
        public static string CREDITS { get => "Hecho por: Lluís Cobos Aumatell."; }
        public static string VERSION { get => "Versión: 1.0.2;"; }
        
        public static string WELCOME_MESS { get => "Bienvenid@ al programa custom para unir las posiciones de los json en un simple CSV."; }
        public static string PATH_ADD_MESS { get => "Escribe la ruta completa de la carpeta donde están los archivos Json:"; }
        public static string PATH_NO_EXIST_MESS { get => "La ruta seleccionada no existe."; }

        public static string PATH_SAVE_MESS { get => "Escribe SOLO la ruta donde guardar el archivo CSV"; }
        public static string PATH_CREATE_MESS { get => "La carpeta no existe. ¿Quiere crearla?"; }

        public static string READING_MESS { get => "Leyendo archivo: "; }
        public static string READING_DONE_MESS { get => "\tLeido archivo: "; }

        public static string FILENAME_ADD { get => "Escribe el nombre del archivo CSV SIN EXTENSION: "; }

        public static string FILENAME_EXISTS { get => "El archivo ya existe. ¿Desea sobreescribirlo?"; }

        public static string YES_NO_FORMAT { get => "   Sí({0})--No({1})"; }

        public static string PATH_NOT_CREATE { get => "Has decidido no crear la carpeta. Volviendo.\n"; }

        public static string FILES_NOT_FOUN { get => "No se han encontrado archivos compatibles. \nCerrando el programa."; }

        public static string PATH_SELECTED { get => "La ruta selecciona es: {0}"; }
        public static string FILE_SELECTED { get => "El nombre del archivo es: {0}"; }

        public static string FILE_GENERATING { get => "Generando archivo en: {0}{1}{2}"; }
        public static string FILE_GENERATE { get => @"Archivo creado con éxito \(^u^)/"; }
        public static string FILE_GENERATE_NOT { get => @"Ha habido un error y el archivo no se ha creado."; }
        public static string GOODBYE { get => "\n¡Gracias por usar el programa! ¡Que tengas un buen día! *\\(ºuº*\\)"; }
        public static string END { get => "\n\nPresiona cualquier tecla para salir."; }
    }
}
