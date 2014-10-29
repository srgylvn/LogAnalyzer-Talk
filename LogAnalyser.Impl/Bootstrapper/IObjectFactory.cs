namespace LogAnalyzer.Impl.Bootstrapper
{
    public interface IObjectFactory
    {
        T Resolve<T>(string[] patrameters);
        T Resolve<T>();
    }
}