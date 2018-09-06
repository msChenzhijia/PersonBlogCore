using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class TokenModelJWT
    {
        /// <summary>
        /// id
        /// </summary>
        public long Id { set; get; }
        /// <summary>
        /// 角色
        /// </summary>
        public string Role { set; get; }
        /// <summary>
        /// 职能
        /// </summary>
        public string Work { set; get; }
    }
}
