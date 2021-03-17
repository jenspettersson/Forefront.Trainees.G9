using System.Collections.Generic;
using FFCG.G9.CardAnalyzer.Rule;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G9.CardAnalyzer.Tests
{
    [TestFixture]
    public class RoyalStraightFlushTests
    {
        private RoyalStraightFlush _royalStraightFlush;

        [SetUp]
        public void Setup()
        {
            _royalStraightFlush = new RoyalStraightFlush();
        }
        
        [Test]
        public void Should_match_if_given_a_royal_straight_flush()
        {
            var matches = _royalStraightFlush.Matches(new List<Card>
            {
                new(10, Suit.Hearts),
                new(11, Suit.Hearts),
                new(12, Suit.Hearts),
                new(13, Suit.Hearts),
                new(14, Suit.Hearts)
            });

            matches.Should().BeTrue();
        }
    }
}