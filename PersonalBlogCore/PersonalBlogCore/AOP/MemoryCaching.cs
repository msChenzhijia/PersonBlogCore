using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlogCore.AOP
{
    /// <summary>
    /// 缓存实现
    /// </summary>
    public class MemoryCaching : ICaching
    {
        private IMemoryCache memoryCache;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="memoryCache"></param>
        public MemoryCaching(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }
        //引用Microsoft.Extensions.Caching.Memory;这个和.net 还是不一样，没有了Httpruntime了
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="cachekey"></param>
        /// <returns></returns>
        public object Get(string cachekey)
        {
           return memoryCache.Get(cachekey);
        }
        /// <summary>
        /// 存放缓存
        /// </summary>
        /// <param name="chachekey"></param>
        /// <param name="cacheValue"></param>
        public void Set(string chachekey, object cacheValue)
        {
            memoryCache.Set(chachekey, cacheValue,TimeSpan.FromSeconds(7200));
        }
    }
}
