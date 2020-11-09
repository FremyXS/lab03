using System;
using System.Collections.Generic;
using System.IO;

namespace FileSearch
{
    public class AllRazborFile
    {
        private string text = File.ReadAllText(@"D:\lab\AdvancedCalculator\input.txt");
        private string OutPut = @"D:\lab\AdvancedCalculator\output.txt";

        public List<string> Peremen = new List<string>();

        public void RazborPeremen() 
        {
            Peremen.AddRange(text.Split(';', ':'));
            
            Peremen.RemoveAt(4);
            Peremen.RemoveAt(2);
            Peremen.RemoveAt(0);
        }


        public List<string> Funcion = new List <string> ();
        public List<string> StepX = new List<string>();
        public List<string> RangeX = new List<string>();

        public void FullFuncion()
        {
            string[] Trash = Peremen[0].Split(new char[]{' '});
            foreach (var i in Trash)
            {
                if (i!="")
                    Funcion.Add(i);
            }
        }
        public void FullStepX()
        {
            string[] Trash = Peremen[1].Split(new char[] { ' ' });
            foreach (var i in Trash)
            {
                if (i != "")
                    StepX.Add(i);
            }
        }
        public void FullRangeX()
        {
            string[] Trash = Peremen[2].Split(new char[] { ' ' });
            foreach (var i in Trash)
            {
                if (i != "")
                    RangeX.Add(i);
            }
        }
        public void Print(string message)
        {
            File.AppendAllText(OutPut, message);
        }

        public void NewStroka()
        {
            File.AppendAllText(OutPut, "" + Environment.NewLine);
        }
        public void ClearFile()
        {
            File.WriteAllText(OutPut, string.Empty);
        }


    }
    
}
