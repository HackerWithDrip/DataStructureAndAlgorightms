using System;
using System.Collections;
using System.IO;
using static System.Console;

namespace P7T2
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
            BTNode Root = new BTNode(0);
            StreamReader SR = new StreamReader("SubmissionInputs.txt");
            String Line = SR.ReadLine();

            while (Line != null)
            {
                Root.value++;
                BTNode curNode = Root;
                foreach(char item in Line)
                    curNode = BuildTree(curNode, item);
                Line = SR.ReadLine();
            }
            SR.Close();
            //LevelOrderDisplay(Root);
            FindSequence(Root);
            SW.Close();
            WriteLine("Process complete!");
            ReadLine();
        }

        public BTNode BuildTree(BTNode root, Char c)
        {
            if (c.Equals('B'))
            {
                if (root.left == null)
                {
                    BTNode newNode = new BTNode(1);
                    root.left = newNode;
                    root = newNode;
                }
                else
                {
                    root.left.value++;
                    root = root.left;
                }
            }
            else if (c.Equals('R'))
            {
                if (root.right == null)
                {
                    BTNode newNode = new BTNode(1);
                    root.right = newNode;
                    root = newNode;
                }
                else
                {
                    root.right.value++;
                    root = root.right;
                }
            }
            return root;
        }

        public void FindSequence(BTNode root)
        {
            int threshold = (root.value) / 2;
            do
            {
                if (root.right.value >= threshold && root.left.value < root.right.value)
                {
                    SW.Write("R");
                    root = root.right;
                }
                else if (root.left.value >= threshold && root.left.value > root.right.value)
                {
                    SW.Write("B");
                    root = root.left;
                }
                else break;
            } while (root.left != null && root.right != null);
        }

        
        public void LevelOrderDisplay(BTNode N)
        {
            Queue Q = new Queue();
            Q.Enqueue(N);

            while (Q.Count > 0)
            {
                BTNode cur = (BTNode)Q.Dequeue();
                Write(cur.value + ",");
                if (cur.left != null) Q.Enqueue(cur.left);
                if (cur.right != null) Q.Enqueue(cur.right);
            }
        }
    }
 
    public class BTNode
    {
        public BTNode left;
        public BTNode right;
        public int value;

        public BTNode(int val)
        {
            value = val;
            left = null;
            right = null;
        }
    }
}