using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlogCore.AOP
{
    /// <summary>
    /// 简单的缓存接口，只有查询和添加，以后会进行扩展
    /// </summary>
    public interface ICaching
    {
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="cachekey">键</param>
        /// <returns></returns>
        object Get(string cachekey);
        /// <summary>
        /// 存放缓存
        /// </summary>
        /// <param name="chachekey">键</param>
        /// <param name="cacheValue">值</param>
        void Set(string chachekey, object cacheValue);
    }
}
