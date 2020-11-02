using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace task1_refactor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите область значений X");
            Console.WriteLine("Начало");
            double x1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Конец");
            double x2;
            do
            {
                x2 = Convert.ToDouble(Console.ReadLine());
                if (x2 < x1)
                    Console.WriteLine("Область значений может идти только по возрастанию.");
                else
                    break;
            } while (x2 < x1);

            Console.WriteLine("Выберите в какую стпень возвести X ");
            double y = Convert.ToDouble(Console.ReadLine());

            List<double> KolX = new List<double>();
            List<double> KolFunc = new List<double>();

            Func(x1, x2, y, KolX, KolFunc);

            int MaxX = 0; int MaxFunc = 0;
            MaxChislo(ref MaxX, KolX);
            MaxChislo(ref MaxFunc, KolFunc);

            Tablet(KolX, KolFunc, MaxX, MaxFunc);

        }
        static void Func(double x1, double x2, double y, List<double>KolX, List<double>KolFunc)
        {
            for (double i = x1; i <= x2; i = Math.Round(i + 0.01, 2))
            {
                KolX.Add(i);
                KolFunc.Add(Math.Round(Math.Pow(i, y), 2));
            }
        }

        static void MaxChislo(ref int Max, List<double>Kol)
        {
            int KolInList = 0;
            foreach (var i in Kol)
                KolInList++;

            for (int i = 0; i < KolInList; i++)
            {
                if (i > 0)
                {
                    if (Kol[i].ToString().Length > Kol[i - 1].ToString().Length)
                    {
                        Max = 0;
                        Max += Kol[i].ToString().Length;
                    }
                }
            }
        }
        static void Tablet(List<double>KolX, List<double>KolFunc, int MaxX, int MaxFunc)
        {
            string x = "x"; string y = "y"; double ChisloX = 0; double ChisloFunc = 0; int AllChisloX = 0; int AllChisloFunc = 0;
            


            Console.Write("|-");
            FirstStroka(MaxX);
            Console.Write("-|-");
            FirstStroka(MaxFunc);
            Console.WriteLine("-|");

            Console.Write("| ");
            XandYstroka(MaxX, x);
            Console.Write(" | ");
            XandYstroka(MaxFunc, y);
            Console.WriteLine(" |");

            Console.Write("|-");
            FirstStroka(MaxX);
            Console.Write("-|-");
            FirstStroka(MaxFunc);
            Console.WriteLine("-|");

            
            for (int i = 0; i < KolX.ToString().Length; i++)
            {
                ChisloX = KolX[i];
                ChisloFunc = KolFunc[i];
                Console.Write("| ");

                Osnova(AllChisloX, ChisloX, MaxX);
                Console.Write(" | ");
                Osnova(AllChisloFunc, ChisloFunc, MaxFunc);
                Console.WriteLine(" |");
            }
            
        }
        static void FirstStroka(int Max)
        {
            for (int i = 0; i < Max; i++)
                Console.Write("-");
        }
        static void XandYstroka(int Max, string x)
        {
            if (Max % 2 == 0)
            {
                for (int i = 0; i < Max/2-1; i++)
                {
                    Console.Write(" ");
                }
                Console.Write(x);
                for (int i = 0; i < Max / 2 ; i++)
                {
                    Console.Write(" ");
                }
            }
            else
            {
                for (int i = 0; i < Max / 2 ; i++)
                {
                    Console.Write(" ");
                }
                Console.Write(x);
                for (int i = 0; i < Max / 2; i++)
                {
                    Console.Write(" ");
                }
            }
        }
        static void Osnova(int AllChislo, double Chislo, int Max )
        {
            Raznost(Max, ref AllChislo, Chislo);

            for(int i = 0; i < AllChislo; i++)
            {
                Console.Write(" ");
            }
            Console.Write(Chislo);
        }
        static void Raznost(int Max, ref int AllChislo, double Chislo)
        {
            AllChislo = Max - Chislo.ToString().Length;
        }
       
    }
}
