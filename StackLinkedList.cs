//---------------------------------------
//implementation of a Stack with single linked list
//----------------------------------------

using System;

namespace LinkedList
{
    public class Stack
    {
        Node head; // head of list  
        private int size;
        readonly int limit = 5;
        

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
            if (getSize() == 0)
            {
                Console.WriteLine("Empty Stack");
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

        public int getSize()
        {
            Node temp = head;
            size = 1;

            if (temp == null)
            {
                size = 0;
            }
            else
            {
                while (temp.next != null)
                {
                    size++;
                    temp = temp.next;
                }
            }
            return size;
        }

        public Node getTop()
        {
            Node temp = head;
           
            while (temp.next != null)
            {
                temp = temp.next;
            }
            return temp;
        }

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
        }
        
        public static void Main(String[] args)
        {
            //Create the stack
            Stack stck = new Stack();

            //Push 4 elements to the stack
            stck.push(2);
            stck.push(5);
            stck.push(7);
            stck.push(1);
            
            //Size at the begginning
            Console.WriteLine("\nThe size of the Stack is -> {0}", stck.getSize());

            //Show the stack at the begginning
            Console.WriteLine("\nInitial Stack: ");
            stck.printList();

            Console.WriteLine();

            //Push 5
            stck.push(5);
            stck.printList();

            //From here, we can not add more elements because the limit is 5.
            //Push 100
            stck.push(100);
            stck.printList();

            //Push 43
            stck.push(43);
            stck.printList();

            //Now pop number 5
            stck.pop();
            stck.printList();

            //Pop number 1
            stck.pop();
            stck.printList();

            //Shows the new size of stack after two pops.
            Console.WriteLine("\nThe size of the Stack is -> {0}", stck.getSize());


            //Try to pop more than "new size" times.
            stck.pop();
            stck.pop();
            stck.pop();
            stck.pop();


            Console.ReadLine();

        }
    }


}


