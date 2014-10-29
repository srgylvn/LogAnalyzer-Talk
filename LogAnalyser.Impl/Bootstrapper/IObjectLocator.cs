namespace LogAnalyzer.Impl.Bootstrapper
{
    public interface IObjectLocator
    {
        string CreateLocator<T>();
    }
}