﻿using Id_nomi.My_IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Id_nomi
{
    public class Input
    {
        private static string ANSW_YES = "s";
        private static string ANSW_NO = "n";
        private static string OPERATOR = "-> ";
        public string GetPathFromInput(in bool createIfNotExist, in string message)
        {
            string inputPath = "";
            bool correctPath = false;

            do
            {
                Console.WriteLine(message);
                inputPath = GetInput();
                correctPath = MyDirectory.CheckDirectory(inputPath);

                if (createIfNotExist && correctPath == false)
                {
                    if (this.GetInputYesOrNo(String.Concat(Messages.PATH_CREATE_MESS, String.Format(Messages.YES_NO_FORMAT, ANSW_YES, ANSW_NO))))
                    {
                        correctPath = MyDirectory.TryCreateDirectory(inputPath);
                        correctPath = true;
                    }
                    else
                    {
                        Console.WriteLine(Messages.PATH_NOT_CREATE);
                    }                       
                   
                }
                else if(correctPath == false)
                {
                    Console.WriteLine(Messages.PATH_NO_EXIST_MESS);
                }


            } while (correctPath == false);

            return inputPath;
        }

        public bool GetInputYesOrNo(in string message)
        {
            string input;
            bool correctInput = false;
            do
            {
                Console.WriteLine(message);
                input = this.GetInput().ToLower();

                if(input == ANSW_NO || input == ANSW_YES)
                {
                    correctInput = true;
                }



            } while (correctInput == false);

            return input == ANSW_YES;
        }

        public string GetFilename(in string path)
        {
            string filename;
            bool correctInput = false;

            do
            {
                Console.WriteLine(Messages.FILENAME_ADD);
                filename = this.GetInput();

                //miramos si el archivo existe y si lo hace, preguntamos si sobreescribir
                if (MyDirectory.CheckFileExist(path + "\\" + filename + Program.FILE_SAVE_EXTENSION))
                {
                    string mess = Messages.FILENAME_EXISTS + String.Format(Messages.YES_NO_FORMAT, ANSW_YES, ANSW_NO);
                    if (GetInputYesOrNo(mess))
                    {
                        correctInput = true;
                    }
                }
                else
                {
                    correctInput = true;
                }

            } while (correctInput == false);

            return filename;
        }

        public bool IsValueYesrOrNo(string mess)
        {
            return (mess == ANSW_YES.ToString() || mess == ANSW_NO.ToString());
        }

        public bool IsCreateFolder(string mess)
        {
            return mess == ANSW_YES;
        }       

        public string GetInput()
        {
            Console.Write(OPERATOR);
            return Console.ReadLine();
        }


    }
}
