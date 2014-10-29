using System;
using System.Collections.Generic;
using FakeItEasy;
using LogAnalyzer.Impl.Bootstrapper;
using NUnit.Framework;

namespace LogAnalyzer.Impl.Tests.Bootstrapper
{
    [TestFixture]
    public class ObjectFactoryTests
    {
        private Dictionary<string, Func<object[], object>> _mockDict;
        private IObjectLocator _stubLocator;
        private string _stringClassLocator;

        [SetUp]
        public void Setup()
        {
            _stringClassLocator = "stringClassLocator";

            _mockDict = new Dictionary<string, Func<object[], object>>();
            _stubLocator = A.Fake<IObjectLocator>();

            A.CallTo(() => _stubLocator.CreateLocator<string>()).Returns(_stringClassLocator);
        }

        ObjectFactory CreateFactory()
        {
            return new ObjectFactory(_mockDict, _stubLocator);
        }

        [Test]
        public void Bind_SavedInMap()
        {
            var factory = CreateFactory();

            factory.Bind<string>((p) => "test");

            Assert.That(_mockDict.ContainsKey(_stringClassLocator), Is.True);
        }

        [Test]
        public void Resolve_CallsFuncCtor()
        {
            var factory = CreateFactory();
            bool isCalled = false;
            factory.Bind<string>((p) =>
            {
                isCalled = true;
                return "test";
            });

            factory.Resolve<string>(null);

            Assert.That(isCalled, Is.True);
        }

        [Test]
        public void Resolve_UsesLocator()
        {
            var factory = CreateFactory();           
            factory.Bind<string>((p) => "test");

            factory.Resolve<string>(null);

            A.CallTo(() => _stubLocator.CreateLocator<string>()).MustHaveHappened();
        }

        [Test]
        public void Resolve_RetutnsRegisteredIstance()
        {
            var factory = CreateFactory();
            factory.Bind<string>((p) => "test");

            var str = factory.Resolve<string>(null);

            Assert.That(str, Is.EqualTo("test"));
        }
    }
}