using System;
using System.Collections.Generic;
using System.IO;
using Calculate;
using FileSearch;
using CheckProcess;


namespace Tabl
{
    class Tabl
    {
        static void Main(string[] args)
        {
            Check uu = new Check();

            uu.ProccesCheck();

            List<string> StepX = new List<string>();
            List<string> RangeX = new List<string>();
            List<string> Funcion = new List<string>();

            AllRazborFile TheLink = new AllRazborFile();

            TheLink.RazborPeremen(); TheLink.FullStepX(); TheLink.FullRangeX();

            StepX = TheLink.StepX; // шаг X
            RangeX = TheLink.RangeX; // диапозон значений X

            CalculateRPN TheLink2 = new CalculateRPN(); string rez = "";

            for ( int i = Convert.ToInt32(RangeX[0]); i <= Convert.ToInt32(RangeX[1]) ; i += Convert.ToInt32(StepX[0]))
            {
                
                TheLink2.OsnovaCalculate(Convert.ToString(i), ref rez);
                Funcion.Add(rez);
                rez = "";
            }

            int X1 = Convert.ToInt32(RangeX[0]); int X2 = Convert.ToInt32(RangeX[1]); int Hod = Convert.ToInt32(StepX[0]);
            int MaxX = 0; int MaxFunc = 0; int AllChislaX = 0; int AllChislaFunc = 0; int KolX = 0; int KolFunc = 0;
            List<string> VseX = new List<string>();
            MaxDlinaX(X1, X2, Hod, ref MaxX, ref AllChislaX, ref KolX, ref VseX);
            
            foreach(string i in Funcion)
            {
                if (MaxFunc < i.Length)
                {
                    MaxFunc = i.Length;
                }
                AllChislaFunc++;
                KolFunc++;
            }

            TablInfo(MaxX, MaxFunc, AllChislaX, AllChislaFunc, KolX, KolFunc, Funcion, VseX);
        }

        static void MaxDlinaX(int FirstZnach, int TwoZnach, int Hod, ref int Max, ref int AllChila, ref int Kol, ref List<string> VseX)
        {
            Max = Convert.ToString(FirstZnach).Length;
            for (int i = FirstZnach; i <= TwoZnach; i+=Hod)
            {
                if(Max < Convert.ToString(i).Length)
                {
                    Max = Convert.ToString(i).Length;
                }
                AllChila++;
                Kol++;

                VseX.Add(Convert.ToString(i));
            }
        }
        static void TablInfo(int MaxX, int MaxFunc, int AllChislaX, int AllChislaFunc, int KolX, int KolFunc, List<string> Funcion, List<string> VseX)
        {
            AllRazborFile TheLink = new AllRazborFile();
            TheLink.ClearFile();

            string X = "x"; string Y = "y"; int ChisloX; int ChisloFunc; string Empty;
            
            Console.Write("|-");
            Empty = "|-"; TheLink.Print(Empty);
            FirstStrok(MaxX);
            Console.Write("-|-");
            Empty = "-|-"; TheLink.Print(Empty);
            FirstStrok(MaxFunc);
            Console.WriteLine("-|");
            Empty = "-|"; TheLink.Print(Empty);
            TheLink.NewStroka();

            Console.Write("| ");
            Empty = "| "; TheLink.Print(Empty);
            XandYstroka(MaxX, X);
            Empty = " | "; TheLink.Print(Empty);
            Console.Write(" | ");
            XandYstroka(MaxFunc, Y);
            Console.WriteLine(" |");
            Empty = " |"; TheLink.Print(Empty);
            TheLink.NewStroka();

            Console.Write("|-");
            Empty = "|-"; TheLink.Print(Empty);
            FirstStrok(MaxX);
            Console.Write("-|-");
            Empty = "-|-"; TheLink.Print(Empty);
            FirstStrok(MaxFunc);
            Console.WriteLine("-|");
            Empty = "-|"; TheLink.Print(Empty);
            TheLink.NewStroka();

            for (int i = 0; i < KolX; i++)
            {
                ChisloX = Convert.ToInt32(VseX[i]);
                ChisloFunc = Convert.ToInt32(Funcion[i]);
                Console.Write("| "); Empty = "| "; TheLink.Print(Empty);

                Osnova(AllChislaX, ChisloX, MaxX);
                Console.Write(" | "); Empty = " | "; TheLink.Print(Empty);
                Osnova(AllChislaFunc, ChisloFunc, MaxFunc);
                Console.WriteLine(" |"); Empty = " |"; TheLink.Print(Empty);
                TheLink.NewStroka();
            }

        }
        static void FirstStrok(int Max)
        {
            AllRazborFile TheLink = new AllRazborFile();
            string Empty;

            for(int i = 0; i < Max; i++)
            {
                Console.Write("-"); Empty = "-"; TheLink.Print(Empty);
            }
        }
        static void XandYstroka(int Max, string x)
        {
            AllRazborFile TheLink = new AllRazborFile();
            string Empty;

            if (Max % 2 == 0)
            {
                for (int i = 0; i < Max / 2 - 1; i++)
                {
                    Console.Write(" "); Empty = " "; TheLink.Print(Empty);
                }
                Console.Write(x); Empty = x; TheLink.Print(Empty);
                for (int i = 0; i < Max / 2; i++)
                {
                    Console.Write(" "); Empty = " "; TheLink.Print(Empty);
                }
            }
            else
            {
                for (int i = 0; i < Max / 2; i++)
                {
                    Console.Write(" "); Empty = " "; TheLink.Print(Empty);
                }
                Console.Write(x); Empty = x; TheLink.Print(Empty);
                for (int i = 0; i < Max / 2; i++)
                {
                    Console.Write(" "); Empty = " "; TheLink.Print(Empty);
                }
            }
        }
        static void Osnova(int AllChislo, int Chislo, int Max)
        {
            AllRazborFile TheLink = new AllRazborFile();
            string Empty;

            Raznost(Max, ref AllChislo, Chislo);

            for (int i = 0; i < AllChislo; i++)
            {
                Console.Write(" "); Empty = " "; TheLink.Print(Empty);
            }
            Console.Write(Chislo); Empty = Convert.ToString(Chislo); TheLink.Print(Empty);
        }
        static void Raznost(int Max, ref int AllChislo, double Chislo)
        {
            AllChislo = Max - Chislo.ToString().Length;
        }

    }
}
