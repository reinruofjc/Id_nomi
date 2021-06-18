using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Id_nomi.My_IO
{
    /// <summary>
    /// Clase que pilla las coordenadas de posición de un json
    /// <remarks>
    /// OJU! el json tiene que tener una estructura especifica:
    /// "position":[coord_x, coord_y, coord_z]
    /// teoricamente debería funcionar en cualquier documento con el atributo "position"
    /// </remarks>
    /// </summary>
    public class Coordinates
    {
        /// <summary>
        /// el nombre del campo que nos interesa
        /// </summary>
        private string FIELD_NAME = "position";

        /// <summary>
        /// el final de línea, a cambiar en caso de otro final
        /// </summary>
        private char END_CHAR = ']';

        private char START_CHAR = '[';

        /// <summary>
        /// caracter para delimitar las coordenadas, como el excel pilla mal las comas y puntos, cada coordenada está delimitada por esto
        /// </summary>
        private char DELIMITATION_CHAR = ';';

        /// <summary>
        /// caracter de separación. En un principio las coordenadas de un mismo punto tenían este caractar, cada punto estaba separado por <see cref="DELIMITATION_CHAR"/>
        /// </summary>
        private char SEPARATION_CHAR = ',';

        /// <summary>
        /// character decimal.
        /// </summary>
        private char DECIMAL_CHAR = '.';

        /// <summary>
        /// Límite de puntos
        /// <remarks>
        /// El programa está escrito para archivos con 16 id's. En caso de que puedan ser variables
        /// habría que cambiar parte de la operatividad del programa o bien preguntando cuantos id's hay o 
        /// bien haciendo un bucle de conteo.
        /// </remarks>
        /// </summary>
        private byte ID_LIMIT = 16;

        /// <summary>
        /// Id con la que empezamos
        /// </summary>
        private byte ID_START = 1;

        /// <summary>
        /// Texto para el header.
        /// </summary>
        private string ID_TEXT = "LD";

        /// <summary>
        /// Texto para el header del campo de archivo
        /// </summary>
        private string HEADER_TEXT = "Filename";

        /// <summary>
        /// Array con chars de dimension, para escribir bien el header
        /// </summary>
        private char[] DIMENSIONS = { 'X','Y','Z'};

        private char NEGATIVE_CHAR = '-';

        /// <summary>
        /// Método que devuelve un string sólo con las coordenadas
        /// </summary>
        /// <param name="message">string completo del archivo</param>
        /// <returns>String con coordenadas</returns>
        public string GetCoordenates(in string message, out int numberCoord)
        {
            StringBuilder coordenates = new StringBuilder();
            numberCoord = 0;
            //leemos línea por línea del archivo
            StringReader reader = new StringReader(message);
            string temp = reader.ReadLine();
            string separated = "";
            //si hay líneas, hay posibilidades de pillar lo que nos interesa
            while (temp != null)
            {
                //si la línea contiene lo que nos interesa, pillamos las coordenadas
                if (temp.Contains(FIELD_NAME))
                {
                    if(SeparateCoordenates(temp, out separated))
                    {
                        coordenates.Append(separated);
                        numberCoord++;
                    }                    
                }

                //leemos siguiente línea
                temp = reader.ReadLine();
            }

            //ale, todo hecho, para casa!
            return coordenates.ToString();
        }

        /// <summary>
        /// Método que separa las coordenadas de una cadena de texto tipo:
        /// "position":[coord_x, coord_y, coord_z]
        /// </summary>
        /// <param name="rawCoordenates">Línera raw de texto</param>
        private bool SeparateCoordenates(in string rawCoordenates, out string separatedCoordenates)
        {
            separatedCoordenates = "";
            char currentChar;
            //clonamos el rawcoordenates, para operar con esto
            //TODO: quizás devolver string o algo así 
            string operation = (string)rawCoordenates.Clone();

            //lo haremos de otra forma ahora, como los datos están entre [x,y,z],grabaremos cuando pillamos el primer [ y acaberomos con el último
            for (int i = 0; i < operation.Length; i++)
            {
                currentChar = operation[i];

                //si hemos pillado el start char, copiamos hasta llegar al final!
                if(currentChar == START_CHAR)
                {
                    //metemos el avance en una acción
                    //TODO: no sé si la gramática tá bien jejeje
                    Action advance = () => { i++; currentChar = operation[i]; };
                    advance();

                    while(currentChar != END_CHAR)
                    {
                        if (currentChar == SEPARATION_CHAR)
                            currentChar = DELIMITATION_CHAR;
                           
                        separatedCoordenates = String.Concat(separatedCoordenates, currentChar);
                        advance();                     
                    }
                    //metemos delimitador
                    //OJU! no te olvides, que es propenso a bug
                    separatedCoordenates = String.Concat(separatedCoordenates, DELIMITATION_CHAR);
                    return true;
                }
            }

            //si llegamos aquí significa que hemos pillado algo que no es            
            return false;
        }

        /// <summary>
        /// comprueba si un caracter es un digito
        /// </summary>
        /// <param name="rawchar">caracter a comprobar</param>
        /// <returns>Es el caracter un número?</returns>
        private bool IsCharDigit(in char rawchar)
        {
            return (rawchar >= '0' && rawchar <= '9');
        }

        /// <summary>
        /// Crea el header con las id-s
        /// </summary>
        /// <returns>string con el header</returns>
        [Obsolete("Usar el que tiene argumento")]
        public string CreateHeader()
        {
            string header = String.Concat(HEADER_TEXT, ";");

            for (int i = ID_START; i <= ID_LIMIT; i++)
            {

                for (int j = 0; j < DIMENSIONS.Length; j++)
                {
                    header += String.Concat(ID_TEXT, i, '_', DIMENSIONS[j], DELIMITATION_CHAR);
                }
                
            }
            header += "\n";
            return header;
        }

        /// <summary>
        /// Crea el header con las id-s
        /// </summary>
        /// <returns>string con el header</returns>
        public string CreateHeader(in int numberCoord)
        {
            string header = String.Concat(HEADER_TEXT, DELIMITATION_CHAR);

            for (int i = ID_START; i <= numberCoord; i++)
            {
                for (int j = 0; j < DIMENSIONS.Length; j++)
                {
                    header += String.Concat(ID_TEXT, i, '_', DIMENSIONS[j], DELIMITATION_CHAR);
                }
                
            }

            header += "\n";
            return header;
        }
    }
}
