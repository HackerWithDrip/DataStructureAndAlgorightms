using System;
using static System.Console;
using System.IO;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4T1
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program();
        }

        public Program()
        {
            Stack theStack = new Stack();
            Queue theQueue = new Queue();

            StreamReader sr = new StreamReader("SubmissionInputs.txt");
            StreamWriter sw = new StreamWriter("Output.txt");

            string line = sr.ReadLine();

            while (line != null)
            {
                string[] records = line.Split(' ');
                for(int i = 0; i < records.Length; i++)
                {
                    if (records[i].Equals("+"))
                    {
                        if (theStack.Count == 0)
                            theStack.Push("+");
                        else if (theStack.Peek().ToString().Equals("*"))
                        {
                            String stackElement = theStack.Peek().ToString();
                            while (stackElement.Equals("*") && theStack.Count > 0)
                            {
                                theQueue.Enqueue(theStack.Pop());
                                if(theStack.Count>0)
                                    stackElement = theStack.Peek().ToString();
                            }
                            theStack.Push(records[i]);
                        }
                        else
                            theStack.Push(records[i]);
                    }
                    else if (records[i].Equals("*"))                        
                            theStack.Push("*");
                    else
                        theQueue.Enqueue(Double.Parse((records[i])));
                }
                
                int nrElStack = theStack.Count;

                for (int j = 1; j <= nrElStack; j++)
                {
                    theQueue.Enqueue(theStack.Pop().ToString());
                }

                Object[] list = theQueue.ToArray();

                for (int i = 0; i < theQueue.Count; i++)
                {
                    sw.Write("{0} ", list[i].ToString());
                }
                sw.WriteLine();
                theQueue.Clear();
                line = sr.ReadLine();
            }
            sr.Close();
            sw.Close();
            WriteLine("Process Complete!");
            ReadLine();
        }
    }
}
