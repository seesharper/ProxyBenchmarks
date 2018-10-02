using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using static ProxyBenchmarks.ProxyHelper;

namespace ProxyBenchmarks
{
    
     public class InterfaceWithValueType
     {
        private IFooWithValueType lightInjectProxy;
        private IFooWithValueType castleProxy;
        private IFooWithValueType linFuProxy;
        private IFooWithValueType dispatchProxy;
        private IFooWithValueType manualNoInlining;

        [GlobalSetup]
        public void Setup ()
        {
            manualNoInlining = new ManualNoInliningValProxy(new FooWithValueType());
            lightInjectProxy = CreateLightInjectInterfaceProxy<IFooWithValueType>(new FooWithValueType());
            castleProxy = CreateCastleInterfaceProxy<IFooWithValueType>(new FooWithValueType());
            linFuProxy = CreateLinFuInterfaceProxy<IFooWithValueType>(new FooWithValueType());                       
            dispatchProxy = CreateDispatchInterfaceProxy<IFooWithValueType>(new FooWithValueType());       
        }

        [Benchmark(Baseline=true)]                 
        public void UsingManualNoInlining()
        {
            manualNoInlining.DoSomething(42);
        }

        [Benchmark]                 
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

        [Benchmark]
        public void UsingDispatch()
        {
            dispatchProxy.DoSomething(42);
        }
     }
    
    public interface IFooWithValueType
    {
        void DoSomething(int test);
    }


    public class FooWithValueType : IFooWithValueType
    {
        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        public void DoSomething(int test)
        {
        }
    }

    public class ManualNoInliningValProxy : IFooWithValueType
    {   
        private IFooWithValueType target;        
        public ManualNoInliningValProxy(IFooWithValueType target) => this.target = target;

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        public void DoSomething(int test) => target.DoSomething(test);        
    }
}