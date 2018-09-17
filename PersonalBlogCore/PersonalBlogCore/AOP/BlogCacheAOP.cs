using Blog.Core.Common.Attributes;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlogCore.AOP
{
    /// <summary>
    /// 面向切面的缓存使用
    /// </summary>
    public class BlogCacheAOP : IInterceptor
    {
        private ICaching caching;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="caching"></param>
        public BlogCacheAOP(ICaching caching)
        {
            this.caching = caching;
        }
        /// <summary>
        /// Intercept方法是拦截的关键所在，也是IInterceptor接口中的唯一定义
        /// </summary>
        /// <param name="invocation"></param>
        public void Intercept(IInvocation invocation)
        {
            var method = invocation.MethodInvocationTarget ?? invocation.Method;
            //对当前方法的特性验证
            var qCachingAttribute = method.GetCustomAttributes(true).FirstOrDefault(x => x.GetType() == typeof(CachingAttribute)) as CachingAttribute;
            if (qCachingAttribute!=null)
            {
                //获取自定义缓存键
                var cacheKey = CustomCacheKey(invocation);
                //根据key获取相对应的缓存值
                var cacheValue = caching.Get(cacheKey);
                if (cacheValue!=null)
                {
                    invocation.ReturnValue = cacheValue;
                    return;
                }
                //去执行当前的方法
                invocation.Proceed();
                //存入缓存
                if (!string.IsNullOrWhiteSpace(cacheKey))
                {
                    caching.Set(cacheKey, invocation.ReturnValue);
                }

            }
            else
            {
                invocation.Proceed();//直接执行被拦截方法
            }
        }
        //自定义缓存键
        private string CustomCacheKey(IInvocation invocation)
        {
            var typeName = invocation.TargetType.Name;
            var methodName = invocation.Method.Name;
            var methodArguments = invocation.Arguments.Select(GetArgumentValue).Take(3).ToList();//获取参数列表,最多3个
            string key = $"{typeName}:{methodName}";
            foreach (var param in methodArguments)
            {
                key += $"{param}:";
            }
            return key.TrimEnd(':');
        }
        /// <summary>
        /// object转string
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public string GetArgumentValue(object arg)
        {
            if (arg is int ||arg is long || arg is string)
            {
                return arg.ToString();
            }
            if (arg is DateTime)
            {
                return ((DateTime)arg).ToString("yyyyMMddHHmmss");
            }
            return "";
        }
    }
}
