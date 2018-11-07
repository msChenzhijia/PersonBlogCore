using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.Model.Models
{
    /// <summary>
    /// 用户信息表
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// 用户名
        /// </summary>
        private string username;
        /// <summary>
        /// 密码
        /// </summary>
        private string password;
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { set; get;}
        /// <summary>
        /// 密码
        /// </summary>
        public string Pass { set; get; }
    }
}

