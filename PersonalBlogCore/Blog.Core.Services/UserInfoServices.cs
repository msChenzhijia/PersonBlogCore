using AutoMapper;
using Blog.Core.IRepository;
using Blog.Core.IServices;
using Blog.Core.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Services
{
    /// <summary>
    /// UserInfo服务层
    /// </summary>
    public class UserInfoServices:BaseServices<UserInfo>,IUserInfoServices
    {
        IUserInfoReposity iuserInfoReposity;
        IMapper imaper;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="iuserInfoReposity"></param>
        /// <param name="imaper"></param>
        public UserInfoServices(IUserInfoReposity iuserInfoReposity, IMapper imaper)
        {
            this.iuserInfoReposity = iuserInfoReposity;
            this.imaper = imaper;
        }
        /// <summary>
        /// 通过密码和用户名登录
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="PassWorld"></param>
        /// <returns></returns>
        public Task<bool> GetLoginByUserAndPass(string UserName,string PassWorld)
        {
           return  iuserInfoReposity.GetLoginUserAndPass(UserName, PassWorld);
        }
    }
}
