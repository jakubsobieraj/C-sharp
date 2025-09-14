using System;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Blackjack
{
	public class BlackjackGame : Game, IWalkAway


	{
		public BlackjackDealer Dealer { get; set; }
		
		public override void Play()
		{
			Dealer = new BlackjackDealer();
			foreach (Player player in Players)
			{
				player.Hand = new List<Card>();
				player.Stay = false;
			}
			Dealer.Hand = new List<Card>();
			Dealer.Stay = false;
			Dealer.Deck = new Deck();
			Console.WriteLine("Place your bet:");

			foreach (Player player in Players)
			{
				int bet = Convert.ToInt32(Console.ReadLine());
				bool successfulBet = player.Bet(bet);
				if (!successfulBet)
				{
					return;
				}
				Bets[player] = bet;
			}

			string answer = string.Empty;

            for (int i = 0; i < 2; i++)
			{
				Console.WriteLine("Dealing...");
				foreach (Player player in Players)
				{
					Console.Write("{0}: ", player.Name);
					Dealer.Deal(player.Hand);
					if (i == 1)
					{
						bool blackJack = BlackjackRules.CheckForBlackjack(player.Hand);
                        if (blackJack)
                        {
							Console.WriteLine("Blackjack! {0} wins {1}", player.Name, Bets[player]);
							player.Balance += Convert.ToInt32((Bets[player] + 1.5) + Bets[player]);
							return;
                        }
                    }
				}
				Console.Write("Dealer: ");
				Dealer.Deal(Dealer.Hand);
				if (i == 1)
				{
					bool blackJack = BlackjackRules.CheckForBlackjack(Dealer.Hand);
					if (blackJack)
					{
						Console.WriteLine("Dealer has blackjack. You lose.");
						foreach (KeyValuePair<Player, int> entry in Bets)
						{
							Dealer.Balance += entry.Value;
						}
					}
				}
			}
           
            foreach (Player player in Players)
			{
				while (!player.Stay)
				{
					Console.WriteLine("Your cards are: ");
					foreach (Card card in player.Hand)
					{
						Console.Write("{0} ", card.ToString());
					}
					Console.WriteLine("\n\nHit or stay?");
					answer = Console.ReadLine().ToLower();
					if (answer == "stay")
					{
						player.Stay = true;
						break;
					}
					else if (answer == "hit")
					{
						Dealer.Deal(player.Hand);
					}
				bool busted = BlackjackRules.isBusted(player.Hand);

					if (busted)
					{
						Dealer.Balance += Bets[player];
						Console.WriteLine("{0} Busted! You lose {1}. Balance is now {2}, ", player.Name, Bets[player], player.Balance);
						Console.WriteLine("Do you want to play again? If yes, type: y");
                        answer = Console.ReadLine().ToLower();

                        if (answer == "y")
						{
							player.IsActivelyPlaying = true;
							return;
						}
						else
						{
							player.IsActivelyPlaying = false;
							return;

						}
                    }
				}
			}

			Dealer.isBusted = BlackjackRules.isBusted(Dealer.Hand);
			Dealer.Stay = BlackjackRules.ShouldDealerStay(Dealer.Hand);
			while (!Dealer.Stay && !Dealer.isBusted)
			{
				Console.WriteLine("Dealer plays hit");
				Dealer.Deal(Dealer.Hand);
				Dealer.isBusted = BlackjackRules.isBusted(Dealer.Hand);
				Dealer.Stay = BlackjackRules.ShouldDealerStay(Dealer.Hand);
			}
			if (Dealer.Stay)
			{
				Console.WriteLine("Dealer plays stay.");
			}
            if (Dealer.isBusted)
            {
                Console.WriteLine("Dealer busts.");
				foreach (KeyValuePair<Player, int> entry in Bets)
				{
					Console.WriteLine("{0} wins {1}. ", entry.Key.Name, entry.Value);
					Players.Where(x => x.Name == entry.Key.Name).First().Balance += (entry.Value * 2);
					Dealer.Balance -= entry.Value;
				}
				return;
            }
			foreach (Player player in Players)
			{
				bool? playerWon = BlackjackRules.CompareHands(player.Hand, Dealer.Hand);
                if (playerWon == null)
                {
					Console.WriteLine("Push. No one wins.");
					player.Balance += Bets[player];
                }
				else if (playerWon == true)
				{
					Console.WriteLine("{0} won {1}.", player.Name, Bets[player]);player.Balance += Bets[player];
                    player.Balance += (Bets[player] * 2);
                    Dealer.Balance -= Bets[player];
                }
				else
				{
					Console.WriteLine("Dealer wins {0}.", Bets[player]);
					Dealer.Balance += Bets[player];

				}
                Console.WriteLine("Play again? If yes, type: y");
                answer = Console.ReadLine().ToLower();
                if (answer == "y")
                {
                    player.IsActivelyPlaying = true;
                    return;
                }
                else
                {
                    player.IsActivelyPlaying = false;
                    return;
                }
            }
        }
		
        public override void ListPlayers()
		{
			Console.WriteLine("Blackjack players:");
			base.ListPlayers();
		}
		public void WalkAway(Player player)
		{
            throw new NotImplementedException();
        }
    }
}