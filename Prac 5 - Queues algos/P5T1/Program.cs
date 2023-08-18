using System;
using static System.Console;
using System.IO;

namespace P5T1
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program();
        }

        public Program()
        {
            MyQueue Q = new MyQueue();
          
            int numberOfCandy = 0;

            StreamReader sr = new StreamReader("SubmissionInputs.txt");
            string line = sr.ReadLine();

            while (line != null)
            {
                string[] records = line.Split(',');
                Q.Enqueue(int.Parse(records[1]));
                line = sr.ReadLine();
            }
            sr.Close();

            int Qlength = Q.Count();

            while (Qlength > 21) 
            {
                int NumberOfQuestions = Q.Dequeue();
                numberOfCandy++;

                if (NumberOfQuestions-1 > 0)
                    Q.Enqueue(NumberOfQuestions - 1);

                Qlength = Q.Count();

            }
            numberOfCandy = numberOfCandy + 21;
            WriteLine("Gave up {0} candies",numberOfCandy);
            StreamWriter sw = new StreamWriter("Outputs.txt");
            sw.Write(numberOfCandy);
            sw.Close();

            ReadLine();
        }
    }


    class MyQueue
    {
        DLLNode first;
        DLLNode last;
        int queueSize;

        public MyQueue()
        {
            first = null;
            last = first;
            queueSize = 0;
        }

        public void Enqueue(int value)
        {
            DLLNode newNode = new DLLNode();
            newNode.cargo = value;

            if (first == null)
            {
                first = newNode;
                last = newNode;
                queueSize++;
            }
            else
            {
                last.next = newNode;
                newNode.prev = last;
                last = newNode;
                queueSize++;
            }
        }

        public int Dequeue()
        {
            if (first == null)
                return 0; 
            else
            {
                Object value = first.cargo;
                first = first.next;
                if (first == null)
                    last = null;
                else 
                    first.prev = null;
                queueSize--;
                return (int)value;
            }
        }

        public int Peek()
        {
            return (first.cargo);
        }

        public int Count()
        {
            return queueSize;
        }

        public void DisplayAll()
        {
            int q = 0;
            DLLNode temp = first;
            while (temp != null)
            {
                q = q + temp.cargo;
                WriteLine(temp.cargo);
                temp = temp.next;
            }
            WriteLine("number of questions = {0}", q);
        }

        public void clearAll()
        {
            first = null;
            last = first;
            queueSize = 0;
        }

    }

    class DLLNode
    {
        public int cargo;
        public DLLNode next;
        public DLLNode prev;  
    }

}
