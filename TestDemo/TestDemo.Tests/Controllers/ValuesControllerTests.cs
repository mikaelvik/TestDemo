using System.Linq;
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
        }

        private const string NewValue = "hei";
        private ValuesController _vc;

        [Test]
        public void Posted_Value_ShouldBeFound_OnGet()
        {
            var originalCount = _vc.Get().Count();
            _vc.Post(NewValue);

            Assert.That(_vc.Get(), Has.Member(NewValue));
            Assert.That(_vc.Get().Count(), Is.EqualTo(originalCount + 1));
        }

        [Test]
        public void Put_ShouldChange_Value()
        {
            var original = _vc.Get(1);

            _vc.Put(1, NewValue);

            Assert.That(_vc.Get(), Has.Member(NewValue));
            Assert.That(_vc.Get(), Has.No.Member(original));
            Assert.That(_vc.Get(1), Is.EqualTo(NewValue));
        }

        [Test]
        public void Delete_ShouldRemove_Value()
        {
            var originalSize = _vc.Get().Count();
            var value = _vc.Get(0);

            _vc.Delete(0);

            Assert.That(_vc.Get().Count(), Is.EqualTo(originalSize - 1));
            Assert.That(_vc.Get(), Has.No.Member(value));
        }
    }
}