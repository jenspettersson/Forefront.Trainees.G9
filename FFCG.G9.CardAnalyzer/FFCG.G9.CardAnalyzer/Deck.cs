using System;
using System.Collections.Generic;
using System.Linq;

namespace FFCG.G9.CardAnalyzer
{
    public class Deck : IDeck
    {
        private readonly Stack<Card> _cards;
        private readonly IEnumerable<Card> _original;
        private readonly Random _rnd;

        public Deck(IEnumerable<Card> cards)
        {
            _original = cards;
            _cards = new Stack<Card>(_original);
            _rnd = new Random();
        }

        public Card Draw()
        {
            return _cards.Pop();
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
            _cards.Clear();

            foreach (var card in _original.OrderBy(x => _rnd.Next()))
            {
                _cards.Push(card);
            }
        }
    }
}