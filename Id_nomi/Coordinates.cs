﻿using System;
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

        /// <summary>
        /// Método que devuelve un string sólo con las coordenadas
        /// </summary>
        /// <param name="message">string completo del archivo</param>
        /// <returns>String con coordenadas</returns>
        public string GetCoordenates(in string message)
        {
            StringBuilder coordenates = new StringBuilder();

            //leemos línea por línea del archivo
            StringReader reader = new StringReader(message);
            string temp = reader.ReadLine();

            //si hay líneas, hay posibilidades de pillar lo que nos interesa
            while (temp != null)
            {
                //si la línea contiene lo que nos interesa, pillamos las coordenadas
                if (temp.Contains(FIELD_NAME))
                {
                    SeparateCoordenates(ref temp);
                    coordenates.Append(temp);
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
        private void SeparateCoordenates(ref string rawCoordenates)
        {
            string temp = "";
            char currentChar;
            for (int i = 0; i < rawCoordenates.Length; i++)
            {
                currentChar = rawCoordenates[i];
                //Console.WriteLine(currentChar);

                //si no es algo de esto miraremos que nosea el último
                if (IsCharDigit(currentChar) || currentChar == DECIMAL_CHAR)
                {
                    temp = String.Concat(temp,currentChar);
                }
                else if(currentChar == SEPARATION_CHAR)
                {
                    temp = String.Concat(temp,DELIMITATION_CHAR);
                }
                else if (currentChar == END_CHAR)
                {
                    //si acabamos, metemos ; y nos vamos
                    temp = String.Concat(temp,DELIMITATION_CHAR);
                    break;
                }
            }

            //vamos juntando
            rawCoordenates = String.Concat(temp);
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

    }
}