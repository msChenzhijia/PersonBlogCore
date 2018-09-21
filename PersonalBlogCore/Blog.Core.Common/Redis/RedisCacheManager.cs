using Blog.Core.Common.Helper;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.Common.Redis
{
    public class RedisCacheManager : IRedisCacheManager
    {
        private readonly string redisConnectionString;
        /// <summary>
        /// 
        /// </summary>
        public volatile ConnectionMultiplexer redisConnection;
        private readonly object redisConnectionLock = new object();
        /// <summary>
        /// 
        /// </summary>
        public RedisCacheManager()
        {
            string redisConfiguration = Appsettings.app(new string[] { "AppSettings", "RedisCaching", "ConnectionString"});
            if (string.IsNullOrWhiteSpace(redisConfiguration))
            {
                throw new ArgumentException("redis地址为空", nameof(redisConfiguration));
            }
            this.redisConnectionString = "127.0.0.1:6379";
            this.redisConnection = GetRedisConnection();
        }
        /// <summary>
        /// 核心代码，获取连接实例
        /// 通过双if 夹lock的方式，实现单例模式
        /// </summary>
        /// <returns></returns>
        public ConnectionMultiplexer GetRedisConnection()
        {
            //如果已经链接实例,直接返回
            if (this.redisConnection!=null&&this.redisConnection.IsConnected)
            {
                return this.redisConnection;
            }
            //加锁
            lock (redisConnectionLock)
            {
                if (this.redisConnection != null)
                {
                    //释放redis链接
                    this.redisConnection.Dispose();
                }
                this.redisConnection = ConnectionMultiplexer.Connect(redisConnectionString);
            }
            return this.redisConnection;
        }
        /// <summary>
        /// 清除
        /// </summary>
        public void Clear()
        {
            foreach (var endPoint in this.GetRedisConnection().GetEndPoints())
            {
                var server = this.GetRedisConnection().GetServer(endPoint);
                foreach (var key in server.Keys())
                {
                    redisConnection.GetDatabase().KeyDelete(key);
                }
            }
        }
        /// <summary>
        /// 获取
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public TEntity Get<TEntity>(string key)
        {
            var value = redisConnection.GetDatabase().StringGet(key);
            if (value.HasValue)
            {
                return SerializeHelper.Deserialize<TEntity>(value);
            }
            else
            {
                return default(TEntity);
            }
        }
        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Get(string key)
        {
            return this.redisConnection.GetDatabase().KeyExists(key);
        }
        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            this.redisConnection.GetDatabase().KeyDelete(key);
        }
        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="chacheTime"></param>
        public void Set(string key, object value, TimeSpan chacheTime)
        {
            if (value!=null)
            {
                redisConnection.GetDatabase().StringSet(key, SerializeHelper.Serialize(value), chacheTime);
            }
        }
    }
}
