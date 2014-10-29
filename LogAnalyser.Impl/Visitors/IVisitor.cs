using LogAnalyzer.Impl.Bo;

namespace LogAnalyzer.Impl.Visitors
{
    public interface IVisitor
    {
        void Visit(string line);
    }
}