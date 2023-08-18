using System;
using static System.Console;
using System.IO;

namespace P2T2
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program();
        }

        public Program()
        {
            StackLL theStack = new StackLL();
            Write("Enter thr fileName: ");
            String filename = ReadLine();
            StreamReader SR = new StreamReader(filename + ".txt");
            String line = SR.ReadLine();

            while (line != null)
            {
                if (line.StartsWith("-"))
                    theStack.Pop();
                else
                {
                    String[] record = line.Split('+');
                    theStack.Push(int.Parse(record[1]));
                }

                line = SR.ReadLine();
            }

            SR.Close();

            StreamWriter SW = new StreamWriter("Outputs.txt");
            for (int i = 0; i < theStack.getNrEl(); i++)
            {
                SW.WriteLine(theStack.Pop());
            }
            SW.Close();

            WriteLine("Done processing the file.");

            ReadLine();
        }
    }

    class StackLL
    {
        Node top = null;
        int nrEl = 0;

        public int getNrEl()
        {
            return nrEl;
        }

        public void Push(int data)
        {
            Node newNode = new Node();
            newNode.cargo = data;
            newNode.next = top;
            top = newNode;
            nrEl++;
        }

        public String Pop()
        {
            Node temp = top;
            if (temp == null)
            {
                return null; // adds empty spaces instead
            }
            else
            {
                top = top.next;

            }
            return temp.cargo.ToString();
        }

        public int Peek()
        {
            if (top == null)
            {
                WriteLine("The stack is empty (has no values)");
                return 0;
            }
            else
                return top.cargo;
        }

        public void Display()
        {
            Node temp = top;
            if (temp == null)
            {
                WriteLine("Stack is Empty!");
                return;
            }
            else
            {
                while (temp != null)
                {
                    WriteLine(temp.cargo);
                    temp = temp.next;
                }
            }
        }
    }


    class Node
    {
        public Node next;
        public int cargo;
    }
}
