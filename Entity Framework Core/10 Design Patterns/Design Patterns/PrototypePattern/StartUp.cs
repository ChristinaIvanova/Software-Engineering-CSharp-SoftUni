using System;

namespace PrototypePattern
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var sandwichMenu = new SandwichMenu
            {
                ["BLT"] = new Sandwich("Wheat", "Bacon", "", "Lettuce, Tomato"),
                ["PB&J"] = new Sandwich("White", "", "", "PeanutButter, Jelly"),
                ["Turkey"] = new Sandwich("Rye", "Turkey", "Swiss", "Lettuce, Tomato, Onion")
            };


            var sandwich1 = sandwichMenu["Turkey"].Clone() as Sandwich;
            var sandwich2 = sandwichMenu["BLT"].Clone() as Sandwich;
            var sandwich3 = sandwichMenu["PB&J"].Clone() as Sandwich;
        }
    }
}
