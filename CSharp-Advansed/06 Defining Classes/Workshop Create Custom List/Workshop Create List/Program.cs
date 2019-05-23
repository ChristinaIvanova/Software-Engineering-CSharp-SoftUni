namespace Workshop_Create_List
{
    using System;

    class Program
    {
        static void Main()
        {
            var listTest = new CustomList();

            listTest.Add(2);
            listTest.Add(3);
            listTest.Add(5);
            listTest.Add(6);
            //2 3 5
            Console.WriteLine(listTest.Count == 4);

            listTest.RemoveAt(2);
            // 2 3 6
            Console.WriteLine(listTest[2] == 6);

            listTest.Add(4);
            listTest.Add(42);
            listTest.Add(41);
            listTest.RemoveAt(0);
            //3 6 4 42 41
            Console.WriteLine(listTest[0] == 3);
            Console.WriteLine(listTest[1] == 6);
  
            Console.WriteLine(listTest[listTest.Count - 1] == 41);
            Console.WriteLine(listTest[listTest.Count - 2] == 42);

            listTest.RemoveAt(2);
            listTest.RemoveAt(2);

        }
    }
}
