using System.Xml.Schema;
using LogAnalyzer.Impl.Bo;

namespace LogAnalyzer.Impl.Visitors
{
    public class LongestRequestVisitor : ILongestRequestVisitor
    {
        public void Visit(string line)
        {
            if (line.StartsWith("#"))
                return;

            string[] parts = line.Split(' ');
            var length = int.Parse(parts[parts.Length - 1]);

            if (length > LongestRequestLength)
            {
                LongestRequest = line;
                LongestRequestLength = length;
            }
        }

        public string LongestRequest { get; private set; }
        public int LongestRequestLength { get; private set; }
    }
}