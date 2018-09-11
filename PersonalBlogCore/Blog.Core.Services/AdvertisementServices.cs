using Blog.Core.IRepository;
using Blog.Core.IServices;
using Blog.Core.Model.Models;
using Blog.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Blog.Core.Services
{
    public class AdvertisementServices :BaseServices<Advertisement>,IAdvertisementServices
    {
        IAdvertisementRepository dal;
        public AdvertisementServices(IAdvertisementRepository advertisementRepository)
        {
            dal = advertisementRepository;
            base.baseRepository = advertisementRepository;
        }
    }
}
