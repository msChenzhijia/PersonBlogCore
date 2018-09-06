using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlogCore.AuthHelper.OverWrite
{
    /// <summary>
    /// 
    /// </summary>
    public class JwtTokenAuth
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly RequestDelegate _next;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        public JwtTokenAuth(RequestDelegate next)
        {
            _next = next;
        }
        public Task Invoke(HttpContext httpContext)
        {
            //检测是否包含Authorization请求头
            if (!httpContext.Request.Headers.ContainsKey("Authorization"))
            {
                return _next(httpContext);
            }
            var tokenHeader = httpContext.Request.Headers["Authorization"].ToString();
            Toke
        }
    }
}
