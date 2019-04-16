using System;
using System.Linq;
using System.Collections.Generic;

namespace E08_Anonymous_Threat
{
    class Program
    {
        static void Main()
        {
            List<string> text = Console.ReadLine().Split().ToList();
            
            while (true)
            {
                List<string> input = Console.ReadLine().Split().ToList();
                if (input[0] == "3:1")
                {
                    break;
                }
                switch (input[0])
                {
                    case "merge":
                        int startIndex = int.Parse(input[1]);
                        int endIndex = int.Parse(input[2]);
                        if (startIndex < 0)
                        {
                            startIndex = 0;
                        }
                        else if (startIndex > text.Count - 1)
                        {
                            startIndex = text.Count - 1;
                        }
                        if (endIndex > text.Count - 1)
                        {
                            endIndex = text.Count - 1;
                        }
                        else if (endIndex < 0)
                        {
                            endIndex = 0;
                        }
                        //List<string> mergeRange = text.Skip(startIndex).Take(endIndex-startIndex+1 ).ToList();
                        List<string> mergeRange = new List<string>();
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            mergeRange.Add(text[i]);
                        }
                        text[startIndex] = string.Join("", mergeRange);
                        for (int i = startIndex+1; i <= endIndex; i++)
                        {
                            text.RemoveAt(startIndex + 1);
                        }
                        //text.RemoveRange(startIndex + 1, endIndex - startIndex);
                        break;

                    case "divide":
                        string divide = text[int.Parse(input[1])];
                        int index = int.Parse(input[1]);
                        List<string> temp = new List<string>();
                        int partitions = int.Parse(input[2]);
                        int divideElementLenght = divide.Length / partitions;
                        int additionalLenght = divide.Length % partitions;
                        for (int i = 0; i < partitions; i++)
                        {
                            if (i > partitions / 2)
                            {
                                divideElementLenght += additionalLenght;
                            }
                            temp.Add(divide.Substring(0, divideElementLenght));
                            divide.Remove(0,divideElementLenght);
                        }
                        text.RemoveAt(index);
                        text.InsertRange(index, temp);
                        
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", text));
        }
    }
}
