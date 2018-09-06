using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.Model
{
    /// <summary>
    /// 通用返回信息类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MessageModel<T>
    {
        /// <summary>
        /// 操作是否成功
        /// </summary>
        public bool Success { set; get;}
        /// <summary>
        /// 返回信息
        /// </summary>
        public string Msg { set; get; }
        /// <summary>
        /// 返回数据集合
        /// </summary>
        public List<T> Data { set; get; }
    }
}
