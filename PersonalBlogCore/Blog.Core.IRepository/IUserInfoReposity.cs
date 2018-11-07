using Blog.Core.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.IRepository
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserInfoReposity:IBaseRepository<UserInfo>
    {
        /// <summary>
        /// 通过用户名和密码登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        Task<bool> GetLoginUserAndPass(string name, string pass);
    }
}
