using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Blackjack. Let's start by telling me your name:");
            string playerName = Console.ReadLine();

            Console.WriteLine("How much money do you want to play with?");
            int bank = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Hello, {0}. Do you want to join a 21 game right now? to join, type: y" , playerName);
            string answer = Console.ReadLine().ToLower();

            if (answer == "y") 
            {
                Player player = new Player(playerName, bank);
                Game game = new BlackjackGame();
                game += player;
                player.IsActivelyPlaying = true;
                while (player.IsActivelyPlaying && player.Balance > 0)

                {
                    game.Play();
                }
                game -= player;
                Console.WriteLine("Thanks for the game.");
            }
            Console.WriteLine("Feel free to look around the casing.");
            Console.Read();
        }
    }
}
