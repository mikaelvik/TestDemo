using System;
using System.Linq;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using TestDemo.Controllers;
using TestDemo.Validators;

namespace TestDemo.Tests.Controllers
{
    [TestFixture]
    public class ValuesControllerTests
    {
        [SetUp]
        public void Init()
        {
            _vvMock.Setup(vv => vv.Validate(It.IsAny<string>())).Returns(true);

            _vc = new ValuesController(_vvMock.Object);

            _vc.Post("value1");
            _vc.Post("value2");
            _vc.Post("value3");
            _vc.Post("value4");
        }

        private const string NewValue = "hei";

        private readonly Mock<ValuesValidator> _vvMock = new Mock<ValuesValidator>();
        private ValuesController _vc;

        [Test]
        public void Delete_ShouldFail_WhenNoSuchValue()
        {
            Assert.Catch<ArgumentOutOfRangeException>(
                () => _vc.Delete(_vc.Get().Count() + 1));
        }

        [Test]
        public void Delete_ShouldRemove_Value()
        {
            var originalSize = _vc.Get().Count();
            var value = _vc.Get(0);

            _vc.Delete(0);

            // vanilla NUnit
            Assert.That(_vc.Get().Count(), Is.EqualTo(originalSize - 1));
            Assert.That(_vc.Get(), Has.No.Member(value));

            // FluentAssertions
            _vc.Get()
                .Should().HaveCount(originalSize - 1)
                .And.NotContain(value);
        }

        [Test]
        public void InvalidValue_ShouldBeRejected()
        {
            _vvMock.Setup(vv => vv.Validate(It.IsAny<string>())).Returns(false).Verifiable();
            _vvMock.Setup(vv => vv.DontCallThis(It.IsAny<string>())).Returns(false);

            _vc.Post(NewValue);

            _vc.Get().Should().NotContain(NewValue);
            _vvMock.Verify();
        }

        [Test]
        public void Posted_Value_ShouldBeFound_OnGet()
        {
            var originalCount = _vc.Get().Count();

            _vc.Post(NewValue);

            _vvMock.Verify(vv => vv.Validate(NewValue));
            _vc.Get()
                .Should().Contain(NewValue)
                .And.HaveCount(originalCount + 1);
        }

        [Test]
        public void Put_ShouldChange_Value()
        {
            var original = _vc.Get(1);

            _vc.Put(1, NewValue);

            _vc.Get()
                .Should().Contain(NewValue)
                .And.NotContain(original)
                .And.HaveElementAt(1, NewValue);
        }

        [Test]
        public void Put_ShouldFail_WhenNoSuchId()
        {
            Assert.Catch<ArgumentOutOfRangeException>(
              () => _vc.Put(-1, null));
        }
    }
}
