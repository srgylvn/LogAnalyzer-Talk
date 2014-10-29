using LogAnalyzer.Impl.Visitors;

namespace LogAnalyzer.Impl
{
    public interface ILinesFile
    {
        void AcceptVisitor(IVisitor visitor);
    }
}