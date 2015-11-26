using FomoLib.Ninjas;
using NUnit.Framework;

namespace FomoLib.Tests.Ninjas
{
    [TestFixture]
    public class ShurikenTests
    {
        [SetUp]
        public void Init()
        {
            _shuriken = new Shuriken();
        }

        private Shuriken _shuriken;

        [Test]
        public void Should_Work()
        {
            var result = _shuriken.Hit("Mikael");
            Assert.That(result, Has.Length.GreaterThan(10));
        }
    }
}