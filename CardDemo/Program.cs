using System;
using System.Collections.Generic;
using System.Threading;

namespace CardGame
{
    class Card
    {
        public string Suit { get; set; }
        public string Rank { get; set; }
        public int Value { get; set; }

        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }
    }

    class Program
    {
        static List<Card> CreateDeck()
        {
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            Dictionary<string, int> ranks = new Dictionary<string, int>
            {
                {"2", 2}, {"3", 3}, {"4", 4}, {"5", 5}, {"6", 6},
                {"7", 7}, {"8", 8}, {"9", 9}, {"10", 10},
                {"J", 11}, {"Q", 12}, {"K", 13}, {"A", 14}
            };

            List<Card> deck = new List<Card>();

            foreach (string suit in suits)
            {
                foreach (KeyValuePair<string, int> rank in ranks)
                {
                    deck.Add(new Card
                    {
                        Suit = suit,
                        Rank = rank.Key,
                        Value = rank.Value
                    });
                }
            }

            return deck;
        }

        static List<Card> Shuffle_Deck(List<Card> deck)
        {
            Random rand = new Random();
            List<Card> copy = new List<Card>(deck);
            List<Card> shuffled = new List<Card>();

            while (copy.Count > 0)
            {
                int index = rand.Next(copy.Count);
                shuffled.Add(copy[index]);
                copy.RemoveAt(index);
            }

            return shuffled;
        }

        static void DealCards(List<Card> deck, out List<Card> player1, out List<Card> player2)
        {
            player1 = deck.GetRange(0, 26);
            player2 = deck.GetRange(26, 26);
        }

        static void PlayRound(List<Card> player1, List<Card> player2)
        {
            Card card1 = player1[0];
            Card card2 = player2[0];
            player1.RemoveAt(0);
            player2.RemoveAt(0);

            Console.WriteLine($"Player 1 plays: {card1}");
            Console.WriteLine($"Player 2 plays: {card2}");

            if (card1.Value > card2.Value)
            {
                Console.WriteLine("Player 1 wins this round\n");
                player1.Add(card1);
                player1.Add(card2);
            }
            else if (card2.Value > card1.Value)
            {
                Console.WriteLine("Player 2 wins this round\n");
                player2.Add(card2);
                player2.Add(card1);
            }
            else
            {
                Console.WriteLine("It's a draw – cards lost\n");
            }
        }

        static void PlayGame()
        {
            List<Card> deck = Shuffle_Deck(CreateDeck());
            DealCards(deck, out List<Card> player1, out List<Card> player2);

            int round = 0;
            while (player1.Count > 0 && player2.Count > 0 && round < 30)
            {
                Console.WriteLine($"\n--- Round {round + 1} ---");
                PlayRound(player1, player2);
                Thread.Sleep(500);
                round++;
            }

            Console.WriteLine("\nGame Over");
            Console.WriteLine($"Player 1 cards: {player1.Count}");
            Console.WriteLine($"Player 2 cards: {player2.Count}");

            if (player1.Count > player2.Count)
            {
                Console.WriteLine("🏆 Player 1 Wins!");
            }
            else if (player2.Count > player1.Count)
            {
                Console.WriteLine("🏆 Player 2 Wins!");
            }
            else
            {
                Console.WriteLine("🤝 It's a draw!");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Card Game!");
            PlayGame();
        }
    }
}
