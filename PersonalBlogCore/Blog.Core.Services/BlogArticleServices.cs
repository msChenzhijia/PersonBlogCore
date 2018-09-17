using Blog.Core.Common.Attributes;
using Blog.Core.IRepository;
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
        IBlogArticleRepository blogArticleRepository;
      
        public BlogArticleServices(IBlogArticleRepository blogArticleRepository)
        {
            this.blogArticleRepository = blogArticleRepository;
            this.baseRepository = blogArticleRepository;
        }
        /// <summary>
        /// 获取博客列表
        /// </summary>
        /// <param name="blogArticleServices"></param>
        [Caching(AbsoluteExpiration=10)]
        public async Task<List<BlogArticle>> getBlogs()
        {
            return await blogArticleRepository.Query(a=>a.bID>0,a=>a.bID);
        }
    }
}
