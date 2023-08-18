using System;
using System.Collections;
using System.IO;
using static System.Console;


namespace P4T2
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program();
        }

        public Program()
        {
            StreamReader sr = new StreamReader("SubmissionInputs.txt");
            StreamWriter sw = new StreamWriter("Outputs.txt");
            Stack S = new Stack();
            Queue Q = new Queue();


            String line = sr.ReadLine();
            while (line != null)
            {
                String[] records = line.Split(' ');
                for (int i = 0; i < records.Length; i++)
                {
                    Q.Enqueue(records[i]);
                }
                int numOfQentries = records.Length;

                for (int i = 1; i <= numOfQentries; i++)
                {
                    String qElement = Q.Peek().ToString();

                    if (qElement.Equals("+"))
                    {
                        if (S.Count > 1)
                        {
                            Q.Dequeue();
                            S.Push(Double.Parse(S.Pop().ToString()) + Double.Parse(S.Pop().ToString()));
                        }
                        else
                            WriteLine("Expression is not Valid");
                    }
                    else if (qElement.Equals("*"))
                    {
                        if (S.Count > 1)
                        {
                            Q.Dequeue();
                            S.Push(Double.Parse(S.Pop().ToString()) * Double.Parse(S.Pop().ToString()));
                        }
                        else
                            WriteLine("Expression is not Valid");
                    }
                    else
                        S.Push(Double.Parse(Q.Dequeue().ToString()));
                }
                WriteLine("{0:F2}", S.Peek().ToString());
                sw.WriteLine("{0:F2}", Double.Parse(S.Peek().ToString()));

                Q.Clear();
                line = sr.ReadLine();
            }
          
            ReadLine();
            sr.Close();
            sw.Close();
        }
        
    }
}
