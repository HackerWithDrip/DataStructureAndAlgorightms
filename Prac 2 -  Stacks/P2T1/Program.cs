using System;
using System.IO;
using System.Collections.Generic;
using static System.Console;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2T1
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
                theStack.Push(line);
                line = SR.ReadLine();
            }

            SR.Close();
            
            StreamWriter SW = new StreamWriter("Outputs.txt");
            for (int i = 0; i < theStack.getNrEl(); i++)
            {
                SW.WriteLine(theStack.Pop());
            }
            SW.Close();

            WriteLine("Done!");

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

        public void Push(String data)
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
                return null;
            else
            {
                top = top.next;
                
            }
            return temp.cargo;
        }

        public String Peek()
        {
            if (top == null)
                return null;
            else
                return top.cargo;
        }

        public void Display()
        {
            Node temp = top;
            if(temp== null)
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
        public String cargo;
    }
}
