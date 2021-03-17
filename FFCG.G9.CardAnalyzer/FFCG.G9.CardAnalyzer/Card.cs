namespace FFCG.G9.CardAnalyzer
{
    public class Card
    {
        public int Number { get; }
        public Suit Suit { get; }

        public Card(int number, Suit suit)
        {
            Number = number;
            Suit = suit;
        }

        public override string ToString()
        {
            var description = Number.ToString();

            if (Number > 10)
            {
                switch (Number)
                {
                    case 11:
                        description = "Knight";
                        break;
                    case 12:
                        description = "Queen";
                        break;
                    case 13:
                        description = "King";
                        break;
                    case 14:
                        description = "Ace";
                        break;
                }
            }

            return $"{description} of {Suit.ToString()}";
        }
    }
}