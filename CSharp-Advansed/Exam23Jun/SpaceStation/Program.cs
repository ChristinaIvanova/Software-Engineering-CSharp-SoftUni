using System;
using System.Linq;

namespace SpaceStation
{
    class Program
    {
        static void Main()
        {
            var rows = int.Parse(Console.ReadLine());

            var galaxy = new char[rows][];

            var spaceShipRow = 0;
            var spaceShipCol = 0;

            var firstBlackHoleRow = 0;
            var firstBlackHoleCol = 0;
            var secondBlackHoleRow = 0;
            var secondBlackHoleCol = 0;

            bool isBlackHole = false;

            for (int i = 0; i < rows; i++)
            {
                var currentRow = Console.ReadLine().ToCharArray();

                galaxy[i] = currentRow;

                if (currentRow.Contains('S'))
                {
                    spaceShipRow = i;
                    spaceShipCol = Array.FindIndex(currentRow, item => item == 'S');
                }

                if (currentRow.Contains('O'))
                {
                    if (!isBlackHole)
                    {
                        firstBlackHoleRow = i;
                        firstBlackHoleCol = Array.FindIndex(currentRow, item => item == 'O');
                        isBlackHole = true;
                    }

                    secondBlackHoleRow = i;
                    secondBlackHoleCol = Array.FindIndex(currentRow, item => item == 'O');
                }
            }

            var totalStars = 0;
            bool isInGalaxy = true;

            var command = Console.ReadLine();

            while (totalStars < 50 && isInGalaxy)
            {
                galaxy[spaceShipRow][spaceShipCol] = '-';

                switch (command)
                {
                    case "up":
                        spaceShipRow -= 1;
                        break;
                    case "down":
                        spaceShipRow += 1;
                        break;
                    case "left":
                        spaceShipCol -= 1;
                        break;
                    case "right":
                        spaceShipCol += 1;
                        break;
                }

                isInGalaxy = spaceShipRow >= 0 && spaceShipRow < galaxy.Length
                                                 && spaceShipCol >= 0 && spaceShipCol < galaxy.Length;

                if (!isInGalaxy)
                {
                    isInGalaxy = false;
                    break;
                }

                bool isDigit = char.IsDigit(galaxy[spaceShipRow][spaceShipCol]);

                if (isDigit)
                {
                    var stars = galaxy[spaceShipRow][spaceShipCol] - '0';
                    totalStars += stars;

                    galaxy[spaceShipRow][spaceShipCol] = 'S';
                }
                else
                {
                    if (galaxy[spaceShipRow][spaceShipCol] == 'O')
                    {
                        galaxy[spaceShipRow][spaceShipCol] = '-';

                        if (spaceShipRow == firstBlackHoleRow
                            && spaceShipCol == firstBlackHoleCol)
                        {
                            spaceShipRow = secondBlackHoleRow;
                            spaceShipCol = secondBlackHoleCol;
                        }
                        else
                        {
                            spaceShipRow = firstBlackHoleRow;
                            spaceShipRow = firstBlackHoleCol;
                        }

                        galaxy[spaceShipRow][spaceShipCol] = 'S';
                    }
                }

                command = Console.ReadLine();
            }

            if (!isInGalaxy)
            {
                Console.WriteLine($"Bad news, the spaceship went to the void.");
            }
            else
            {
                Console.WriteLine($"Good news! Stephen succeeded in collecting enough star power!");
            }

            Console.WriteLine($"Star power collected: {totalStars}");

            foreach (var row in galaxy)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}
