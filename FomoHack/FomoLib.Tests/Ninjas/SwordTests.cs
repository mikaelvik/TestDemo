using FluentAssertions;
using FomoLib.Ninjas;
using NUnit.Framework;

namespace FomoLib.Tests.Ninjas
{
    [TestFixture]
    public class SwordTests
    {
        [SetUp]
        public void Init()
        {
            _sword = new Sword();
        }

        private Sword _sword;

        [Test]
        public void Attack_Should_Mangle_Target()
        {
            var target = "Morten";
            var result = _sword.Hit(target);
            result.Should().Match("Slice*in half*")
                .And.Contain(target);
        }
    }
}