using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace variant7ulesanne3
{
    class ex1
    {
        public static void Startex1()
        {
            Console.OutputEncoding = Encoding.UTF8;
            int[,] medium = new int[20, 30];
            int[,] small = new int[10, 20];
            int[,] big = new int[50, 70];

            Random rnd = new Random();
            for (int i = 0; i < 15; i++)
            {
                medium[rnd.Next(medium.GetLength(0)), rnd.Next(medium.GetLength(1))] = 1;
                small[rnd.Next(small.GetLength(0)), rnd.Next(small.GetLength(1))] = 1;
                big[rnd.Next(big.GetLength(0)), rnd.Next(big.GetLength(1))] = 1;
            }
            while (true)
            {
                Console.WriteLine("Впишите, какой зал хотите выбрать(big, med, small): ");
                string dec = Console.ReadLine();
                switch (dec)
                {
                    case "big":
                        printAr(big);
                        buy(big);
                        break;
                    case "med":
                        printAr(medium);
                        buy(medium);
                        break;
                    case "small":
                        printAr(small);
                        buy(small);
                        break;
                    case "q":
                        goto q;
                    default:
                        Console.WriteLine("Неверный зал.");
                        break;
                }
            }
        q:
            Console.WriteLine("Всего доброго.");
            Console.ReadLine();
        }

        static void printAr(int[,] arr)
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

        static void buy(int[,] arr)
        {
            Console.WriteLine("Впишите, какое место хотите занять в кинотеатре(ряд, столбец): ");
            string answer = Console.ReadLine();
            string[] ans = answer.Split(',');
            while (arr[Convert.ToInt32(ans[0]) - 1, Convert.ToInt32(ans[1]) - 1] != 0)
            {
                Console.WriteLine("Место занято. Введите другое");
                answer = Console.ReadLine();
                ans = answer.Split(',');
            }
            arr[Convert.ToInt32(ans[0]) - 1, Convert.ToInt32(ans[1]) - 1] = 3;
            printAr(arr);
        }
    }
}
