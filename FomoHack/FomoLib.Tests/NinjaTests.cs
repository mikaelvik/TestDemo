using System;
using FluentAssertions;
using FomoLib.Error;
using Moq;
using NUnit.Framework;

namespace FomoLib.Tests
{
    [TestFixture]
    public class NinjaTests
    {
        [SetUp]
        public void Init()
        {
            _ninja = new Ninja();
            _wMock = new Mock<IWeapon>();

            _ninja.Arm(_wMock.Object);
        }

        private Ninja _ninja;
        private Mock<IWeapon> _wMock;

        [Test]
        public void Fail_When_Arming_Without_Weapon()
        {
            // vanilla NUnit
            Assert.Catch<DisgruntledNinja>(() => _ninja.Arm(null));

            // FluentAssertions
            Action act = () => _ninja.Arm(null);
            act.ShouldThrow<DisgruntledNinja>()
                .WithMessage("?*hell no*");
        }

        [Test]
        public void Should_Accept_And_Attack_With_Weapon()
        {
            var mockAttack = "mock attack";
            var target = "Morten";
            _wMock.Setup(w => w.Hit(It.IsAny<string>())).Returns(mockAttack);

            var attack = _ninja.Attack(target);

            attack.Should().Contain(mockAttack);
            _wMock.Verify(w => w.Hit(target));
        }
    }
}