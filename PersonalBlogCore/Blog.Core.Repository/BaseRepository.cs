using Blog.Core.IRepository;
using Blog.Core.Repository.sugar;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        public DbContext context;
        private SqlSugarClient db;
        private SimpleClient<T> entityDB;
        public DbContext Context
        {
            get { return context; }
            set { context = value; }
        }

        internal SqlSugarClient Db
        {
            get { return db; }
            private set { db = value; }
        }
        internal SimpleClient<T> EntityDB
        {
            get { return entityDB; }
            private set { entityDB = value; }
        }
        public BaseRepository()
        {
            DbContext.Init(BaseDBConfig.ConnectionString);
            context = DbContext.GetDbContext();
            db = context.Db;
            entityDB = context.GeTDB<T>(db);
        }

        public Task<int> Add(T obj)
        {
            throw new NotImplementedException();
        }

        public Task<int> delete(T model)
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

        public Task<List<T>> Query()
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Query(string strWhere)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Query(Expression<Func<T, bool>> whereExpression)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Query(Expression<Func<T, bool>> whereExpression, string strOrderByFileds)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Query(Expression<Func<T, bool>> whereExpression, Expression<Func<T, object>> orderByExpression, bool isAsc = true)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Query(string strWhere, string strOrderByFileds)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Query(Expression<Func<T, bool>> whereExpression, int intTop, string strOrderByFileds)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Query(string strWhere, int intTop, string strOrderByFileds)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Query(Expression<Func<T, bool>> whereExpression, int intPageIndex, int intPageSize, string strOrderByFileds)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Query(string strWhere, int intPageIndex, int intPageSize, string strOrderByFileds)
        {
            throw new NotImplementedException();
        }

        public Task<T> QueryById(object objId)
        {
            throw new NotImplementedException();
        }

        public Task<T> QueryById(object objId, bool blnUseCache = false)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> QueryByIds(object[] lstIds)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> QueryPage(Expression<Func<T, bool>> whereExpression, int intPageIndex = 0, int intPageSize = 20, string strOrderByFileds = null)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(T obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(T entity, string strWhere)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(T entity, List<string> lstColumns = null, List<string> lstIgnoreColumns = null, string strWhere = "")
        {
            throw new NotImplementedException();
        }
    }
}
