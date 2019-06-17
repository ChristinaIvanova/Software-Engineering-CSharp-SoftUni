namespace E05_Generic_Count_Method_String
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var lines = int.Parse(Console.ReadLine());
            var box = new Box<string>();

            for (int i = 0; i < lines; i++)
            {
                var item = Console.ReadLine();
                box.Add(item);
            }

            var itemTocompare = Console.ReadLine();

            var greaterCount = GetGreaterCountOfElements(box.Values, itemTocompare);

            Console.WriteLine(greaterCount);
        }

        public static int GetGreaterCountOfElements<T>(List<T> listWithData, T item)
            where T : IComparable
        {
            var greaterValues = listWithData.Where(x => item.CompareTo(x) < 0).ToList();
            return greaterValues.Count;
        }
    }
}
