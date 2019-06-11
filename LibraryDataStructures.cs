using System;


namespace DSLibrary
{
    public class LinkedList // The definition of a linked list
    {
        public Node head;              // head of list 

        public class Node              // the constructor
        {
            public int data;
            public Node next;
            public Node(int d)
            {
                data = d;
                next = null;
            }
        }

        public void AddFirst(int new_data) //adding a node in a front of a list
        {
            Node new_node = new Node(new_data);
            new_node.next = head;
            head = new_node;
        }

        public Node GetLastNode()
        {
            Node temp = head;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            return temp;
        }

        public void AddLast(int new_data)
        {
            Node new_node = new Node(new_data);
            if (head == null)
            {
                head = new_node;
                return;
            }
            Node lastNode = GetLastNode();
            lastNode.next = new_node;
        }

        public void InsertAfter(int prev_key, int new_data)
        {
            Node n = head;
            while (n != null && n.data != prev_key)
            {
                n = n.next;
            }
            Node new_node = new Node(new_data);
            new_node.next = n.next;
            n.next = new_node;
        }


        public void InsertBefore(int next_key, int new_data)
        {
            if (head == null) return;
            if (head.data == next_key)
            {
                AddFirst(new_data);
                return;
            }

            Node prev = null;
            Node cur = head;

            while (cur != null && cur.data != next_key)
            {
                prev = cur;
                cur = cur.next;
            }

            Node new_node = new Node(new_data);

            prev.next = new_node;
            new_node.next = cur;

        }

        public void Update(int key, int new_data)
        {
            if (head == null) return;
            if (head.data == key)
            {
                AddFirst(new_data);
                return;
            }

            Node prev = null;
            Node cur = head;

            while (cur != null && cur.data != key)
            {
                prev = cur;
                cur = cur.next;
            }

            prev.next = cur;
            cur.data = new_data;
        }


        public void ReverseLinkedList()
        {
            Node prev = null;
            Node current = head;
            Node temp = null;
            while (current != null)
            {
                temp = current.next;
                current.next = prev;
                prev = current;
                current = temp;
            }
            head = prev;
        }

        public void DeleteNodebyKey(int key)
        {
            Node temp = head;
            Node prev = null;
            if (temp != null && temp.data == key)
            {
                head = temp.next;
                return;
            }
            while (temp != null && temp.data != key)
            {
                prev = temp;
                temp = temp.next;
            }
            if (temp == null)
            {
                return;
            }
            prev.next = temp.next;
        }



        public void PrintList() // prints out all nodes of a list
        {
            Node n = head;
            while (n != null)
            {
                Console.Write(n.data + " ");
                n = n.next;
            }
            Console.WriteLine();
        }        

    } //class LINKEDLIST


    public class Stack : LinkedList
    {
        private int size;
        readonly int limit = 5;

        public void push(int new_data)
        {
            Node new_node = new Node(new_data);

            if (head == null)
            {
                Console.WriteLine("Pushed number {0} to the stack.", new_data);
                head = new_node;
                size++;
                return;
            }

            if (size < limit)
            {
                Console.WriteLine("Pushed number {0} to the stack.", new_data);
                Node lastNode = getTop();
                lastNode.next = new_node;
                size++;
            }
            else
            {
                Console.WriteLine("\nStack is FULL, you can not add more elements.");
            }
        }

        public void pop()
        {
            Node temp = head;
            Node prev = null;

            if (head == null)
            {
                Console.WriteLine("The Stack is empty");
            }
            else
            {
                if (temp.next == null)
                {
                    prev = temp;
                    head = null;
                    Console.WriteLine("\nPopped number {0} from the stack.", prev.data);
                    size--;
                }
                else
                {
                    while (temp.next.next != null)
                    {
                        temp = temp.next;
                    }
                    prev = temp.next;
                    Console.WriteLine("\nPopped number {0} from the stack.", prev.data);
                    size--;

                    temp.next = null;

                }
            }
        }//MethodAccessException Pop

        public Node getTop()
        {
            Node temp = head;

            while (temp.next != null)
            {
                temp = temp.next;
            }
            return temp;
        }//Method getTop

    }//CLASS STACK


    public class Queue : LinkedList
    {
          
        private int size;
        readonly int limit = 5;

