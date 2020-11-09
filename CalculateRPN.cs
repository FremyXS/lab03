using System;
using System.Collections.Generic;
using RPN;

namespace Calculate
{
    public class CalculateRPN
    {
        
        public List<string> RPN = new List<string>();
        public void OsnovaCalculate(string X, ref string rez)
        {
            List<string> trash = new List<string>();
            string[] RPNArray;
            PazborRPN too = new PazborRPN();
            too.RazborRPN();

            RPNArray = too.RPN; int Kol = 0;
            
            foreach (var i in RPNArray)
            {
                RPN.Add(i);
                
                Kol++;
               
            }

            int rezult = 0; int index;

            if (RPN.Contains("x"))
            {
                index = RPN.IndexOf("x");

                RPN.RemoveAt(index);
                RPN.Insert(index, X);
            }



            for (int i = 0; i < Kol; i++)
            {
                
                if (RPN[i] == "*")
                {
                    rezult = Convert.ToInt32(RPN[i - 2]) * Convert.ToInt32(RPN[i - 1]);
                    RPN.Insert(i, Convert.ToString(rezult)); RPN.RemoveAt(i - 2); RPN.RemoveAt(i - 2); RPN.RemoveAt(i - 1);

                    i = 0; Kol -= 2;
                }
                else if (RPN[i] == "/")
                {
                    rezult = Convert.ToInt32(RPN[i - 2]) / Convert.ToInt32(RPN[i - 1]);
                    RPN.Insert(i, Convert.ToString(rezult)); RPN.RemoveAt(i - 2); RPN.RemoveAt(i - 2); RPN.RemoveAt(i - 1);

                    i = 0;  Kol -= 2;
                }
                else if (RPN[i] == "+")
                {
                    rezult = Convert.ToInt32(RPN[i - 2]) + Convert.ToInt32(RPN[i - 1]);
                    RPN.Insert(i, Convert.ToString(rezult)); RPN.RemoveAt(i - 2); RPN.RemoveAt(i - 2); RPN.RemoveAt(i - 1);

                    i = 0; Kol -= 2;
                }
                else if (RPN[i] == "-")
                {
                    rezult = Convert.ToInt32(RPN[i - 2]) - Convert.ToInt32(RPN[i - 1]);
                    RPN.Insert(i, Convert.ToString(rezult)); RPN.RemoveAt(i - 2); RPN.RemoveAt(i - 2); RPN.RemoveAt(i - 1);

                    i = 0; Kol -= 2;
                }
                
            }
            rez = RPN[0];

            RPN.RemoveAt(0);
            

            


        }
    }
}
