using System.Collections.Generic;
using FFCG.G9.CardAnalyzer.Rule;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G9.CardAnalyzer.Tests
{
    [TestFixture]
    public class FlushRuleTests
    {
        private Flush _flush;

        [SetUp]
        public void Setup()
        {
            _flush = new Flush();
        }

        [Test]
        public void Should_match_if_given_cards_with_same_suit()
        {
            var matches = _flush.Matches(new List<Card>
            {
                new(4, Suit.Clubs),
                new(7, Suit.Clubs),
                new(9, Suit.Clubs),
                new(12, Suit.Clubs),
                new(2, Suit.Clubs)
            });

            matches.Should().BeTrue();
        }
        
        [Test]
        public void Should_not_match_if_given_cards_with_different_suit()
        {
            var matches = _flush.Matches(new List<Card>
            {
                new(4, Suit.Clubs),
                new(7, Suit.Hearts),
                new(9, Suit.Clubs),
                new(12, Suit.Clubs),
                new(2, Suit.Clubs)
            });

            matches.Should().BeFalse();
        }
    }
}