using System.Collections.Generic;
using FFCG.G9.CardAnalyzer.Rule;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G9.CardAnalyzer.Tests
{
    [TestFixture]
    public class StraightFlushTests
    {
        private StraightFlush _straightFlush;

        [SetUp]
        public void Setup()
        {
            _straightFlush = new StraightFlush();
        }
        
        [Test]
        public void Should_match_if_given_a_straight_with_same_suit()
        {
            var matches = _straightFlush.Matches(new List<Card>
            {
                new(2, Suit.Clubs),
                new(3, Suit.Clubs),
                new(4, Suit.Clubs),
                new(5, Suit.Clubs),
                new(6, Suit.Clubs)
            });

            matches.Should().BeTrue();
        }
        
        [Test]
        public void Should_not_match_if_given_a_straight_with_different_suit()
        {
            var matches = _straightFlush.Matches(new List<Card>
            {
                new(2, Suit.Clubs),
                new(3, Suit.Hearts),
                new(4, Suit.Diamonds),
                new(5, Suit.Spades),
                new(6, Suit.Clubs)
            });

            matches.Should().BeFalse();
        }
        
        [Test]
        public void Should_not_match_if_not_given_a_straight_but_with_same_suit()
        {
            var matches = _straightFlush.Matches(new List<Card>
            {
                new(2, Suit.Clubs),
                new(7, Suit.Clubs),
                new(4, Suit.Clubs),
                new(9, Suit.Clubs),
                new(6, Suit.Clubs)
            });

            matches.Should().BeFalse();
        }
    }
}