﻿using System;
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
            _nMock = new Mock<Weapon>();
        }

        private Ninja _ninja;
        private Mock<Weapon> _nMock;

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
            _ninja.Arm(_nMock.Object);

            _ninja.Attack("Morten");
        }
    }
}