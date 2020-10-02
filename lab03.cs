using System;

namespace lab03_ver2
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

            double ChisloX = x1;
            int KolX = 0;
            for (; x1 <= x2; x1 += 0.01) 
            {
                KolX += 1;
            }

            double[] MassivKolX = new double [KolX];
            double[] MassivFunc = new double [KolX];
            int KolChiselX=0;
            int KolChiselFunc=0;

            double ChisloFunc;
            for (int i = 0; i < KolX; i++)
            {
                MassivKolX[i] = Math.Round(ChisloX, 3);
                ChisloX += 0.01;
                ChisloFunc = Math.Round(Math.Pow(MassivKolX[i], y), 3);
                MassivFunc[i] = ChisloFunc;
                
                if (i > 0)
                {
                    if (MassivKolX[i].ToString().Length > MassivKolX[i - 1].ToString().Length)
                    {
                        KolChiselX = 0;
                        KolChiselX += MassivKolX[i].ToString().Length;
                    }
                    if (MassivFunc[i].ToString().Length > MassivFunc[i - 1].ToString().Length)
                    {
                        KolChiselFunc = 0;
                        KolChiselFunc += MassivFunc[i].ToString().Length;
                    }
                }
            }
            FirstStroka(KolChiselX, KolChiselFunc);

            StrokaXandY(KolChiselX, KolChiselFunc);

            SecondStroka(KolChiselX, KolChiselFunc);

            int RaznX;
            int RaznFunc;
            for (int i = 0; i < KolX; i++) 
            {
                RaznX = Math.Abs(KolChiselX - MassivKolX[i].ToString().Length);
                RaznFunc = Math.Abs(KolChiselFunc - MassivFunc[i].ToString().Length);
                Console.Write("| ");
                if (RaznX > 0)
                {
                    for (int x = 0; x < RaznX; x++)
                        Console.Write(" ");
                }
                Console.Write(MassivKolX[i]);
                Console.Write(" | ");
                if (RaznFunc > 0)
                {
                    for (int func = 0; func < RaznFunc; func++)
                        Console.Write(" ");
                }
                Console.Write(MassivFunc[i]);
                Console.WriteLine(" |");
            }

        }
        static void FirstStroka(int KolChiselX, int KolChiselFunc) 
        {
           Console.Write("|-");
           for (int n = 0; n < KolChiselX; n++)
               Console.Write("-");
           Console.Write("-|-");
           for (int n = 0; n < KolChiselFunc; n++)
               Console.Write("-");
           Console.WriteLine("-|");
        }

        static void StrokaXandY(int KolChiselX, int KolChiselFunc) 
        {
            Console.Write("| ");
            if (KolChiselX % 2 == 0)
            {
                for (int n = 0; n < KolChiselX / 2; n++)
                    Console.Write(" ");
                Console.Write("x");
                for (int n = 0; n < KolChiselX / 2 - 1; n++)
                    Console.Write(" ");
            }
            else
            {
                for (int n = 0; n < KolChiselX / 2; n++)
                    Console.Write(" ");
                Console.Write("x");
                for (int n = 0; n < KolChiselX / 2; n++)
                    Console.Write(" ");
            }
            Console.Write(" | ");
            if (KolChiselFunc % 2 == 0)
            {
                for (int n = 0; n < KolChiselFunc / 2; n++)
                    Console.Write(" ");
                Console.Write("y");
                for (int n = 0; n < KolChiselFunc / 2 - 1; n++)
                    Console.Write(" ");
            }
            else
            {
                for (int n = 0; n < KolChiselFunc / 2; n++)
                    Console.Write(" ");
                Console.Write("y");
                for (int n = 0; n < KolChiselFunc / 2; n++)
                    Console.Write(" ");
            }
            Console.WriteLine(" |");
        }

        static void SecondStroka(int KolChiselX, int KolChiselFunc) 
        {
            Console.Write("|-");
            for (int n = 0; n < KolChiselX; n++)
                Console.Write("-");
            Console.Write("---");
            for (int n = 0; n < KolChiselFunc; n++)
                Console.Write("-");
            Console.WriteLine("-|");
        }

        
    }
}
