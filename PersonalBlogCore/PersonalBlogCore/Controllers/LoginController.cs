﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Core.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalBlogCore.AuthHelper.OverWrite;

namespace PersonalBlogCore.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/Login")]
    [EnableCors("LimitRequests")]
    public class LoginController : Controller
    {
        #region  获取token的第二种方法
        /// <summary>
        /// 获取JWT的重写方法，推荐这种，注意在文件夹OverWrite下
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="sub">角色</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Token")]
        public JsonResult GetJWTStr(long id=1,string sub = "Admin")
        {
            //这里就是用户登陆以后，通过数据库去调取数据，分配权限的操作
            TokenModelJWT tokenModelJWT = new TokenModelJWT();
            tokenModelJWT.Id = id;
            tokenModelJWT.Role = sub;
            string jwtStr = JwtHelper.IssueJWT(tokenModelJWT);
            return Json(jwtStr);
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="callBack"></param>
        /// <param name="id"></param>
        /// <param name="sub"></param>
        /// <param name="expiresSliding"></param>
        /// <param name="expiresAbsoulute"></param>
        [HttpGet]
        [Route("jsonp")]
        public void GetJsonp(string callBack, long id = 1, string sub = "Admin", int expiresSliding = 30, int expiresAbsoulute = 30)
        {
            TokenModelJWT tokenModelJWT = new TokenModelJWT();
            tokenModelJWT.Id = id;
            tokenModelJWT.Role = sub;
            string jwtStr = JwtHelper.IssueJWT(tokenModelJWT);
            string response = string.Format("\"value\":\"{0}\"", jwtStr);
            string call = callBack + "({" + response + "})";
            Response.WriteAsync(call);
        }
    }
}
