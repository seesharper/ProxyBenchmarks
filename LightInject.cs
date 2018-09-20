using System;
using LightInject.Interception;

namespace InterceptionBenchmarks
{
    public class LightInjectInterceptor : IInterceptor
    {
        public object Invoke(IInvocationInfo invocationInfo)
        {
            return invocationInfo.Proceed();
        }
    }


    public static partial class ProxyHelper
    {
      public static T CreateLightInjectInterfaceProxy<T>(T target)
        {
            var proxyDefinition = new ProxyDefinition(typeof(T), () => target);
            proxyDefinition.Implement(() => new LightInjectInterceptor());
            var proxyBuilder = new ProxyBuilder();            
            return (T)Activator.CreateInstance(proxyBuilder.GetProxyType(proxyDefinition));
        }
    }
}