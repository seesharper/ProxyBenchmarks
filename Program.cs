using System;
using LightInject.Interception;
using BenchmarkDotNet.Running;


namespace InterceptionBenchmarks
{
    class Program
    {
        static void Main(string[] args)
        {            
            // var test = new InterfaceTests();
            // test.Setup();
            // test.UsingLinFu();


            var summary = BenchmarkRunner.Run<InterfaceTests>();
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
