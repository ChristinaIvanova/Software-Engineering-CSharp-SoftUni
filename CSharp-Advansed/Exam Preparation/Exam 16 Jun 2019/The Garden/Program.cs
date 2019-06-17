using System;
using System.Linq;

namespace The_Garden
{
    class Program
    {
        static void Main()
        {
            var rows = int.Parse(Console.ReadLine());

            var garden = new string[rows][];

            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine()
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                garden[row] = currentRow;
            }

            var countCarrots = 0;
            var countPotatoes = 0;
            var countLettuce = 0;
            var countHarmed = 0;

            var input = Console.ReadLine();

            while (input != "End of Harvest")
            {
                var commandArgs = input.
                    Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var command = commandArgs[0];
                var row = int.Parse(commandArgs[1]);
                var col = int.Parse(commandArgs[2]);

                bool isInGarden = row >= 0 && row < garden.Length
                            && col >= 0 && col < garden[row].Length;

                switch (command)
                {
                    case "Harvest":
                        if (isInGarden)
                        {
                            if (garden[row][col] == "C")
                            {
                                countCarrots++;
                            }
                            else if (garden[row][col] == "P")
                            {
                                countPotatoes++;
                            }
                            else if (garden[row][col] == "L")
                            {
                                countLettuce++;
                            }

                            garden[row][col] = " ";
                        }
                        break;
                    case "Mole":
                        var direction = commandArgs[3];

                        if (isInGarden)
                        {
                            if (direction == "up")
                            {
                                for (int i = row; i >= 0; i -= 2)
                                {
                                    if (garden[i][col] == "C" || garden[i][col] == "P"
                                       || garden[i][col] == "L")
                                    {
                                        countHarmed++;
                                        garden[i][col] = " ";
                                    }
                                }
                            }
                            else if (direction == "down")
                            {
                                for (int i = row; i < garden.Length; i += 2)
                                {
                                    if (garden[i][col] == "C" || garden[i][col] == "P"
                                       || garden[i][col] == "L")
                                    {
                                        countHarmed++;
                                        garden[i][col] = " ";
                                    }
                                }
                            }
                            else if (direction == "right")
                            {
                                for (int i = col; i < garden[row].Length; i += 2)
                                {
                                    if (garden[row][i] == "C" || garden[row][i] == "P"
                                       || garden[row][i] == "L")
                                    {
                                        countHarmed++;
                                        garden[row][i] = " ";
                                    }
                                }

                            }
                            else if (direction == "left")
                            {
                                for (int i = col; i >= 0; i -= 2)
                                {
                                    if (garden[row][i] == "C" || garden[row][i] == "P"
                                       || garden[row][i] == "L")
                                    {
                                        countHarmed++;
                                        garden[row][i] = " ";
                                    }
                                }
                            }
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            foreach (var row in garden)
            {
                Console.WriteLine(string.Join(" ", row));
            }

            Console.WriteLine($"Carrots: {countCarrots}");
            Console.WriteLine($"Potatoes: {countPotatoes}");
            Console.WriteLine($"Lettuce: {countLettuce}");
            Console.WriteLine($"Harmed vegetables: {countHarmed}");
        }
    }
}
