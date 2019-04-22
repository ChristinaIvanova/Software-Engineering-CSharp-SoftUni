using System;
using System.Linq;
namespace _004E_Array_rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int rotations = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < rotations; i++)
            {
                int firstNum = array[0];
                for (int j = 0; j < array.Length - 1; j++)
                {
                    array[j] = array[j + 1];
                }
                array[array.Length - 1] = firstNum;
            }
            Console.WriteLine(string.Join(' ',array));
        }

             
            
        
    }
}
