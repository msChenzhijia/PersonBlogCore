using Blog.Core.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.IServices
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserInfoServices:IBaseServices<UserInfo>
    {
        /// <summary>
        /// 通过密码和用户名登录
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="PassWorld"></param>
        /// <returns></returns>
        Task<bool> GetLoginByUserAndPass(string UserName, string PassWorld);
    }
}
