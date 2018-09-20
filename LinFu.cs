using LinFu.DynamicProxy;

namespace InterceptionBenchmarks
{
    public class LinFuInterceptor<T> : IInterceptor
    {
        private readonly T target;

        public LinFuInterceptor(T target)
        {
            this.target = target;
        }
        
        public object Intercept(InvocationInfo info)
        {
            return info.TargetMethod.Invoke(target, info.Arguments);
        }
    }


    public static partial class ProxyHelper
    {
        public static T CreateLinFuInterfaceProxy<T>(T target) where T:class
        {
            var proxyFactory = new ProxyFactory();
            return (T)proxyFactory.CreateProxy(typeof(T),new LinFuInterceptor<T>(target));
        }
    }
}