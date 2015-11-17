using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using TestDemo.Controllers;

namespace TestDemo.Tests.Controllers
{
    [TestFixture]
    public class ValuesControllerTests
    {
        [SetUp]
        public void Init()
        {
            _vc = new ValuesController();
            _vc.Post("value1");
            _vc.Post("value2");
            _vc.Post("value3");
        }

        private const string NewValue = "hei";
        private ValuesController _vc;

        [Test]
        public void Posted_Value_ShouldBeFound_OnGet()
        {
            var originalCount = _vc.Get().Count();
            _vc.Post(NewValue);

            // vanilla NUnit
            Assert.That(_vc.Get(), Has.Member(NewValue));
            Assert.That(_vc.Get().Count(), Is.EqualTo(originalCount + 1));

            // FluentAssertions 
            _vc.Get()
                .Should().Contain(NewValue)
                .And.HaveCount(originalCount + 1);
        }

        [Test]
        public void Put_ShouldChange_Value()
        {
            var original = _vc.Get(1);

            _vc.Put(1, NewValue);

            // vanilla NUnit
            Assert.That(_vc.Get(), Has.Member(NewValue));
            Assert.That(_vc.Get(), Has.No.Member(original));
            Assert.That(_vc.Get(1), Is.EqualTo(NewValue));

            // FluentAssertions
            _vc.Get()
                .Should().Contain(NewValue)
                .And.NotContain(original)
                .And.HaveElementAt(1, NewValue);
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
    }
}