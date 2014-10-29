using System;
using LogAnalyzer.Impl.Visitors;
using NUnit.Framework;

namespace LogAnalyzer.Impl.Tests
{
    [TestFixture]
    public class LongestRequestVisitorTests
    {
        private string[] _requestString =
        {
            "2014-09-16 04:57:47 ::1 GET / - 8080 - ::1 Mozilla/5.0+(Windows+NT+6.3;+WOW64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/37.0.2062.120+Safari/537.36 - 200 0 0 21714",
            "2014-09-16 04:57:47 ::1 GET /bundles/bootstrap v=2Fz3B0iizV2NnnamQFrx-NbYJNTFeBJ2GM05SilbtQU1 8080 - ::1 Mozilla/5.0+(Windows+NT+6.3;+WOW64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/37.0.2062.120+Safari/537.36 http://localhost:8080/ 200 0 0 21722"
        };

        private LongestRequestVisitor CreateVisitor()
        {
            return new LongestRequestVisitor();
        }

        [Test]
        public void Visit_GetsLastNUmberFromLine()
        {
            var visitor = CreateVisitor();

            visitor.Visit(_requestString[0]);

            Assert.That(visitor.LongestRequest, Is.EqualTo(_requestString[0]));
            Assert.That(visitor.LongestRequestLength, Is.EqualTo(21714));
        }

        [Test]
        public void Visit_FindsTheLongest()
        {
            var visitor = CreateVisitor();

            visitor.Visit(_requestString[0]);
            visitor.Visit(_requestString[1]);

            Assert.That(visitor.LongestRequest, Is.EqualTo(_requestString[1]));
            Assert.That(visitor.LongestRequestLength, Is.EqualTo(21722));
        }

        [Test]
        public void Visit_PassesComentLines()
        {
            var visitor = CreateVisitor();

            visitor.Visit("#Comment line");

            Assert.That(visitor.LongestRequest, Is.Null.Or.Empty);
        }
    }
}