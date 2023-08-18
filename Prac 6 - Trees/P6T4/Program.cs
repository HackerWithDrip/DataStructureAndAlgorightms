using System;
using System.Collections;
using System.IO;
using static System.Console;


namespace P6T4
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
            Stack theStack = new Stack();
            StreamReader sr = new StreamReader("SubmissionInputs.txt");
            String line = sr.ReadLine();
            line = sr.ReadLine(); // Read it twice to skip the first line

            while (line != null)
            {

                if (line.Contains(","))
                {
                    String[] nums = line.Split(',');
                    for (int i = 0; i < nums.Length; i++)
                        theStack.Push(nums[i]);
                }
                else if (!(line.Contains("<")) && !(line.Contains(","))) // root of the tree
                {
                    theStack.Push(line);
                    int sum = 0;
                    int cnt = theStack.Count;

                    while (cnt > 0)
                    {
                        int number = int.Parse((String)theStack.Pop());
                        sum = sum + number;
                        cnt--;
                    }
                    theStack.Clear();
                    WriteLine("sum = {0}", sum);
                    SW.WriteLine("{0}", sum);
                }
                else
                    line = sr.ReadLine(); // Move to the next line
                line = sr.ReadLine();       // Twice
            }
            sr.Close();

            SW.Close();
            WriteLine();
            WriteLine("Dankie Mpilo !!!!");
            ReadLine();
        }
    }
}
