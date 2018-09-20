using BenchmarkDotNet.Attributes;
using static ProxyBenchmarks.ProxyHelper;

namespace ProxyBenchmarks
{
    
     public class InterfaceWithValueType
     {
        private IFooWithValueType lightInjectProxy;
        private IFooWithValueType castleProxy;
        private IFooWithValueType linFuProxy;

        [GlobalSetup]
        public void Setup ()
        {
            lightInjectProxy = CreateLightInjectInterfaceProxy<IFooWithValueType>(new FooWithValueType());
            castleProxy = CreateCastleInterfaceProxy<IFooWithValueType>(new FooWithValueType());
            linFuProxy = CreateLinFuInterfaceProxy<IFooWithValueType>(new FooWithValueType());                       
        }

        [Benchmark(Baseline=true)]                 
        public void UsingLightInject()
        {
            lightInjectProxy.DoSomething(42);
        }

        [Benchmark]
        public void UsingCastle()
        {
            castleProxy.DoSomething(42);
        }

        [Benchmark]
        public void UsingLinFu()
        {
            linFuProxy.DoSomething(42);
        }
     }
    
    public interface IFooWithValueType
    {
        void DoSomething(int test);
    }


    public class FooWithValueType : IFooWithValueType
    {
        public void DoSomething(int test)
        {
        }
    }
}