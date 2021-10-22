using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace variant7ulesanne3
{
    class ex2
    {
        public static void Startex2()
        {

            int rowsAr = 1;
            Random rnd = new Random();
            int[] tempArr = new int[5];
            do
            {
                Console.WriteLine("Enter the amount of rows: ");
                rowsAr = Convert.ToInt32(Console.ReadLine());
            } while (rowsAr % 2 != 0);
            int[][] jagg = new int[rowsAr][];
            for (int i = 0; i < rowsAr; i++)
            {
                jagg[i] = new int[5];
                for (int j = 0; j < 5; j++)
                {
                    jagg[i][j] = rnd.Next(1, 15);
                }
            }
            PrintAr(jagg);
            for (int i = 0; i < jagg.Length; i = i + 2)
            {
                tempArr = jagg[i];
                jagg[i] = jagg[i + 1];
                jagg[i + 1] = tempArr;
            }
            Console.WriteLine();
            PrintAr(jagg);
            /*
            int rows = 1;
            do
            {
                Console.WriteLine("Enter the amount of rows: ");
                rows = Convert.ToInt32(Console.ReadLine());
            } while (rows % 2 != 0);
            int[,] arr = new int[rows, 3];
            int temp = 0;
            for (int i = 0; i < 4; i++)
            {
                arr[rnd.Next(arr.GetLength(0)), rnd.Next(arr.GetLength(1))] = rnd.Next(1,4);
            }
            printAr(arr);
            for (int i = 0; i < arr.GetLength(0); i=i+2)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    temp = arr[i, j];
                    arr[i, j] = arr[i + 1, j];
                    arr[i + 1, j] = temp;
                }
            }
            Console.WriteLine();
            printAr(arr);*/
        }
        static void PrintAr(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void PrintAr(int[][] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    System.Console.Write("{0}{1}", arr[i][j], j == (arr[i].Length - 1) ? "" : " ");
                }
                Console.WriteLine();
            }
        }
    }
}
