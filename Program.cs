using System;
using LightInject.Interception;
using BenchmarkDotNet.Running;


namespace ProxyBenchmarks
{
    class Program
    {
        static void Main(string[] args)
        {                        
            // BenchmarkRunner.Run<Interface>();
            // BenchmarkRunner.Run<InterfaceWithValueType>();
            BenchmarkRunner.Run<InterfaceWithReferenceType>();
        }
    }


    

   
}
