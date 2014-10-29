namespace LogAnalyzer.Impl.Bootstrapper
{
    public class ObjectLocator : IObjectLocator
    {
        public string CreateLocator<T>()
        {
            return typeof (T).FullName;
        }

        public static IObjectLocator DefaultLocator
        {
            get { return new ObjectLocator(); }
        }
    }
}