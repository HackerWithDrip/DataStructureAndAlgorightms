 using System;
using System.Collections;
using static System.Console;
using System.IO;

namespace P6T1
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
            ArrayList listOfTrees = new ArrayList();
            StreamReader sr = new StreamReader("SubmissionInputs.txt");
          
            String line = sr.ReadLine();

            while (line != null) 
            {    
                if (line.Contains(","))
                {
                    String[] nums = line.Split(',');
                    for(int i = 0;i < nums.Length; i++)
                        theStack.Push(nums[i]);
                }
                else if (!(line.Contains("<")) && !(line.Contains(",")))
                {
                    theStack.Push(line);
                    int cnt = theStack.Count;
                    ArrayList list = new ArrayList();
                   
                    while (cnt > 0)                      // Adding the elements in the list
                    {
                        String item = (String)theStack.Pop();
                        list.Add(item);
                        cnt--;
                    }
                    listOfTrees.Add(list);              // Adding the list in the listOfTrees
                }
                line = sr.ReadLine();
            }
            sr.Close();

            for (int j = 0; j<listOfTrees.Count; j++)
            {
                BTNode root = InsertLevelOrder((ArrayList)(listOfTrees)[j], 0);

                PreOrderDisplay(root);
                WriteLine();
                SW.WriteLine();
                PostOrderDisplay(root);
                WriteLine();
                SW.WriteLine();
                LevelOrderDisplay(root);
                WriteLine();
                WriteLine();
                SW.WriteLine();
                SW.WriteLine();
            }

            SW.Close();

            WriteLine("DANKO !!!!");
            ReadLine();
        }

        //Method to insert Nodes in level order

        public BTNode InsertLevelOrder(ArrayList list,int i)
        {
            BTNode root = null;
            //Base case ffor recursion
            if (i < list.Count)
            {
                root = new BTNode(list[i].ToString());

                //insert right child
                root.right = InsertLevelOrder(list, 2 * i + 1);

                //insert left child
                root.left = InsertLevelOrder(list, 2 * i + 2);
            }
            return root;
        }

        public void PreOrderDisplay(BTNode N)
        {
            if (N != null)
            {
                Write(N.value+", ");
                SW.Write(N.value + ",");
                PreOrderDisplay(N.left);
                PreOrderDisplay(N.right);
            }
        }

        public void PostOrderDisplay(BTNode N)
        {
            if (N != null)
            {
                PostOrderDisplay(N.left);
                PostOrderDisplay(N.right);
                Write(N.value + ", ");
                SW.Write(N.value + ",");
            }
        }

        public void LevelOrderDisplay(BTNode N)
        {
            Queue Q = new Queue();
            Q.Enqueue(N);

            while (Q.Count > 0)
            {
                BTNode cur = (BTNode)Q.Dequeue();
                Write(cur.value + ", ");
                SW.Write(cur.value + ",");
                if (cur.left != null) Q.Enqueue(cur.left);
                if (cur.right != null) Q.Enqueue(cur.right);
            }
        }

    }

    public class BTNode
    {
        public BTNode left;
        public BTNode right;
        public string value;

        public BTNode (string val)
        {
            value = val;
            left = null;
            right = null;
        }
    }
}
