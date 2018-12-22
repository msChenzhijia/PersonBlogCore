using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Core.Common.Helper;
using Blog.Core.Common.Redis;
using Blog.Core.IServices;
using Blog.Core.Model.Models;
using Blog.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PersonalBlogCore.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/Blog")]
    //[Authorize(Policy = "Admin")]
    public class BlogController : Controller
    {
        private IAdvertisementServices advertisementServices;
        private IBlogArticleServices  blogArticleServices;
        private IRedisCacheManager redisCacheManager;//Reids缓存
        /// <summary>
        /// 
        /// </summary>
        /// <param name="advertisementServices"></param>
        /// <param name="blogArticleServices"></param>
        /// <param name="redisCacheManager"></param>
        public BlogController(IAdvertisementServices advertisementServices, IBlogArticleServices blogArticleServices,IRedisCacheManager redisCacheManager)
        {
            this.advertisementServices = advertisementServices;
            this.blogArticleServices = blogArticleServices;
            this.redisCacheManager = redisCacheManager;
        }
        // GET: api/Blog
        /// <summary>
        /// Sum接口
        /// </summary>
        /// <param name="i">参数i</param>
        /// <param name="j">参数j</param>
        /// <returns></returns>
        [HttpGet]
        public Task<List<Advertisement>> Get(int i, int j)
        {
             return advertisementServices.Query();            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}",Name ="Get")]
        public Task<List<Advertisement>> Get(int id)
        {
             return advertisementServices.Query(x => x.Id == id);            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT: api/Blog/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>     
        [HttpPost("id")]        
        public async Task<Boolean> Delete(Int32 id)
        {
             return await blogArticleServices.DeleteById(id);
        }
        /// <summary>
        /// 获取博客列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetBlogs")]
        public async Task<List<BlogArticle>> GetBlogs()
        {
            //var connect = Appsettings.app(new string []{ "AppSettings", "RedisCaching", "ConnectionString"});//按照层级的顺序，依次写出来
            List<BlogArticle> blogArticlesList = new List<BlogArticle>();
            //if (redisCacheManager.Get<object>("Redis.Blog") != null)
            //{
            //    blogArticlesList = redisCacheManager.Get<List<BlogArticle>>("Redis.Blog");
            //}
            //else
            //{
                blogArticlesList = await blogArticleServices.Query(d => d.bID < 5);
                redisCacheManager.Set("Redis.Blog", blogArticlesList, TimeSpan.FromHours(2));//缓存2小时
            //}
            return blogArticlesList;


        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="bsubmitter">提交人</param>
        /// <param name="btitle">博客标题</param>
        /// <param name="bcategory">博客类型</param>
        /// <param name="bcontent">内容</param>
        /// <param name="bRemark">备注</param>
        /// <returns>返回true或false</returns>
        [HttpGet]
        [Route("Inserts")]
        public  async Task<bool> Inserts(String bsubmitter,String btitle,String bcategory,String bcontent,String bRemark)
        {
            BlogArticle blogArticle = new BlogArticle()
            {   bsubmitter = bsubmitter,
                btitle = btitle,
                bcategory = bcategory,
                bcontent = bcontent,
                bRemark = bRemark,
                btraffic = 0,
                bcommentNum = 0,
                bUpdateTime = DateTime.Now,
                bCreateTime = DateTime.Now };
                bool result= await blogArticleServices.Add(blogArticle)>0?true:false;
            return result;
        }
        /// <summary>
        /// 获取博客内容
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetBlogArticle")]
        public async Task<List<BlogArticle>> GetBlogArticle()
        {
            return await blogArticleServices.getBlogs();
        }


    }
}