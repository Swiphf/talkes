using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Table
    {
        public List<Coin> Left { get; private set; }
        public List<Coin> Right { get; private set; }
        public List<Coin> Coins { get; set; }

        public Table(int gold, int silver)
        {
            this.Left = new List<Coin>();
            this.Right = new List<Coin>();
            this.Coins = new List<Coin>();
        }

        public string MoveCoinsToStack(int coinsToMove, List<Coin> stack)
        {
            int numberOfCoins = Math.Min(coinsToMove, this.Coins.Count);

            for (int i = 0; i < numberOfCoins; i++)
            {
                if (this.Coins.Count > 0)
                {
                    stack.Add(this.Coins[0]);
                    this.Coins.RemoveAt(0);
                }
            }

            return numberOfCoins + " Coins moved";
        }

        public string FlipCoinsInStack(int coinsToFlip, List<Coin> stack)
        {
            int numberOfCoins = Math.Min(coinsToFlip, this.Coins.Count);

            for (int i = 0; i < numberOfCoins; i++)
            {
                stack[i].Flip();
            }
            return numberOfCoins + " Coins flipped";
        }

        public void PrintTable(List<Coin> stack)
        {
            int goldCounter = 0;
            int silverCounter = 0;

            for (int i = 0; i < stack.Count; i++)
            {
                if (stack[i].Side == Side.silver)
                {
                    silverCounter++;
                }
                else
                {
                    goldCounter++;
                }
            }
            Console.WriteLine("silver amount: " + silverCounter + " gold amount: " + goldCounter + "\n");
        }
    }
}