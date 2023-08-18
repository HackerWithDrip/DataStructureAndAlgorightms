using System;
using System.IO;
using static System.Console;

namespace P1T1
{
    class Program
    {
        LinkedList List = new LinkedList();
        static void Main(string[] args)
        {
            new Program();
        }

        public Program()
        {
            IntersectionMerge();
            reverseRecursiveHelper();
            List.DisplayAll();
            ReadLine();
        }

        public SLLNode IntersectionMerge()
        {
            StreamReader SR = new StreamReader("File1.txt");
            StreamReader sr = new StreamReader("File2.txt");
            string lineF1 = SR.ReadLine();
            string lineF2 = sr.ReadLine();
            while (lineF1 != null && lineF2 != null)
            {
                if (lineF1.CompareTo(lineF2) < 0)
                {
                    lineF1 = SR.ReadLine();
                }
                else if ((lineF1.CompareTo(lineF2) == 0))
                {
                    List.InsertAtLast(lineF1);
                    lineF1 = SR.ReadLine();
                    lineF2 = sr.ReadLine();
                }
                else
                {
                    lineF2 = sr.ReadLine();
                }
            }
            SR.Close();
            sr.Close();
            return List.head;
        }

        public void reverseRecursiveHelper()
        {
            List.head = reverseRecursive(List.head);
        }
        public SLLNode reverseRecursive(SLLNode curNode)
        {
            // terminating condition: empty list or
            // single node (since they are already reversed)
            if (curNode == null || curNode.next == null)
                return curNode;
            // reverse the rest of the list:
            SLLNode headForRest = reverseRecursive(curNode.next);
            // change the pointers
            curNode.next.next = curNode;
            curNode.next = null;
            return headForRest;
        }
    }

    class SLLNode
    {
        public String Cargo;
        public SLLNode next;
    }

    class LinkedList
    {
        public SLLNode head;
        public SLLNode tail;
        int listSize;

        public LinkedList()
        {
            head = null;
            tail = head;
            listSize = 0;
        }

        public void InsertAtLast(string value)
        {
            SLLNode newNode = new SLLNode();
            newNode.Cargo = value;

            if (head == null)
            {
                head = newNode;
                tail = newNode;
                listSize++;
            }
            else
            {
                tail.next = newNode;
                tail = newNode;
                listSize++;
            }
        }

        public void DisplayAll()
        {
            SLLNode curNode = head;
            while (curNode != null)
            {
                WriteLine(curNode.Cargo);
                curNode = curNode.next;
            }
        }
    }
}
