using FluentAssertions;
using FomoLib.Ninjas;
using NUnit.Framework;

namespace FomoLib.Tests.Ninjas
{
    [TestFixture]
    public class PeasantTests
    {
        [Test]
        public void Peasant_Should_Be_Damaged()
        {
            var peasant = new Peasant(10);
            peasant.Defend(5).Should().Be(true);
            peasant.Defend(3).Should().Be(true);
            peasant.Defend(3).Should().Be(false);
        }
    }
}