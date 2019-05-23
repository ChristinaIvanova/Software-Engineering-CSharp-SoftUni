using System;

namespace LinkedList
{
    class Program
    {
        static void Main()
        {
            var node = new DoublyLinkedList();

            node.AddHead(5);
            node.AddHead(10);
            node.AddHead(25);

            //25 <-> 10 <-> <-> 5
            Console.WriteLine(node.Count == 3);
            Console.WriteLine((int)node.Head == 25);
            Console.WriteLine((int)node.Tail == 5);

            node.AddTail(1);
            node.AddTail(2);

            //25 <-> 10 <-> <-> 5 <-> 1 <-> 2
            Console.WriteLine(node.Count == 5);
            Console.WriteLine((int)node.Head == 25);
            Console.WriteLine((int)node.Tail == 2);

            node.RemoveHead();

            //10 <-> 5 <-> 1 <-> 2
            Console.WriteLine(node.Count == 4);
            Console.WriteLine((int)node.Head == 10);
            Console.WriteLine((int)node.Tail == 2);

            node.AddTail(10);
            node.RemoveHead();

            // 5 <-> 1 <-> 2 <-> 10
            Console.WriteLine(node.Count == 4);
            Console.WriteLine((int)node.Head == 5);
            Console.WriteLine((int)node.Tail == 10);
            node.ForEach(Console.WriteLine,false);

            node.RemoveTail();

            // 5 <-> 1 <-> 2 
            Console.WriteLine(node.Count == 3);
            Console.WriteLine((int)node.Head == 5);
            Console.WriteLine((int)node.Tail == 2);

            node.RemoveHead();
            node.RemoveHead();
            node.RemoveTail();
            
            Console.WriteLine(node.Count == 0);

            try
            {
                Console.WriteLine(node.Head);
                Console.WriteLine(false);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine(true);
            }
        }
    }
}
