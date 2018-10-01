using System.Reflection;

namespace ProxyBenchmarks
{
    public class ReflectionDispatchProxy<T> : DispatchProxy
    {   
        private T target;
         
        internal void SetTarget(T target) => this.target = target;

        protected override object Invoke(MethodInfo targetMethod, object[] args) =>
            targetMethod.Invoke(target, args);
    }

    public static partial class ProxyHelper
    {
      public static T CreateDispatchInterfaceProxy<T>(T target)
        {
            var proxy = DispatchProxy.Create<T, ReflectionDispatchProxy<T>>();
            (proxy as ReflectionDispatchProxy<T>).SetTarget(target);
            return (T)proxy;
        }
    }
}