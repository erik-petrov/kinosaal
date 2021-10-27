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
                        PrintAr(big);
                        Buy(big);
                        break;
                    case "med":
                        PrintAr(medium);
                        Buy(medium);
                        break;
                    case "small":
                        PrintAr(small);
                        Buy(small);
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

        static void PrintAr(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.Write($"Rida {i}: ");
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i,j] == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write(arr[i, j]);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        static void Buy(int[,] arr)
        {
            //Console.WriteLine("Впишите, какое место хотите занять в кинотеатре(ряд, столбец): ");
            //string answer = Console.ReadLine();
            //string[] ans = answer.Split(',');
            //while (arr[Convert.ToInt32(ans[0]) - 1, Convert.ToInt32(ans[1]) - 1] != 0)
            //{
            //    Console.WriteLine("Место занято. Введите другое");
            //    answer = Console.ReadLine();
            //    ans = answer.Split(',');
            //}
            //arr[Convert.ToInt32(ans[0]) - 1, Convert.ToInt32(ans[1]) - 1] = 3;
            //printAr(arr);

            Console.WriteLine("Впишите, какое место хотите занять в кинотеатре(ряд): ");
            int row = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Сколько мест вы хотите?: ");
            int amount = Convert.ToInt32(Console.ReadLine());
            FromCentre(arr, amount, row);
        }
        static void FromCentre(int[,] arr, int amount, int row)
        {
            string dec = "";
            int[] bought = new int[amount];
            int seats = Convert.ToInt32(Math.Round(Convert.ToDouble((arr.GetLength(1)-amount)/ 2))) ;
            Console.WriteLine(seats);
            for (int i = 0; i < amount; i++)
            {
                if (arr[row, seats + i] == 0)
                {
                    bought[i] = seats + i;
                }
                else
                {
                    Array.Clear(bought, 0, bought.Length);
                    Console.Write("К сожалению места в центре заняты. Хотите ли вы сами выбрать промежуток?(y/n): ");
                    string dec1 = Console.ReadLine();
                    if (dec1 == "y")
                    {
                        UserChoice(arr, row);
                        goto q;
                    }
                    else 
                    {
                        Console.WriteLine("Всего доброго!");
                        goto q;
                    }
                }
            }
            Console.WriteLine("Вы уверены что хотите купить эти места?(y/n): ");
            Console.WriteLine($"Rida {row}: ");
            foreach (int i in bought)
            {
                Console.Write($"{i} ");
            }
            dec = Console.ReadLine();
            if (dec == "y")
            {
                Console.WriteLine("Спасибо за покупку!");
                foreach (var item in bought)
                {
                    arr[row, item] = 3;
                }
            }
            else
            {
               Console.Write("Хотите ли вы выбрать места сами?(y/n): ");
               dec = Console.ReadLine();
                if (dec == "y")
                {
                    UserChoice(arr, row);
                }
                else
                { Console.WriteLine("Всего доброго!"); }
            }
        q:;
        }
        static void UserChoice(int[,] arr, int row)
        {
            string dec = "";
            Console.Write("Введите с какого места по какое хотите занять:(от, до) ");
            string[] place = Console.ReadLine().Split(',');
            int amount = Convert.ToInt32(place[1]) + Convert.ToInt32(place[0]);
            int[] taken = new int[amount];
            for (int i = 0; i < amount ; i++)
            {
                if (arr[row, Convert.ToInt32(place[0])] == 0)
                {
                    taken[i] = Convert.ToInt32(place[0]) + i;
                }
                else 
                {
                    Console.WriteLine("В вашем списке мест есть занятые места, хотите ли вы пропустить и занять следующее или отменить занимание впринципе?(skip/abort)");
                    dec = Console.ReadLine();
                    if (dec == "skip")
                    {
                        i++;
                        taken[i] = 3;
                    } else { return; }
                }
            }
            Console.WriteLine("Вы уверены что хотите купить эти места?(y/n): ");
            foreach (var item in taken)
            {
                Console.Write(item);
            }
            dec = Console.ReadLine();
            if (dec == "y")
            {
                Console.WriteLine("Спасибо за покупку!");
                foreach (var item in taken)
                {
                    arr[row, item] = 3;
                }
            }
            else
            {
                Console.WriteLine("Доброго дня!");
            }
        }
    }
}