        public Node getTop()
        {
            Node temp = head;

            while (temp.next != null)
            {
                temp = temp.next;
            }
            return temp;
        }

        public void queuePrintList()
        {
            Node n = head;
            if (size == 0)
            {
                Console.WriteLine("Empty Queue");
            }
            else
            {
                while (n != null)
                {
                    Console.Write(n.data + " ");
                    n = n.next;
                }
            }
            Console.WriteLine();
        }

        public void enqueue(int new_data)
        {
            Node new_node = new Node(new_data);

            if (head == null)
            {
                Console.WriteLine("Pushed number {0} to the queue.", new_data);
                head = new_node;
                size++;
                return;
            }

            if (size < limit)
            {
                Console.WriteLine("Pushed number {0} to the queue.", new_data);
                Node lastNode = getTop();
                lastNode.next = new_node;
                size++;
            }
            else
            {
                Console.WriteLine("\nQueue is FULL, you can not add more elements.");
            }
        }

        public void dequeue()
        {
            Node temp = head;
            Node prev = null;

            if (head == null)
            {
                Console.WriteLine("The queue is empty");
            }
            else
            {
                if (temp.next == null)
                {
                    prev = temp;
                    head = null;
                    Console.WriteLine("\nDequeued number {0} from the queue.", prev.data);
                    size--;
                }
                else
                {
                    while (temp.next.next != null)
                    {
                        temp = temp.next;
                    }
                    prev = temp.next;
                    Console.WriteLine("\nDequeued number {0} from the queue.", prev.data);
                    size--;

                    temp.next = null;

                }
            }
        }

    }//CLASS QUEUE


    public class NodeB
    {
        public int data;
        public NodeB left, right;

        public NodeB(int item)
        {
            data = item;
            left = right = null;
        }
    }//CLASS NodeB

    public class BinaryTree
    {

        public NodeB root;
        public static int counter = 0;

        public BinaryTree()
        {
            root = null;
        }

        
        void printPreorder(NodeB node)
        {
            if (node == null)
                return;
            Console.Write(node.data + "-");
            printPreorder(node.left);
            printPreorder(node.right);
        }

        void printPostorder(NodeB NodeB)
        {
            if (NodeB == null)
                return;

            printPostorder(NodeB.left);
            printPostorder(NodeB.right);
            Console.Write(NodeB.data + " ");
        }

        void printInorder(NodeB NodeB)
        {
            if (NodeB == null)
                return;
            printInorder(NodeB.left);
            Console.Write(NodeB.data + " ");
            printInorder(NodeB.right);
        }

        bool isBST(NodeB node, int min, int max)
        {
            /* an empty tree is BST */
            if (node == null)
            {
                return true;
            }

            if (node.data < min || node.data > max)
            {
                return false;
            }

            return (isBST(node.left, min, node.data - 1)
                && isBST(node.right, node.data + 1, max));
        }
    }//CLASS BINARY TREE

    public class BinaryTreeBST : BinaryTree
    {

        bool search(NodeB root, int key)
        {
            while (root != null)
            {
                Console.Write(root.data + "-");
                if (key > root.data)
                    root = root.right;
                else if (key < root.data)
                    root = root.left;
                else
                    return true;
            }
            return false;
        }

        NodeB searchRec(NodeB root, int key)
        {
            if (root == null || root.data == key)
                return root;

            if (root.data > key)
                return searchRec(root.left, key);

            return searchRec(root.right, key);
        }

        int maxKey(NodeB root)
        {
            int max = root.data;

            while (root != null)
            {
                max = root.data;
                root = root.right;
            }

            return max;
        }

        int minKey(NodeB root)
        {
            int min = root.data;

            while (root != null)
            {
                min = root.data;
                root = root.left;
            }

            return min;
        }

        void insert(NodeB root, int key)
        {
            if (root == null)
            {
                NodeB node = new NodeB(key);
                this.root = node;
            }
            else if (key < root.data)
            {
                if (root.left != null)
                {
                    insert(root.left, key);
                }
                else
                {
                    root.left = new NodeB(key);
                }
            }
            else if (key > root.data)
            {
                if (root.right != null)
                {
                    insert(root.right, key);
                }
                else
                {
                    root.right = new NodeB(key);
                }
            }
        }
    }
}
