using BenchmarkDotNet.Attributes;
using static ProxyBenchmarks.ProxyHelper;

namespace ProxyBenchmarks
{         
     public class InterfaceWithReferenceType
     {
        private IFooWithReferenceType lightInjectProxy;
        private IFooWithReferenceType castleProxy;
        private IFooWithReferenceType linFuProxy;

        [GlobalSetup]
        public void Setup ()
        {
            lightInjectProxy = CreateLightInjectInterfaceProxy<IFooWithReferenceType>(new FooWithReferenceType());
            castleProxy = CreateCastleInterfaceProxy<IFooWithReferenceType>(new FooWithReferenceType());
            linFuProxy = CreateLinFuInterfaceProxy<IFooWithReferenceType>(new FooWithReferenceType());                       
        }

        [Benchmark(Baseline=true)]                 
        public void UsingLightInject()
        {
            lightInjectProxy.DoSomething("42");
        }

        [Benchmark]
        public void UsingCastle()
        {
            castleProxy.DoSomething("42");
        }

        [Benchmark]
        public void UsingLinFu()
        {
            linFuProxy.DoSomething("42");
        }
     }
    
    public interface IFooWithReferenceType
    {
        void DoSomething(string test);
    }


    public class FooWithReferenceType : IFooWithReferenceType
    {
        public void DoSomething(string test)
        {
        }
    }
}