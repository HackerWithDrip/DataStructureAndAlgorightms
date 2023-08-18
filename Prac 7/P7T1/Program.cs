using System;
using System.Collections;
using static System.Console;
using System.IO;

namespace P7T1
{
    class Program
    {
        StreamWriter SW = new StreamWriter("Outputs.txt");

        static void Main(string[] args)
        {
            new Program();
        }

        public Program()
        {
            StreamReader SR = new StreamReader("SubmissionInputs.txt");
            Stack S = new Stack();
            Queue Q = new Queue();
            String line = SR.ReadLine(); // Reads the first line

            while (line != null)
            {
                String[] AscSeq = line.Split(',');
                foreach (string number in AscSeq)
                    Q.Enqueue(number);
                line = SR.ReadLine(); // Reads second line

                String[] DescSeq = line.Split(',');
                foreach (string number in DescSeq)
                    S.Push(number);
                MergeSequences(Q, S); // Performs the merging
                line = SR.ReadLine(); // Updates the first line

            }
            SR.Close();
            SW.Close();
            WriteLine("Process complete!");
            ReadLine();
        }

        public void MergeSequences(Queue Q, Stack S)
        {
            while (Q.Count > 0 && S.Count > 0)
            {
                if (int.Parse((String)Q.Peek()) < int.Parse((String)S.Peek()))
                    SW.Write((String)Q.Dequeue() + ",");
                else if (int.Parse((String)Q.Peek()) > int.Parse((String)S.Peek()))
                    SW.Write((String)S.Pop() + ",");
                else
                    SW.Write((String)Q.Dequeue() + ","+ (String)S.Pop() + ",");
            }

            while (Q.Count > 0)
                SW.Write((String)Q.Dequeue() + ",");

            while (S.Count > 0)
                SW.Write((String)S.Pop() + ",");

            SW.WriteLine();
        }
    }
}
