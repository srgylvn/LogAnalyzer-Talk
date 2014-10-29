using System.IO;
using LogAnalyzer.Impl.Visitors;

namespace LogAnalyzer.Impl
{
    public class LinesFile : ILinesFile
    {
        private string _path;
        public LinesFile(string path)
        {
            _path = path;
        }

        public void AcceptVisitor(IVisitor visitor)
        {
            using (var reader = new StreamReader(_path))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    visitor.Visit(line);
                }
            }
        }
    }
}