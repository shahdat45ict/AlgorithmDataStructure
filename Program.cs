using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*int n = 10;
            // int[] arr = new int[] {1, 64, -12, 15, 11, 40 };
            int[] arr = new int[n];
            int[] arr1 = new int[n];
            int[] arr2 = new int[n];
            int[] arr3 = new int[n];
            int[] arr4 = new int[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                arr[i] = arr1[i] = arr2[i] = arr3[i] = arr4[i] = random.Next(0, n);
            }
            Console.WriteLine("Unsorted Array");
            //PrintArray(arr);
            SelectionSort(arr1);
            BubbleSort(arr2);
            ShahdatSort(arr3);

            int l = 0, r = arr.Length - 1;
            DateTime start = DateTime.Now;
            MergeSort(arr4, l, r);
            Console.WriteLine("\nMerge sort elapsed time: " + DateTime.Now.Subtract(start).TotalMilliseconds + " millisecs");
            Console.WriteLine("Sorted Array");
           // PrintArray(arr4);*/

            int[] arr = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };// {38,27,43,3,9,82,10};        
            Console.WriteLine("\n");
            Node bt = BuildBinaryTree(arr);
            PrintBinaryTree(bt);
        }

        static void PrintArray(int[] arr)
        {
            if (arr == null) return;

            foreach (int v in arr)
            {
                Console.Write(v + " ");
            }
        }
        static void SelectionSort(int[] arr)
        {
            DateTime startTime = DateTime.Now;

            if (arr == null)
            {
                return;
            }
            int n = arr.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int mini = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[mini])
                    {
                        mini = j;
                    }
                }
                if (arr[i] > arr[mini])
                {
                    int t = arr[mini];
                    arr[mini] = arr[i];
                    arr[i] = t;
                }
            }


            //print           
            Console.WriteLine();
            Console.WriteLine(string.Format("Selection Sort elapsed time {0} milliseconds",
             DateTime.Now.Subtract(startTime).TotalMilliseconds));
            Console.WriteLine("Sorted Array");
            if (n < 100)
                PrintArray(arr);
            return;
        }
        static void BubbleSort(int[] arr)
        {
            DateTime startTime = DateTime.Now;

            if (arr == null) return;
            int n = arr.Length;

            for (int i = n; i > 1; i--)
            {
                for (int j = 0; j < i - 1; j++)
                {
                    if (arr[j + 1] < arr[j])
                    {
                        int t = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = t;
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine(string.Format("Bubble sort elapsed time {0} milliseconds",
           DateTime.Now.Subtract(startTime).TotalMilliseconds));
            Console.WriteLine("Sorted Array");
            if (n < 100)
                PrintArray(arr);
            return;
        }
        static void ShahdatSort(int[] arr)
        {
            DateTime startTime = DateTime.Now;

            if (arr == null) return;

            int n = arr.Length;
            int sp = 0;
            while (sp < n - 1)
            {
                int p = sp;
                for (int j = p + 1; j < n; j++)
                    if (arr[j] < arr[p]) p = j;

                if (p == sp) sp++;
                else
                {
                    int t = arr[p];
                    arr[p] = arr[sp];
                    arr[sp] = t;
                }
            }

            Console.WriteLine();
            Console.WriteLine(string.Format("Shahdat sort elapsed time {0} milliseconds",
           DateTime.Now.Subtract(startTime).TotalMilliseconds));
            Console.WriteLine("Sorted Array");
            if (n < 100)
                PrintArray(arr);
            return;
        }

        static void MergeSort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                int m = (l + r) / 2;

                MergeSort(arr, l, m);
                MergeSort(arr, m + 1, r);
                Merge(arr, l, m, r);
            }
        }
        static void Merge(int[] arr, int l, int m, int r)
        {
            int n1 = m - l + 1;
            int n2 = r - m;
            int[] t1 = new int[n1];
            int[] t2 = new int[n2];

            for (int i = 0; i < n1; i++)
            {
                t1[i] = arr[l + i];
            }
            for (int j = 0; j < n2; j++)
            {
                t2[j] = arr[m + 1 + j];
            }

            int x = 0, y = 0, z = l;
            while (x < n1 || y < n2)
            {
                if (x < n1 && y < n2)
                {
                    if (t1[x] < t2[y])
                    {
                        arr[z++] = t1[x++];
                    }
                    else
                    {
                        arr[z++] = t2[y++];
                    }
                }
                else if (x < n1)
                {
                    arr[z++] = t1[x++];
                }
                else if (y < n2)
                {
                    arr[z++] = t2[y++];
                }
            }
        }
        static Node BuildBinaryTree(int[] arr)
        {
            int i = 0, n = arr.Length;
            Node root = new Node(arr[i++]);
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                Node node = queue.Dequeue();
                if (i < n)
                {
                    node.LNode = new Node(arr[i++]);
                    queue.Enqueue(node.LNode);
                }
                if (i < n)
                {
                    node.RNode = new Node(arr[i++]);
                    queue.Enqueue(node.RNode);
                }

            }
            return root;
        }
        static void PrintBinaryTree(Node bt)
        {
            /*Node bt = new Node(0)
            {
                LNode = new Node(1)
                {
                    LNode = new Node(3),
                    RNode = new Node(4)
                },
                RNode = new Node(2)
                {
                    LNode = new Node(5),
                    RNode = new Node(6)
                }
            };*/

            bt.PrintBTreeBreathFirst();
            bt.PrintBTreeDepthFirst();
            Console.WriteLine("\nPrintRecurrsive");
            bt.PrintBTreeRecurrsive();
        }
    }
    class Node
    {
        public object Data { set; get; }
        //b tree
        public Node LNode { set; get; }
        public Node RNode { set; get; }
        //linkedlist
        public Node Next { set; get; }
        public Node(object data)
        {
            this.Data = data;
            this.LNode = null;
            this.RNode = null;
            this.Next = null;
        }
        public void PrintBTreeRecurrsive()
        {
            Console.Write(Data + " ");

            if (LNode != null)
            {
                LNode.PrintBTreeRecurrsive();
            }
            if (RNode != null)
            {
                RNode.PrintBTreeRecurrsive();
            }
            if (Next != null)
            {
                Next.PrintBTreeRecurrsive();
            }
        }
        public void PrintBTreeBreathFirst()
        {
            Console.WriteLine("\nPrintBreathFirst");
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(this);
            while (queue.Count != 0)
            {
                Node node = queue.Dequeue();
                Console.Write(node.Data + " ");
                if (node.LNode != null)
                    queue.Enqueue(node.LNode);
                if (node.RNode != null)
                    queue.Enqueue(node.RNode);
            }
        }
        public void PrintBTreeDepthFirst()
        {
            Console.WriteLine("\nPrintDeapthFirst");
            Stack<Node> stack = new Stack<Node>();
            stack.Push(this);
            while (stack.Count != 0)
            {
                Node node = stack.Pop();
                Console.Write(node.Data + " ");
                if (node.RNode != null)
                    stack.Push(node.RNode);
                if (node.LNode != null)
                    stack.Push(node.LNode);
            }
        }
    }
}
