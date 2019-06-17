using System;
using System.Collections.Generic;
using System.Linq;

namespace Make_a_Salad
{
    class Program
    {
        static void Main()
        {
            var vegetablesInput = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var saladsInput = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var vegetableCalories = new Queue<int>();
            var vegetables = new Queue<string>(vegetablesInput);

            for (int i = 0; i < vegetablesInput.Length; i++)
            {
                var vegetable = vegetablesInput[i];

                switch (vegetable)
                {
                    case "tomato":
                        vegetableCalories.Enqueue(80);
                        break;
                    case "carrot":
                        vegetableCalories.Enqueue(136);
                        break;
                    case "lettuce":
                        vegetableCalories.Enqueue(109);
                        break;
                    case "potato":
                        vegetableCalories.Enqueue(215);
                        break;
                }

            }

            var salads = new Stack<int>(saladsInput);

            var readySalads = new List<int>();

            while (true)
            {
                if (salads.Count == 0)
                {
                    break;
                }

                if (vegetableCalories.Count == 0)
                {
                    break;
                }

                var salad = salads.Peek();

                while (salad > 0)
                {
                    if (vegetables.Count == 0)
                    {
                        break;
                    }
                    var currentVegetable = vegetableCalories.Dequeue();
                    vegetables.Dequeue();
                    salad -= currentVegetable;
                }

                var readySalad = salads.Pop();
                readySalads.Add(readySalad);
            }

            Console.WriteLine(string.Join(" ", readySalads));

            var left = string.Empty;
            
            if (vegetables.Any())
            {
                left = string.Join(" ", vegetables);
            }
            else
            {
                left = string.Join(" ", salads);
            }

            Console.WriteLine(left);
        }
    }
}
