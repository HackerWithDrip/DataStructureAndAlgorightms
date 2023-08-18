using System;
using System.Collections;
using System.IO;
using static System.Console;

namespace P5T2
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program();
        }

        public Program()
        {
            int maxVac = 1000;
            MyQueue Q1 = new MyQueue();
            MyQueue Q2 = new MyQueue();
            MyQueue Q3 = new MyQueue();

            StreamReader sr = new StreamReader("SubmissionInputs.txt");
            StreamWriter sw = new StreamWriter("Outputs.txt");
            String line = sr.ReadLine();

            while (line != null)
            {
                String[] records = line.Split(',');
                Person person = new Person(records[0], int.Parse(records[1]));
                if (person.age < 40)
                    Q3.Enqueue(person);
                else if (person.age >= 40 && person.age < 65)
                    Q2.Enqueue(person);
                else
                    Q1.Enqueue(person);

                line = sr.ReadLine();
            }
            sr.Close();

            String lastRecipient="";

            while (maxVac > 0)
            {
                while (Q1.Count()> 0)
                {
                    if (Q1.Count() >= 4)
                    {
                        for (int i = 1; i <= 4; i++)
                        {
                            lastRecipient = ((Person)Q1.Dequeue()).name;
                            maxVac--;
                            if (maxVac == 0)
                            {
                                sw.WriteLine(lastRecipient);
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 1; i <= Q1.Count(); i++)
                        {
                            lastRecipient = ((Person)Q1.Dequeue()).name;
                            maxVac--;
                            if (maxVac == 0)
                            {
                                sw.WriteLine(lastRecipient);
                                break;
                            }
                        }
                    }
                }
                while (Q2.Count() > 0)
                {
                    if (Q2.Count() >= 2)
                    {
                        for (int i = 1; i <= 2; i++)
                        {
                            lastRecipient = ((Person)Q2.Dequeue()).name;
                            maxVac--;
                            if (maxVac == 0)
                            {
                                sw.WriteLine(lastRecipient);
                                break;
                            }
                        }
                    }
                    else
                    {
                        lastRecipient = ((Person)Q2.Dequeue()).name;
                        maxVac--;
                        if (maxVac == 0)
                        {
                            sw.WriteLine(lastRecipient);
                            break;
                        }
                    }
                }
                while (Q3.Count() > 0)
                {
                    lastRecipient = ((Person)Q3.Dequeue()).name;
                    maxVac--;
                    if (maxVac == 0)
                    {
                        sw.WriteLine(lastRecipient);
                        break;
                    }
                }
            }

            sw.Close();

            WriteLine(lastRecipient);
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

        public void Enqueue(Person person)
        {
            DLLNode newNode = new DLLNode();
            newNode.cargo = person;

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

        public Object Dequeue()
        {
            if (first == null)
                return null;
            else
            {
                Object value = first.cargo;
                first = first.next;
                if (first == null)
                    last = null;
                else
                    first.prev = null;
                queueSize--;
                return value;
            }
        }

        public Object Peek()
        {
            return (first.cargo);
        }

        public int Count()
        {
            return queueSize;
        }

        public void DisplayAll()
        {

            DLLNode temp = first;
            while (temp != null)
            {
               
                WriteLine(temp.cargo.name);
                temp = temp.next;
            }
            
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
        public Person cargo;
        public DLLNode next;
        public DLLNode prev;
    }

    class Person
    {
        public String name;
        public int age;

        public Person(String name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }

}
