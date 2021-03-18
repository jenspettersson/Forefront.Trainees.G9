using System;
using System.Collections.Generic;
using System.Linq;

namespace FFCG.G9.CardAnalyzer
{
    public class Deck : IDeck
    {
        private readonly Card[] _cards;
        private readonly Random _rnd;
        private int _drawn;
        public Deck(IEnumerable<Card> cards)
        {
            _cards = cards.ToArray();
            _rnd = new Random();
            _drawn = 0;
        }

        public Card Draw()
        {
            return _cards[_drawn++];
        }

        public static Deck Default()
        {
            var cards = new List<Card>();
            foreach (var number in Enumerable.Range(2, 13))
            {
                cards.Add(new Card(number, Suit.Hearts));
                cards.Add(new Card(number, Suit.Clubs));
                cards.Add(new Card(number, Suit.Diamonds));
                cards.Add(new Card(number, Suit.Spades));
            }

            return new Deck(cards);
        }

        public void Shuffle()
        {
            _drawn = 0;

            // Fisher-Yates shuffle method
            for (int i = _cards.Length - 1; i > 0; --i)
            {
                var k = _rnd.Next(i + 1);
                var temp = _cards[i];
                _cards[i] = _cards[k];
                _cards[k] = temp;
            }
        }
    }
}