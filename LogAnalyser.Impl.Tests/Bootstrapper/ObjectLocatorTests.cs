using LogAnalyzer.Impl.Bootstrapper;
using NUnit.Framework;

namespace LogAnalyzer.Impl.Tests.Bootstrapper
{
    [TestFixture]
    public class ObjectLocatorTests
    {
        public ObjectLocator CreateObjectLocator()
        {
            return new ObjectLocator();
        }

        [Test]
        public void CreateLocator_ByTypeName()
        {
            var locator = CreateObjectLocator();

            var id = locator.CreateLocator<string>();

            Assert.That(id, Is.EqualTo(typeof(string).FullName));
        }
    }
}