// C# program for array implementation of queue 
using System;

namespace QueueArray
{
    // A class to represent a linearqueue 
    class Queue
    {
        private int[] ele;
        private int front;
        private int rear;
        private int max;

        public Queue(int size)
        {
            ele = new int[size];
            front = 0;
            rear = -1;
            max = size;
        }

        // Function to add an item to the queue.  
        // It changes rear and size 
        public void enqueue(int item)
        {
            if (rear == max - 1)
            {
                Console.WriteLine("Queue Overflow");
                return;
            }
            else
            {
                ele[++rear] = item;
            }

        }

        // Function to remove an item from queue.  
        // It changes front and size 
        public int dequeue()
        {
            if (front == rear + 1)
            {
                Console.WriteLine("Queue is Empty");
                return -1;
            }
            else
            {
                Console.WriteLine(ele[front] + " dequeued from queue");
                int p = ele[front++];
                Console.WriteLine();
                Console.WriteLine("Front item is {0}", ele[front]);
                Console.WriteLine("Rear item is {0} ", ele[rear]);
                return p;
            }

        }

        // Function to print queue.  
        public void printQueue()
        {
            if (front == rear + 1)
            {
                Console.WriteLine("Queue is Empty");
                return;
            }
            else
            {
                for (int i = front; i <= rear; i++)
                {
                    Console.WriteLine(ele[i] + " enqueued to queue");
                }
            }

        }
    }

    // Driver code 
    class Program
    {
        static void Main()
        {
            Queue Q = new Queue(5);

            Q.enqueue(10);
            Q.enqueue(20);
            Q.enqueue(30);
            Q.enqueue(40);
            Q.printQueue();
            Q.dequeue();

            Console.ReadKey();

        }
    }
}