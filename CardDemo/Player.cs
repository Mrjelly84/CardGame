using System.Collections.Generic;

namespace CardGame
{
    public class Player
    {
        public string Name { get; }
        public List<Card> Hand { get; }

        public Player(string name, List<Card> hand)
        {
            Name = name;
            Hand = hand;
        }

        public Card PlayCard()
        {
            if (Hand.Count == 0) return null;
            Card card = Hand[0];
            Hand.RemoveAt(0);
            return card;
        }

        public void AddCards(params Card[] cards)
        {
            Hand.AddRange(cards);
        }
    }
}