using System;
using System.Collections.Generic;
using System.Linq;
using FileSearch;

namespace CheckProcess
{
    public class Check
    {
        private List<string> Peremens = new List<string>();
        private string text;
        private void ChekInfo()
        {
            AllRazborFile TheLink = new AllRazborFile();
            
            TheLink.RazborPeremen();

            Peremens = TheLink.Peremen;
        }
        public void ProccesCheck()
        {
            ChekInfo();

            char [] Oper = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '-', '*', '/', '(', ')', ' ', 'x' };
            text = Peremens[0];

            int ind = 0;
            foreach(var i in text)
            {
                if (Oper.Contains(i) == false)
                {
                    WriteError(ind);
                    Console.WriteLine("Неверный оператор!");
                    System.Environment.Exit(0);
                }
                ind++;
            }

            int KolLeftScob = 0; int KolRightScob = 0;

            foreach (var i in text)
            {
                if (i == '(')
                    KolLeftScob++;
                else if (i == ')')
                    KolRightScob++;
            }

            if (KolRightScob > KolLeftScob)
            {
                ind = text.IndexOf(')');

                WriteError(ind);
                Console.WriteLine("Лишняя скобка!");
                System.Environment.Exit(0);
            }
            else if (KolRightScob < KolLeftScob)
            {
                ind = text.IndexOf('(');

                WriteError(ind);
                Console.WriteLine("Лишняя скобка!");
                System.Environment.Exit(0);
            }
        }
        private void WriteError(int ind)
        {
            Console.WriteLine(text);

            for (int i = 0; i < ind; i++)
                Console.Write(" ");
            Console.WriteLine("^");
        }
        

    }
}
