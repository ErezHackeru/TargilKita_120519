using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    class ImageFile<T> : MyFile
    {
        public override void PrintFile()
        {
            for (int i = 0; i < ScreenColor.GetLength(0); i++)      //lines
            {
                for (int j = 0; j < ScreenColor.GetLength(1); j++)  //columns
                {
                    Console.WriteLine(ScreenColor[i, j]);
                }
            }
        }

        public T[,] ScreenColor { get; set; }

        public ImageFile(T[,] screenColor)
        {
            ScreenColor = screenColor;
        }


    }
}
