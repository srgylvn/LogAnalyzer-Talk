namespace LogAnalyzer.Impl.Visitors
{
    public interface ILongestRequestVisitor : IVisitor
    {
        string LongestRequest { get; }
        int LongestRequestLength { get; }
    }
}