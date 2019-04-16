using System;
using System.Linq;
using System.Collections.Generic;

namespace E06_Cards_Game
{
    class Program
    {
        static void Main()
        {
            List<int> firstPlayer = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> secondPlayer = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            WinningCardCheck(firstPlayer, secondPlayer);
            string winningPlayer;
            List<int> biggerHands;
            WinningPlayer(firstPlayer, secondPlayer, out winningPlayer, out biggerHands);
            int sum = biggerHands.Sum();
            Console.WriteLine($"{winningPlayer} player wins! Sum: {sum}");
        }
  
        private static void WinningCardCheck(List<int> firstPlayer, List<int> secondPlayer)
        {
            for (int i = 0; i < Math.Min(firstPlayer.Count, secondPlayer.Count); i++)
            {
                if (firstPlayer[i] > secondPlayer[i])
                {
                    firstPlayer.Add(firstPlayer[i]);
                    firstPlayer.Add(secondPlayer[i]);
                    firstPlayer.RemoveAt(i);
                    secondPlayer.RemoveAt(i);
                    i = -1;
                }
                else if (firstPlayer[i] < secondPlayer[i])
                {
                    secondPlayer.Add(secondPlayer[i]);
                    secondPlayer.Add(firstPlayer[i]);
                    firstPlayer.RemoveAt(i);
                    secondPlayer.RemoveAt(i);
                    i = -1;
                }
                else if (firstPlayer[i] == secondPlayer[i])
                {
                    firstPlayer.RemoveAt(i);
                    secondPlayer.RemoveAt(i);
                    i = -1;
                }
            }
        }

        private static void WinningPlayer(List<int> firstPlayer, List<int> secondPlayer, out string winningPlayer, out List<int> biggerHands)
        {
            winningPlayer = string.Empty;
            int biggerDeck = Math.Max(firstPlayer.Count, secondPlayer.Count);
            biggerHands = new List<int>();
            if (biggerDeck == firstPlayer.Count)
            {
                biggerHands = firstPlayer;
                winningPlayer = "First";
            }
            else
            {
                biggerHands = secondPlayer;
                winningPlayer = "Second";
            }
        }
    }
}
