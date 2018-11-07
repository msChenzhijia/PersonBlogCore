using Blog.Core.IRepository;
using Blog.Core.Model.Models;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class UserInfoReposity: BaseRepository<UserInfo>,IUserInfoReposity
    {
        /// <summary>
        /// 根据用户名和密码登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pass"></param>
        /// <returns></returns>        
        public async Task<bool> GetLoginUserAndPass(string name, string pass)
        {
            bool IsExits = false;
            await Task.Run(() => {
                var IsExitsList = Db.Queryable<UserInfo>().Where(x => x.UserName == name && x.Pass == pass);
                int Count = IsExitsList.Count();
                if (Count>0)
                {
                    IsExits = true;
                }
                else
                {
                    IsExits = false;
                }
            });
            return IsExits;
        }
    }
}
