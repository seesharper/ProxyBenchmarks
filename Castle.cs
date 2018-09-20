using Castle.DynamicProxy;


namespace ProxyBenchmarks
{
    public class CastleInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
        }
    }

    public static partial class ProxyHelper
    {
        public static T CreateCastleInterfaceProxy<T>(T target) where T:class
        {
            Castle.DynamicProxy.ProxyGenerator generator = new ProxyGenerator();
            return generator.CreateInterfaceProxyWithTarget(target, new CastleInterceptor());
        }
    }
}