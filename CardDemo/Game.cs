using System;
using System.Threading;

namespace CardGame
{
    public class Game
    {
        private Player player1;
        private Player player2;

        public void Start()
        {
            Deck deck = new Deck();
            deck.Shuffle();

            player1 = new Player("Player 1", deck.Deal(26));
            player2 = new Player("Player 2", deck.Deal(26));

            int round = 0;
            while (player1.Hand.Count > 0 && player2.Hand.Count > 0 && round < 30)
            {
                Console.WriteLine($"\n--- Round {round + 1} ---");
                PlayRound();
                Thread.Sleep(500);
                round++;
            }

            Console.WriteLine("\nGame Over");
            Console.WriteLine($"{player1.Name} cards: {player1.Hand.Count}");
            Console.WriteLine($"{player2.Name} cards: {player2.Hand.Count}");

            if (player1.Hand.Count > player2.Hand.Count)
                Console.WriteLine("🏆 Player 1 Wins!");
            else if (player2.Hand.Count > player1.Hand.Count)
                Console.WriteLine("🏆 Player 2 Wins!");
            else
                Console.WriteLine("🤝 It's a draw!");
        }

        private void PlayRound()
        {
            Card card1 = player1.PlayCard();
            Card card2 = player2.PlayCard();

            Console.WriteLine($"{player1.Name} plays: {card1}");
            Console.WriteLine($"{player2.Name} plays: {card2}");

            if (card1.Value > card2.Value)
            {
                Console.WriteLine($"{player1.Name} wins this round\n");
                player1.AddCards(card1, card2);
            }
            else if (card2.Value > card1.Value)
            {
                Console.WriteLine($"{player2.Name} wins this round\n");
                player2.AddCards(card2, card1);
            }
            else
            {
                Console.WriteLine("It's a draw – cards lost\n");
            }
        }
    }
}