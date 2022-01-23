using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeightOfBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            int height = 0;
            Node root = null;
            //Enter number of test cases 
            while (t-- > 0)
            {
                //Enter the string with spaces for each test case like 1 2 3 for below binary tree
                //1
                //  \
                //    2
                //     \
                //       3
                string data = Console.ReadLine();
                foreach(int ele in data.Split(Convert.ToChar(" ")).ToList().Select(x => Convert.ToInt32(x)))
                {
                    root = Solution.insert(root, ele);
                    height = Solution.height(root);
                }
                Console.WriteLine(height);
            }
            
        }
    }
    //To create node object
    class Node
    {
        public Node left;
        public Node right;
        public int data;

        public Node(int data)
        {
            this.data = data;
            left = null;
            right = null;
        }
    }
    //To find height of a binary tree using recursion
    class Solution
    {
        public static int height(Node root)
        {

            if (root == null)
                return -1;
            else
            {
                /* compute the depth of each subtree */
                int lDepth = height(root.left);
                int rDepth = height(root.right);

                /* use the larger one */
                if (lDepth < rDepth)
                    return (rDepth + 1);
                else
                    return (lDepth + 1);
            }
        }
        public static Node insert(Node root, int data)
        {
            if (root == null)
            {
                return new Node(data);
            }
            else
            {
                Node cur;
                if (data <= root.data)
                {
                    cur = insert(root.left, data);
                    root.left = cur;
                }
                else
                {
                    cur = insert(root.right, data);
                    root.right = cur;
                }
                return root;
            }
        }
    }


}