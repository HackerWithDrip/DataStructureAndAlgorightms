using System;
using static System.Console;
using System.IO;
using System.Collections;

namespace P6T3
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

            while (line != null)
            {
                if (line.Contains(","))
                {
                    String[] nums = line.Split(',');
                    for (int i = 0; i < nums.Length; i++)
                        theStack.Push(nums[i]);
                }
                else if (!(line.Contains("<")) && !(line.Contains(",")))
                {
                    theStack.Push(line);
                    int min = int.Parse(line);
                    int max = int.Parse(line);
                    int sum = 0;
                    int cnt = theStack.Count, n = theStack.Count;

                    while (cnt > 0)
                    {
                        int number = int.Parse((String)theStack.Pop());
                        if (min > number)
                            min = number;
                        if (max < number)
                            max = number;
                        sum = sum + number;
                        cnt--;
                    }
                    Write("Average = {0:F2}",((Double)sum/n));
                    WriteLine();
                    SW.Write("{0:F2}", ((Double)sum / n));
                    SW.WriteLine();
                }
                line = sr.ReadLine();
            }
            sr.Close();

            SW.Close();
            WriteLine();
            WriteLine("Asbonge !!!!");
            ReadLine();
        }
    }
}
