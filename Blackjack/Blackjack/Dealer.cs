using System;
using static System.Net.Mime.MediaTypeNames;

namespace Blackjack
{
	public class Dealer
	{
        public string Name { get; set; }
        public Deck Deck { get; set; }
        public int Balance { get; set; }

		public void Deal(List<Card> Hand)
		{
			Hand.Add(Deck.Cards.First());
			string card = string.Format(Deck.Cards.First().ToString() + "\n");
            Console.WriteLine(card);
			using (StreamWriter file = new StreamWriter(@"F:\\OneDrive - University of Dundee\\Pitman\\C-sharp\\Blackjack\\Blackjack\\LOGS", true))
			{
				file.WriteLine(card);
			}
			Deck.Cards.RemoveAt(0);
		}
	}
}