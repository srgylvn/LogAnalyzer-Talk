using System;
using System.Collections.Generic;
using LogAnalyzer.Impl.Visitors;

namespace LogAnalyzer.Impl.Bootstrapper
{
    public static class Ioc
    {
        public static IObjectFactory Initialize()
        {
            var of = new ObjectFactory();

            RegisterBindings(of);

            return of;
        }

        private static void RegisterBindings(ObjectFactory of)
        {
            of.Bind<ILinesFile>((p) => new LinesFile((string)p[0]));
            of.Bind<ILongestRequestVisitor>((p) => new LongestRequestVisitor());
        }
    }
}