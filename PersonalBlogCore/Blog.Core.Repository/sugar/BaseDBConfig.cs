using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.Repository.sugar
{
    public class BaseDBConfig
    {
        //public static string ConnectionString = File.ReadAllText(@"D:\my-file\dbCountPsw1.txt").Trim();

        //正常格式是

        public static string ConnectionString = "server=localhost;user=root;password=123;post=3306;database=personalblogcore;sslmode=none;";

        //原谅我用配置文件的形式，因为我直接调用的是我的服务器账号和密码，安全起见
    }
}
