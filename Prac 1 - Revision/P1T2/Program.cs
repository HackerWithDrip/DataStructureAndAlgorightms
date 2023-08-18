using System;
using static System.Console;

namespace P1T2
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program();
        }

        public Program()
        {
            DLL list = new DLL();

            for (int i = 1; i <= 5; i++)
            {
                list.InsertAtMiddle(i);
            }

            list.DisplayAll();
            WriteLine("");
            list.DisplayAllReverse();
            ReadLine();
        }
    }


    class DLL
    {
        DLLNode head;
        DLLNode tail;
        int listSize;

        public DLL()
        {
            head = null;
            tail = head;
            listSize = 0;
        }

        public void InsertAtMiddle(int val)
        {
            
            DLLNode newNode = new DLLNode();
            newNode.cargo = val;

            
            if (head == null)
            {
                head = newNode;
                tail = newNode;
                listSize++;
               
                
            }
            else if (head.next==null)
            {
                head.prev = newNode;
                newNode.next = head;
                head = newNode;
                listSize++;
               
            }
            else
            {
                DLLNode temp = head;
                int pos = listSize / 2;
                while (pos > 0)
                {
                    temp = temp.next;
                    pos--;
                }
                
                temp.prev.next = newNode;
                newNode.next = temp;
                newNode.prev = temp.prev;
                temp.prev = newNode;
                listSize++;
            }
        }

        public void DisplayAll()
        {
            DLLNode temp = head;
            while (temp != null)
            {
                Write(temp.cargo);
                temp = temp.next;
            }
        }

        public void DisplayAllReverse()
        {
            DLLNode temp = tail;
            while (temp != null)
            {
                Write(temp.cargo);
                temp = temp.prev;
            }
        }

        public int getListSize()
        {
            return listSize;
        }

    }

        class DLLNode
    {
        public int cargo;
        public DLLNode next;
        public DLLNode prev;
    }

}
