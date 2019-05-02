using System;
using System.Collections.Generic;
using System.Linq;

namespace L02_Average_Students_Grades
{
    class Program
    {
        static void Main()
        {
            var marks = new Dictionary<string, List<double>>();

            var totalMarks = int.Parse(Console.ReadLine());

            for (int i = 0; i < totalMarks; i++)
            {
                var marksPart = Console.ReadLine().Split();
                var name = marksPart[0];
                var grade = double.Parse(marksPart[1]);

                if (!marks.ContainsKey(name))
                {
                    marks[name] = new List<double>();
                }

                marks[name].Add(grade);
            }

            foreach (var kvp in marks)
            {
                var name = kvp.Key;
                var currentMarks = kvp.Value;
                var averageMark = currentMarks.Average();

                Console.WriteLine($"{name} -> {string.Join(" ", currentMarks)} (avg: {averageMark:f2})");
            }
        }
    }
}
