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
        }

        private Ninja _ninja;
        private Mock<IWeapon> _wMock;

        [Test]
        public void Fail_When_Arming_Without_Weapon()
        {
            Assert.Catch<DisgruntledNinja>(() => _ninja.Arm(null));

            Action act = () => _ninja.Arm(null);
            act.ShouldThrow<DisgruntledNinja>()
                .WithMessage("?*hell no*");
        }

        [Test]
        public void Should_Accept_And_Attack_With_Weapon()
        {
            _wMock.Setup(w => w.Hit(It.IsAny<string>())).Returns(true).Verifiable();
            _ninja.Arm(_wMock.Object);

            _ninja.Attack("Morten");

            _wMock.Verify();
        }
    }
}