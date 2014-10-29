using LogAnalyzer.Impl;
using LogAnalyzer.Impl.Bootstrapper;
using LogAnalyzer.Impl.Visitors;

namespace LogAnalyzer.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = args[0];
            IObjectFactory factory = Ioc.Initialize();

            ILinesFile file = factory.Resolve<ILinesFile>(new []{ fileName});
            ILongestRequestVisitor longestRequestVisitor = factory.Resolve<ILongestRequestVisitor>();

            file.AcceptVisitor(longestRequestVisitor);

            System.Console.WriteLine(longestRequestVisitor.LongestRequest);

            System.Console.ReadLine();
        }
    }
}
