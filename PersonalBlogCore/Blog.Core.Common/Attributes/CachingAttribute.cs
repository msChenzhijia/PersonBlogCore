﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.Common.Attributes
{
    /// <summary>
    /// 这个Attribute就是使用时候的验证，把它添加到要缓存数据的方法中，即可完成缓存的操作。
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class CachingAttribute: Attribute
    {

        /// <summary>
        /// 缓存绝对过期时间
        /// </summary>
        public int AbsoluteExpiration { set; get; } = 30;
    }
}
