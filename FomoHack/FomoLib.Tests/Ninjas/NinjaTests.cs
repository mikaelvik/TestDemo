using System;
using FluentAssertions;
using FomoLib.Ninjas;
using FomoLib.Ninjas.Errors;
using FomoLib.Ninjas.Weapons;
using Moq;
using NUnit.Framework;

namespace FomoLib.Tests.Ninjas
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
            _wMock.Setup(w => w.Hit(It.IsAny<string>())).Returns(mockAttack).Verifiable();

            var attack = _ninja.Attack(target);

            attack.Should().Contain(mockAttack);
            _wMock.Verify(w => w.Hit(target));
            _wMock.Verify();
        }

        [TestCase("Sindre")]
        [TestCase("Brita")]
        public void Should_Attack(string target)
        {
            _ninja.Attack(target);
            _wMock.Verify(w => w.Hit(target));
        }

        [TestCase(100, 10, true)]
        [TestCase(11, 10, true)]
        [TestCase(10, 10, false)]
        [TestCase(9, 10, false)]
        public void Ninja_Should_Defend_When_Attacked(int lifeForce, int damage, bool survived)
        {
            _ninja = new Ninja(lifeForce);

            _ninja.Defend(damage)
                .Should().Be(survived);
        }

        [Test]
        public void Ninja_Should_Suffer_Damage_When_Attacked_Several_Times()
        {
            _ninja = new Ninja(100);
            _ninja.Defend(50).Should().Be(true);
            _ninja.Defend(50).Should().Be(false);
        }
    }
}