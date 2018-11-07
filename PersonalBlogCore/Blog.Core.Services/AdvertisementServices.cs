using Blog.Core.IRepository;
using Blog.Core.IServices;
using Blog.Core.Model.Models;
using Blog.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Blog.Core.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class AdvertisementServices :BaseServices<Advertisement>,IAdvertisementServices
    {
        IAdvertisementRepository dal;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="advertisementRepository"></param>
        public AdvertisementServices(IAdvertisementRepository advertisementRepository)
        {
            dal = advertisementRepository;
            base.baseRepository = advertisementRepository;
        }
    }
}
