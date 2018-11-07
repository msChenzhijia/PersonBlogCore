using Blog.Core.IRepository;
using Blog.Core.Model.Models;
using Blog.Core.Repository.sugar;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Blog.Core.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class AdvertisementRepository:BaseRepository<Advertisement>,IAdvertisementRepository
    {
      
       
    }
}
