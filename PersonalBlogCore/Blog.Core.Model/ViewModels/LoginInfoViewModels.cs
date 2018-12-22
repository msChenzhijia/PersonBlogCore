using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Model.VeiwModels
{
    /// <summary>
    /// 登陆信息模型
    /// </summary>
    public class LoginInfoViewModels
    {
        /// <summary>
        /// 登陆用户名
        /// </summary>
        public string uLoginName { get; set; }
        /// <summary>
        /// 登陆密码
        /// </summary>
        public string uLoginPwd { get; set; }
        /// <summary>
        /// 代码
        /// </summary>
        public string VCode { get; set; }

        /// <summary>
        /// 是否记录
        /// </summary>
        public bool IsMember { get; set; }
    }
}
