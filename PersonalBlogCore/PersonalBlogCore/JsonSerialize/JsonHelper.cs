using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlogCore.JsonSerialize
{
    /// <summary>
    /// Json帮助类
    /// </summary>
    public class JsonHelper:IJsonHelper.IJsonHelper
    {
        /// <summary>
        /// 序列化Json
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public String JsonSerializeObject(Object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public T JsonDeSerializeObject<T>(String param)
        {
            return JsonConvert.DeserializeObject<T>(param);
        }
    }
}
