using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlogCore.JsonSerialize.IJsonHelper
{
    /// <summary>
    /// 
    /// </summary>
    public interface IJsonHelper
    {
        /// <summary>
        /// 序列化Json
        /// </summary>
        /// <param name="obj">任何类型的参数</param>
        /// <returns></returns>
        String JsonSerializeObject(Object obj);
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="param">字符串</param>
        /// <returns></returns>
        T JsonDeSerializeObject<T>(String param);
    }
}
