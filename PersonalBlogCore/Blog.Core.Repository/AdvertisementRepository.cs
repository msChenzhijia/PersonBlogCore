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
    public class AdvertisementRepository : IRepository.IAdvertisementRepository
    {
        #region 弃用
        //private DbContext context;
        //private SqlSugarClient db;
        //private SimpleClient<Advertisement> entityDB;
        //internal SqlSugarClient Db
        //{
        //    get { return db; }
        //    private set { db = value; }
        //}
        //public DbContext Context
        //{
        //    get { return context; }
        //    set { context = value; }
        //}
        //public AdvertisementRepository()
        //{
        //    DbContext.Init(BaseDBConfig.ConnectionString);
        //    Context = DbContext.GetDbContext();
        //    db = context.Db;
        //    entityDB = context.GeTDB<Advertisement>(db);
        //}
        //public int Add(Advertisement model)
        //{
        //    var i = db.Insertable(model).ExecuteReturnBigIdentity();
        //    return i.ObjToInt();
        //}

        //public bool Delete(Advertisement model)
        //{
        //    var i = db.Deleteable(model).ExecuteCommand();
        //    return i > 0;
        //}


        //public List<Advertisement> Query(Expression<Func<Advertisement, bool>> whereExpression)
        //{
        //    return entityDB.GetList(whereExpression);
        //}

        //public int Sum(int i, int j)
        //{
        //    return i + j;
        //}

        //public bool Update(Advertisement model)
        //{
        //    var i = db.Updateable(model).ExecuteCommand();
        //    return i > 0;
        //}
        #endregion
        public Task<int> Add(Advertisement obj)
        {
            throw new NotImplementedException();
        }

        public Task<int> delete(Advertisement model)
        {
            throw new NotImplementedException();
        }

        public Task<int> deleteById(object id)
        {
            throw new NotImplementedException();
        }

        public Task<int> deleteByIds(object[] lstIds)
        {
            throw new NotImplementedException();
        }

        public Task<List<Advertisement>> Query()
        {
            throw new NotImplementedException();
        }

        public Task<List<Advertisement>> Query(string strWhere)
        {
            throw new NotImplementedException();
        }

        public Task<List<Advertisement>> Query(Expression<Func<Advertisement, bool>> whereExpression)
        {
            throw new NotImplementedException();
        }

        public Task<List<Advertisement>> Query(Expression<Func<Advertisement, bool>> whereExpression, string strOrderByFileds)
        {
            throw new NotImplementedException();
        }

        public Task<List<Advertisement>> Query(Expression<Func<Advertisement, bool>> whereExpression, Expression<Func<Advertisement, object>> orderByExpression, bool isAsc = true)
        {
            throw new NotImplementedException();
        }

        public Task<List<Advertisement>> Query(string strWhere, string strOrderByFileds)
        {
            throw new NotImplementedException();
        }

        public Task<List<Advertisement>> Query(Expression<Func<Advertisement, bool>> whereExpression, int intTop, string strOrderByFileds)
        {
            throw new NotImplementedException();
        }

        public Task<List<Advertisement>> Query(string strWhere, int intTop, string strOrderByFileds)
        {
            throw new NotImplementedException();
        }

        public Task<List<Advertisement>> Query(Expression<Func<Advertisement, bool>> whereExpression, int intPageIndex, int intPageSize, string strOrderByFileds)
        {
            throw new NotImplementedException();
        }

        public Task<List<Advertisement>> Query(string strWhere, int intPageIndex, int intPageSize, string strOrderByFileds)
        {
            throw new NotImplementedException();
        }

        public Task<Advertisement> QueryById(object objId)
        {
            throw new NotImplementedException();
        }

        public Task<Advertisement> QueryById(object objId, bool blnUseCache = false)
        {
            throw new NotImplementedException();
        }

        public Task<List<Advertisement>> QueryByIds(object[] lstIds)
        {
            throw new NotImplementedException();
        }

        public Task<List<Advertisement>> QueryPage(Expression<Func<Advertisement, bool>> whereExpression, int intPageIndex = 0, int intPageSize = 20, string strOrderByFileds = null)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Advertisement obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Advertisement entity, string strWhere)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Advertisement entity, List<string> lstColumns = null, List<string> lstIgnoreColumns = null, string strWhere = "")
        {
            throw new NotImplementedException();
        }
    }
}
