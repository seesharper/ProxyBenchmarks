using Castle.DynamicProxy;
using BenchmarkDotNet.Attributes;
using static InterceptionBenchmarks.ProxyHelper;


namespace InterceptionBenchmarks
{
    public class InterfaceTests
    {
        private IFoo lightInjectProxy;
        private IFoo castleProxy;
        private IFoo linFuProxy;

        [GlobalSetup]
        public void Setup ()
        {
            lightInjectProxy = CreateLightInjectInterfaceProxy<IFoo>(new Foo());
            castleProxy = CreateCastleInterfaceProxy<IFoo>(new Foo());
            linFuProxy = CreateLinFuInterfaceProxy<IFoo>(new Foo());                       
        }
               
        private T CreateCastleInterfaceProxy<T>(T target) where T:class
        {            
            Castle.DynamicProxy.ProxyGenerator generator = new ProxyGenerator();
            return generator.CreateInterfaceProxyWithTarget(target, new CastleInterceptor());
        }

        [Benchmark(Baseline=true)]                 
        public void UsingLightInject()
        {
            lightInjectProxy.DoSomething();
        }

        [Benchmark]
        public void UsingCastle()
        {
            castleProxy.DoSomething();
        }

        [Benchmark]
        public void UsingLinFu()
        {
            linFuProxy.DoSomething();
        }
    }

    public interface IFoo
    {
        void DoSomething();
    }

    public class Foo : IFoo
    {
        public void DoSomething()
        {            
        }
    }
}
