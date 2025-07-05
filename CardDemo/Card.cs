namespace CardGame
{
    public class Card
    {
        public string Suit { get; set; }
        public string Rank { get; set; }
        public int Value { get; set; }

        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }
    }
}