using Blog.Core.IRepository;
using System;

namespace Blog.Core.Repository
{
    public class AdvertisementRepository : IRepository.IAdvertisementRepository
    {     
        public int Sum(int i, int j)
        {
            return i + j;
        }
    }
}
