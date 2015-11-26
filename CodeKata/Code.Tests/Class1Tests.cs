using NUnit.Framework;

namespace Code.Tests
{
    [TestFixture]
    public class Class1Tests
    {
        [SetUp]
        public void Init()
        {
            _class1 = new Class1();
        }

        private Class1 _class1;

        [Test]
        public void Empty_Test()
        {
            Assert.That(_class1, Is.Not.Null);
        }
    }
}