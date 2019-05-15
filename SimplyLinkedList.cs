//---------------------------------------
//implementation of a single linked list
//----------------------------------------

using System;

namespace LinkedList
{
    public class LinkedList
    {
        Node head; // head of list  
        public class Node
        {
            public int data;
            public Node next; // Pointer
            public Node(int d)
            {
                data = d;
                next = null;
            }
        }

        public void printList()
        {
            Node n = head;
            while (n != null)
            {
                Console.Write(n.data + " ");
                n = n.next;
            }
            Console.WriteLine();
        }

        public void printList(Node head)
        {
            if (head == null)
            {
                //Empty List
                Console.Write("");
            }
            else
            {
                Console.Write(head.data + " ");
                printList(head.next);
            }
        }

        public void AddInFront(int new_data) //adding a node in a front of a list
        {
            Node new_node = new Node(new_data);
            new_node.next = head;
            head = new_node;
        }

        
        void InsertAfter(Node prev_node, int new_data)
        {
            if (prev_node == null)
            {
                Console.WriteLine("The given node cannot be null !");
                return;
            }
            Node new_node = new Node(new_data);
            new_node.next = prev_node.next;
            prev_node.next = new_node;
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

        public void Append(int new_data)
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

        public void Remove(LinkedList list1, Node nodeToRemove)
        {
            Node temp = list1.head;
            Node prev = null;

            //List not empty and first element node to remove
            if (temp != null && temp == nodeToRemove)
            {
                //List with only 1 element
                if (temp.next != null)
                {
                    list1.head = temp.next;
                }
                //More than 1 elements
                else
                {
                    head = null;
                }
            }
            while (temp != null && temp.next != nodeToRemove)
            {
                prev = temp;
                temp = temp.next;
            }
            if (temp != null)
            {
                prev.next = temp.next;
            }

        }

        public void DeleteNodebyKey(LinkedList singlyList, int key)
        {
            Node temp = singlyList.head;
            Node prev = null;
            if (temp != null && temp.data == key)
            {
                singlyList.head = temp.next;
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

        public void Reverse(LinkedList lst1)
        {
            Node prev = null;
            Node temp = null;

            Node current = lst1.head;
            
            while (current != null)
            {
                temp = current.next;
                current.next = prev;
                prev = current;
                current = temp;
            }
            lst1.head = prev;
        }

        public static void Main(String[] args)
        {

            LinkedList lst = new LinkedList();

            lst.head = new Node(2);
            Node second = new Node(3);
            Node third = new Node(5);
            Node fourth = new Node(7);

            lst.head.next = second;
            second.next = third;
            third.next = fourth;
            lst.AddInFront(100);

            lst.printList();

            lst.InsertAfter(second, 50);

            lst.printList();

            lst.InsertAfter(lst.head.next, 333);

            lst.printList();

            lst.InsertAfter(lst.GetLastNode(), 8);

            lst.printList();

            //lst.DeleteNodebyKey(lst,50);
            lst.Remove(lst, second);
            lst.printList();



            lst.Reverse(lst);
            lst.printList();

            lst.printList(lst.head);

            /*
            Console.Write(lst.head.data + " ");
            Console.Write(lst.head.next.data + " ");
            Console.Write(second.data + " ");
            Console.Write(third.data + " ");
            Console.Write(fourth.data + " ");
            */


            /*
            lst.AddInFront(100);

            lst.printList();

            lst.AddInFront(200);

            lst.printList();
            */

            Console.ReadLine();

        }
    }


}


