using System;
using System.Collections.Generic;

namespace LogAnalyzer.Impl.Bootstrapper
{
    public class ObjectFactory : IObjectFactory
    {
        public static Dictionary<string, Func<object[], object>> DefaultStorage
        {
            get { return new Dictionary<string, Func<object[], object>>(); }
        }

        private Dictionary<string, Func<object[], object>> _ctors;
        private IObjectLocator _objectLocator;
        public ObjectFactory(Dictionary<string, Func<object[], object>> ctorsStorage, IObjectLocator objectLocator)
        {
            _ctors = ctorsStorage;
            _objectLocator = objectLocator;
        }
        public ObjectFactory()
            : this(ObjectFactory.DefaultStorage, ObjectLocator.DefaultLocator)
        {
        }

        public void Bind<T>(Func<object[], T> ctor)
        {
            _ctors.Add(_objectLocator.CreateLocator<T>(), (p) => (object)ctor.Invoke(p));
        }

        public T Resolve<T>(string[] parameters)
        {
            return (T) (_ctors[_objectLocator.CreateLocator<T>()].Invoke(parameters));
        }

        public T Resolve<T>()
        {
            return Resolve<T>(null);
        }
    }
}