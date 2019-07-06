using System.Collections.Generic;

namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var animals = new List<Animal>();

            animals.Add(new Bear("Yoggi"));
            animals.Add(new Mammal("Ruspin"));
            animals.Add(new Reptile("snake"));
        }
    }
}