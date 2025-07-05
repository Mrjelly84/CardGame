using System;
using System.Collections.Generic;

namespace CardGame
{
    public class Deck
    {
        private List<Card> cards;

        public Deck()
        {
            cards = new List<Card>();
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            Dictionary<string, int> ranks = new Dictionary<string, int>
            {
                {"2", 2}, {"3", 3}, {"4", 4}, {"5", 5}, {"6", 6},
                {"7", 7}, {"8", 8}, {"9", 9}, {"10", 10},
                {"J", 11}, {"Q", 12}, {"K", 13}, {"A", 14}
            };

            foreach (string suit in suits)
            {
                foreach (var rank in ranks)
                {
                    cards.Add(new Card
                    {
                        Suit = suit,
                        Rank = rank.Key,
                        Value = rank.Value
                    });
                }
            }
        }

        public void Shuffle()
        {
            Random rand = new Random();
            for (int i = cards.Count - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                var temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }

        public List<Card> Deal(int count)
        {
            var hand = cards.GetRange(0, count);
            cards.RemoveRange(0, count);
            return hand;
        }
    }
}