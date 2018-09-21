using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Blog.Core.Repository.sugar
{
    public class BaseDBConfig
    {
        //public static string ConnectionString = File.ReadAllText(@"D:\my-file\dbCountPsw1.txt").Trim();

        //正常格式是

        public static string ConnectionString = "Database=personalblogcore;Data Source=120.78.194.117;User Id=root;Password=123456;pooling=false;CharSet=utf8;port=3306";

        //public static string ConnectionString = "Server =.;Database=PersonalBlogCore;Trusted_Connection=True;MultipleActiveResultSets=true";
       // public static string ConnectionString= Configuration.GetSection("AppSetting:MySqlConnection").Value;
        //原谅我用配置文件的形式，因为我直接调用的是我的服务器账号和密码，安全起见
    }
}
