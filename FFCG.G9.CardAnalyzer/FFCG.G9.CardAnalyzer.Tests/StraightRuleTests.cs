using System.Collections.Generic;
using FFCG.G9.CardAnalyzer.Rule;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G9.CardAnalyzer.Tests
{
    [TestFixture]
    public class StraightRuleTests
    {
        private Straight _straight;

        [SetUp]
        public void Setup()
        {
            _straight = new Straight();
        }

        [Test]
        public void Should_match_if_given_a_straight_in_order()
        {
            bool matches = _straight.Matches(new List<Card>
            {
                new(2, Suit.Clubs),
                new(3, Suit.Hearts),
                new(4, Suit.Diamonds),
                new(5, Suit.Spades),
                new(6, Suit.Clubs)
            });

            matches.Should().BeTrue();
        }
        
        [Test]
        public void Should_match_if_given_a_straight_out_of_order()
        {
            bool matches = _straight.Matches(new List<Card>
            {
                new(3, Suit.Clubs),
                new(6, Suit.Hearts),
                new(4, Suit.Diamonds),
                new(2, Suit.Spades),
                new(5, Suit.Clubs)
            });

            matches.Should().BeTrue();
        }
        
        [Test]
        public void Should_not_match_if_not_given_a_straight()
        {
            bool matches = _straight.Matches(new List<Card>
            {
                new(3, Suit.Clubs),
                new(6, Suit.Hearts),
                new(10, Suit.Diamonds),
                new(7, Suit.Spades),
                new(5, Suit.Clubs)
            });

            matches.Should().BeFalse();
        }
    }
}