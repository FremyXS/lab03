using System;
using System.Collections.Generic;
using System.Linq;
using FileSearch;
using Microsoft.VisualBasic.CompilerServices;

namespace RPN
{
    public class PazborRPN
    {
        public List<string> ArrayRPN = new List<string>();
        public string[] RPN;

        private Stack<string> Queue = new Stack<string>();
        private Stack<string> Stack = new Stack<string>();

        private void RPNC()
        {


            AllRazborFile TheLink = new AllRazborFile();
            List<string> Peremens;

            TheLink.RazborPeremen();
            TheLink.FullFuncion();

            Peremens = TheLink.Funcion;

            string[] ArrayOper = { "+", "-", "*", "/" };
            string[] Prior2 = { "*", "/" };
            string[] Prior1 = { "-", "+" };
            string[] Scob = { "(", ")" };

            int KolInPer = 0; Kolich(Peremens, ref KolInPer);



            for (int i = 0; i < KolInPer; i++)
            {
                int KolOp = 0;
                foreach (var n in Stack)
                    KolOp++;

                if (ArrayOper.Contains(Peremens[i]) == false && Scob.Contains(Peremens[i]) == false)
                {
                    Queue.Push(Peremens[i]);
                }
                else if (ArrayOper.Contains(Peremens[i]) && Scob.Contains(Peremens[i]) == false)
                {


                    if (Stack.Count() == 0 || Stack.Peek() == "(")
                    {
                        Stack.Push(Peremens[i]);
                    }
                    else if (Prior2.Contains(Peremens[i]) && Prior1.Contains(Stack.Peek()))
                    {
                        Stack.Push(Peremens[i]);
                    }
                    else if (Prior1.Contains(Peremens[i]) && (Prior1.Contains(Stack.Peek()) || Prior2.Contains(Stack.Peek())))
                    {
                        // KolOp = 0;
                        //foreach (var n in Stack)
                        //  KolOp++;
                        do
                        {
                            Queue.Push(Stack.Pop());

                            if (Stack.Count() == 0)
                                break;

                        } while (Prior1.Contains(Stack.Peek()) == false || Stack.Peek() != "(");

                        Stack.Push(Peremens[i]);
                    }
                }
                else if (Peremens[i] == "(")
                {
                    Stack.Push(Peremens[i]);
                }
                else if (Peremens[i] == ")")
                {
                    do
                    {
                        Queue.Push(Stack.Pop());

                    } while (Stack.Peek() != "(");

                    if (Stack.Peek() == "(")
                        Stack.Pop();
                }


            }
            Queue.Push(Stack.Pop());
        }
        public void RazborRPN()
        {
            RPNC();

            int KolPeremens = 0;

            foreach (var i in Queue)
            {
                KolPeremens++;
            }

            RPN = new string[KolPeremens];

            for (int i = KolPeremens - 1; i >= 0; i--)
            {
                RPN[i] = Queue.Pop();
            }
        }
        
        private static void Kolich(List<string> LF, ref int Kol)
        {
            foreach (var i in LF)
                Kol++;
        }



    }
}
