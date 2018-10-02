using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using static ProxyBenchmarks.ProxyHelper;

namespace ProxyBenchmarks
{         
     public class InterfaceWithReferenceType
     {
        private IFooWithReferenceType lightInjectProxy;
        private IFooWithReferenceType castleProxy;
        private IFooWithReferenceType linFuProxy;
        private IFooWithReferenceType dispatchProxy;
        private IFooWithReferenceType manualNoInliningProxy;

        [GlobalSetup]
        public void Setup ()
        {
            manualNoInliningProxy = new ManualNoInliningRefProxy(new FooWithReferenceType());
            lightInjectProxy = CreateLightInjectInterfaceProxy<IFooWithReferenceType>(new FooWithReferenceType());
            castleProxy = CreateCastleInterfaceProxy<IFooWithReferenceType>(new FooWithReferenceType());
            linFuProxy = CreateLinFuInterfaceProxy<IFooWithReferenceType>(new FooWithReferenceType());    
            dispatchProxy = CreateDispatchInterfaceProxy<IFooWithReferenceType>(new FooWithReferenceType());                   
        }

        
        [Benchmark(Baseline=true)]                 
        public void UsingManualNoInlining()
        {
            manualNoInliningProxy.DoSomething("42");
        }

        [Benchmark]                 
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

        [Benchmark]
        public void UsingDispatch()
        {
            dispatchProxy.DoSomething("42");
        }
     }
    
    public interface IFooWithReferenceType
    {
        void DoSomething(string test);
    }


    public class FooWithReferenceType : IFooWithReferenceType
    {
        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        public void DoSomething(string test)
        {
        }
    }

    public class ManualNoInliningRefProxy : IFooWithReferenceType
    {   
        private IFooWithReferenceType target;        
        public ManualNoInliningRefProxy(IFooWithReferenceType target) => this.target = target;

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        public void DoSomething(string test) => target.DoSomething(test);        
    }
}