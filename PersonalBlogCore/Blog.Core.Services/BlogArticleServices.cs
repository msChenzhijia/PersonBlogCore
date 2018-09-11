using Blog.Core.IServices;
using Blog.Core.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Services
{
    public class BlogArticleServices:BaseServices<BlogArticle>,IBlogArticleServices
    {
        IBlogArticleServices blogArticleServices;
      
        public BlogArticleServices(IBlogArticleServices blogArticleServices)
        {
            this.blogArticleServices = blogArticleServices;
        }
        /// <summary>
        /// 获取博客列表
        /// </summary>
        /// <param name="blogArticleServices"></param>
        public async Task<List<BlogArticle>> getBlogs()
        {
            return await blogArticleServices.Query();
        }
    }
}
