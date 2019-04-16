using System;
using System.Linq;
using System.Collections.Generic;

namespace L04_List_of_products
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalProducts = int.Parse(Console.ReadLine());
            List<string> products=new List<string>();
            for (int i = 0; i < totalProducts; i++)
            {
                string currentProduct = Console.ReadLine();
                products.Add(currentProduct);//products.Add(Console.ReadLine());
            }
            products.Sort();
            for (int i = 0; i < totalProducts; i++)
            {
                Console.WriteLine($"{i+1}.{products[i]}");
            }
        }
    }
}
