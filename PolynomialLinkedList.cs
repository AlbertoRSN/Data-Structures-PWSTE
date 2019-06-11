
//Polynomial using linked list

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class LinkedList
    {
        Node head; // head of list  
        public class Node
        {
            public int exp;
            public int coef;
            public Node next; // Pointer
            public Node(int exp, int coef)
            {
                this.exp = exp;
                this.coef = coef;
                next = null;
            }
        }
        /*
        public void printList()
        {
            Node n = head;
            
            while (n != null && n.coef != 0)
            {
                if(n.coef > 1)
                {
                    if(n.coef == 1)
                        Console.Write("x^" + n.exp + " + ");
                    else
                        Console.Write(n.coef + "x^" + n.exp + " + ");
                }
                else if(n.coef == -1)
                {
                    Console.Write("-x^" + n.exp + " + ");
                }
                else if(n.exp == 0)
                {
                    Console.Write(n.coef);
                }
                else if(n.exp == 1)
                {
                    Console.Write(n.coef + "x");
                }
                else if (n.next == null)
                { 
                    Console.Write(n.coef + "x^" + n.exp);
                }
                else 
                {
                    Console.Write(n.coef + "x^" + n.exp + " + ");
                } 
 
                n = n.next;
            }
            Console.WriteLine();
        }
        */


        public void printList()
        {
            Node n = head;

            while (n != null)
            {
                if (n.coef == 1)
                {
                    Console.Write("x^" + n.exp);
                }
                else if (n.coef == -1)
                {
                    Console.Write("-x^" + n.exp);
                }
                else if (n.exp == 1)
                {
                    Console.Write(n.coef + "x");
                }

                else if (n.exp == 0)
                {
                    Console.Write(n.coef);
                }

                else
                {
                    Console.Write(n.coef + "x^" + n.exp);
                }

                if (n.next != null && n.next.coef > 0)
                { Console.Write(" + "); }

                n = n.next;
            }
            Console.WriteLine();
        }

        public void AddInFront(int p_exp, int p_coef) //adding a node in a front of a list
        {
            Node new_node = new Node(p_exp, p_coef);
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

        public void Append(int p_exp, int p_coef)
        {
            Node new_node = new Node(p_exp, p_coef);
            if (head == null)
            {
                head = new_node;
                return;
            }
            Node lastNode = GetLastNode();
            lastNode.next = new_node;
        }



        public void Reverse()
        {
            Node prev = null;
            Node temp = null;

            Node current = head;

            while (current != null)
            {
                temp = current.next;
                current.next = prev;
                prev = current;
                current = temp;
            }
            head = prev;
        }

        public double Value(double x)//Calculates the value of a given x.
        {
            double value = 0;

            Node n = head;
            while (n != null)
            {
                value += n.coef * Math.Pow(x, n.exp);
                n = n.next;
            }

            return value;
        }

        public LinkedList Derivative()
        {
            LinkedList w = new LinkedList();
            Node n = head;

            while (n != null)
            {
                if (n.exp > 0)
                    w.AddInFront(n.exp - 1, n.exp * n.coef);
                n = n.next;
            }
            return w;
        }

        public void Add(LinkedList pol)
        {
            Node n = head;
            Node aux = pol.head;
            while (n != null)
            {
                n.coef = n.coef + aux.coef;
                n = n.next;
                aux = aux.next;
            }
        }

        public void MultiplyByNumber(int number)
        {
            Node n = head;

            while (n != null)
            {
                n.coef *= number;
                n = n.next;
            }
        }

        public static void Main(String[] args)
        {
            LinkedList P = new LinkedList();
            LinkedList Q = new LinkedList();

            P.AddInFront(3, -1);
            P.AddInFront(2, 2);
            P.AddInFront(1, 4);
            P.AddInFront(0, -4);

            P.Reverse();

            Q.Append(3, 5);
            Q.Append(2, 3);
            Q.Append(1, 7);
            Q.Append(0, -4);


            Console.Write("P(x) = ");
            P.printList();

            double x = 2;
            Console.WriteLine("P(" + x + ") = " + P.Value(x));

            x = 0;
            Console.WriteLine("P(" + x + ") = " + P.Value(x));


            LinkedList w = P.Derivative();
            Console.Write("P'(x) = ");
            w.Reverse();
            w.printList();



            Console.WriteLine("\n ----------- Polynomials -----------");
            Console.Write("P(x) = ");
            P.printList();
            Console.Write("W(x) = ");
            Q.printList();

            Console.Write("\nP(x) + W(x) =  ");
            P.Add(Q);
            P.printList();

            int number = 5;
            Console.WriteLine("\nMultiply polynomial 'P' by number {0}", number);
            Console.Write("P(x) = ");
            P.MultiplyByNumber(number);
            P.printList();

            Console.ReadKey();
        }
    }

}






