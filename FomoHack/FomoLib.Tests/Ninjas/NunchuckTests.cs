using FluentAssertions;
using FomoLib.Ninjas;
using NUnit.Framework;

namespace FomoLib.Tests.Ninjas
{
    [TestFixture]
    public class NunchuckTests
    {
        [SetUp]
        public void Init()
        {
            _nunchuck = new Nunchuck();
        }

        private Nunchuck _nunchuck;

        [TestCase("Sindre", "Las Vegas")]
        [TestCase("Anders", "Nordpolen")]
        [TestCase("Kenneth", "Nowhere")]
        [TestCase("Kjetil", "Nowhere")]
        public void Nunchuck_Should_Move_Sindre_To_LasVegas(string target, string city)
        {
            var result = _nunchuck.Hit(target);
            result.Should().Contain(city)
                .And.Contain(target);
        }
    }
}