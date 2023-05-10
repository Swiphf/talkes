using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Game
    {
        private static int _silver = 20;
        private static int _gold = 80;
        private int _total = _silver + _gold;
        private string _userInput, _result;
        Random _rnd = new Random();

        private static Table _table = null;
        public static Table Table
        {
            get
            {
                if (_table == null)
                {
                    _table = new Table(_gold, _silver);
                }
                return _table;
            }
        }

        public Game()
        {
            InitGame();
        }

        public void InitGame()
        {
            InitCoins();
            InitText();
            Start();
            Finish();
        }

        public void InitCoins()
        {
            for (int i = 0; i < _total; i++)
            {
                if (i < _silver)
                {
                    Coin coin = new Coin(Side.silver);
                    Table.Coins.Add(coin);
                }
                else
                {
                    Coin coin = new Coin(Side.gold);
                    Table.Coins.Add(coin);
                }
            }
            //shuffle array
            Table.Coins = _table.Coins.OrderBy(_ => _rnd.Next()).ToList();
        }

        public void Start()
        {
            do
            {
                Console.WriteLine("what would you like to do ?");
                _userInput = Console.ReadLine();
                _result = Act(_userInput);
                Console.WriteLine(_result);
            } while (_result != "Game ended");
        }

        public void InitText()
        {
            Console.WriteLine("Coins problem \n");
            Console.WriteLine("silver coins: " + _silver + ", gold coins: " + _gold + "\n");
            Console.WriteLine("There are two stacks. Left and right.\nMove or flip coins in order to get the same amount of silver coins in each stack.\ngold coins are unimportant.\nall coins must be used. \n");
            Console.WriteLine(" 1. move X coins to left stack \n 2. move X coins to right stack \n 3. flip coins in left stack \n 4. flip coins in right stack \n type 'finish' to finish the game \n");
        }

        public void Finish()
        {
            //print
            Console.WriteLine("\n \n \n ");
            Console.WriteLine("Left stack: \n");
            Table.PrintTable(Table.Left);

            Console.WriteLine("Right stack: \n");
            Table.PrintTable(Table.Right);

            Console.WriteLine("Unused coins: \n");
            Table.PrintTable(Table.Coins);
        }

        public string Act(string choice)
        {
            int numberOfCoins = 0;
            string result = "Game ended";

            switch (choice)
            {
                case "1":
                    Console.WriteLine("how many coins?");
                    numberOfCoins = int.Parse(Console.ReadLine());
                    result = Table.MoveCoinsToStack(numberOfCoins, Table.Left);
                    return result;
                case "2":
                    Console.WriteLine("how many coins?");
                    numberOfCoins = int.Parse(Console.ReadLine());
                    result = Table.MoveCoinsToStack(numberOfCoins, Table.Right);
                    return result;
                case "3":
                    Console.WriteLine("how many coins?");
                    numberOfCoins = int.Parse(Console.ReadLine());
                    result = Table.FlipCoinsInStack(numberOfCoins, Table.Left);
                    return result;
                case "4":
                    Console.WriteLine("how many coins?");
                    numberOfCoins = int.Parse(Console.ReadLine());
                    result = Table.FlipCoinsInStack(numberOfCoins, Table.Right);
                    return result;
                case "finish":
                    return result;
                default:
                    return "invalid choice . choose again \n";
            }
        }
    }
}
