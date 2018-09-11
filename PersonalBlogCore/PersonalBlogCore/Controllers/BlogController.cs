using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private IBlogArticleServices  BlogArticleServices;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="advertisementServices"></param>
        public BlogController(IAdvertisementServices advertisementServices)
        {
            this.advertisementServices = advertisementServices;
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
        /// 
        /// </summary>
        /// <param name="id"></param>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        /// <summary>
        /// 获取博客列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetBlogs")]
        public async Task<List<BlogArticle>> GetBlogs()
        {
            return await  BlogArticleServices.Query();
        }
        
    }
}