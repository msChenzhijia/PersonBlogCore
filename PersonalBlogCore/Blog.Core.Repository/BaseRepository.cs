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
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        /// <summary>
        /// 
        /// </summary>
        public DbContext context;
        private SqlSugarClient db;
        private SimpleClient<T> entityDB;
        /// <summary>
        /// 
        /// </summary>
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
        /// <summary>
        /// 
        /// </summary>
        public BaseRepository()
        {
            DbContext.Init(BaseDBConfig.ConnectionString);
            context = DbContext.GetDbContext();
            db = context.Db;
            entityDB = context.GeTDB<T>(db);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public async Task<int> Add(T obj)
        {
            var i = await Task.Run(() => db.Insertable<T>(obj).ExecuteCommand());           
            return (int)i;
        }
        /// <summary>
        /// 通过实体删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> delete(T model)
        {
            var i = await Task.Run(() => db.Deleteable<T>(model).ExecuteCommand());
            return (int)i>0;
        }
        /// <summary>
        /// 通过ID删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public async Task<bool> deleteById(object id)
        {
            var i = await Task.Run(() => db.Deleteable<T>(id).ExecuteCommand());
            return (int)i>0;
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="lstIds">删除集合</param>
        /// <returns></returns>
        public async Task<bool> deleteByIds(object[] lstIds)
        {
            var i = await Task.Run(() => db.Deleteable<T>().In(lstIds).ExecuteCommand());
            return i > 0;
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public async Task<List<T>> Query()
        {
            var i = await Task.Run(() => entityDB.GetList());
            return i;
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        public async Task<List<T>> Query(string strWhere)
        {
            var i = await Task.Run(() => db.Queryable<T>().WhereIF(!string.IsNullOrEmpty(strWhere), strWhere).ToList());
            return i;
        }
        /// <summary>
        /// 查询数据列表
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public async Task<List<T>> Query(Expression<Func<T, bool>> whereExpression)
        {
            var i = await Task.Run(() => entityDB.GetList(whereExpression));
            return i;
        }
        /// <summary>
        /// 查询一个列表
        /// </summary>
        /// <param name="whereExpression">条件表达式</param>
        /// <param name="strOrderByFileds">排序字段，如name asc,age desc</param>
        /// <returns></returns>
        public async Task<List<T>> Query(Expression<Func<T, bool>> whereExpression, string strOrderByFileds)
        {
            var i= await Task.Run(() => db.Queryable<T>().OrderByIF(!string.IsNullOrEmpty(strOrderByFileds), strOrderByFileds).WhereIF(whereExpression!=null, whereExpression).ToList());
            return i;
        }
        /// <summary>
        /// 查询前N条数据
        /// </summary>
        /// <param name="whereExpression">条件</param>
        /// <param name="orderByExpression">排序</param>
        /// <param name="isAsc">是否排序</param>
        /// <returns></returns>
        public async Task<List<T>> Query(Expression<Func<T, bool>> whereExpression, Expression<Func<T, object>> orderByExpression, bool isAsc = true)
        {
            var i = await Task.Run(() => db.Queryable<T>().OrderByIF(orderByExpression != null, orderByExpression, isAsc ? OrderByType.Asc : OrderByType.Desc).WhereIF(whereExpression != null, whereExpression).ToList());
            return i;
        }
        /// <summary>
        /// 查询一个列表
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="strOrderByFileds">排序字段，如name,asc,age,desc</param>
        /// <returns></returns>
        public async Task<List<T>> Query(string strWhere, string strOrderByFileds)
        {
            var i = await Task.Run(()=>db.Queryable<T>().OrderByIF(!string.IsNullOrEmpty(strOrderByFileds), strOrderByFileds).WhereIF(!string.IsNullOrEmpty(strWhere), strWhere).ToList());
            return i;
        }
        /// <summary>
        /// 查询前N条数据
        /// </summary>
        /// <param name="whereExpression">条件表达式</param>
        /// <param name="intTop">前N条</param>
        /// <param name="strOrderByFileds">排序字段，如name asc,age desc</param>
        /// <returns></returns>
        public async Task<List<T>> Query(Expression<Func<T, bool>> whereExpression, int intTop, string strOrderByFileds)
        {
            return await Task.Run(() => db.Queryable<T>().OrderByIF(!string.IsNullOrEmpty(strOrderByFileds), strOrderByFileds).WhereIF(whereExpression != null, whereExpression).Take(intTop).ToList());
        }
        /// <summary>
        /// 查询前N条数据
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="intTop">前N条</param>
        /// <param name="strOrderByFileds">排序字段，如name asc,age desc</param>
        /// <returns></returns>
        public async Task<List<T>> Query(string strWhere, int intTop, string strOrderByFileds)
        {
            return await Task.Run(() => db.Queryable<T>().OrderByIF(!string.IsNullOrEmpty(strOrderByFileds), strOrderByFileds).WhereIF(!string.IsNullOrEmpty(strWhere), strWhere).Take(intTop).ToList());
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="whereExpression">条件表达式</param>
        /// <param name="intPageIndex">页码（下标0）</param>
        /// <param name="intPageSize">页大小</param>
        /// <param name="strOrderByFileds">排序字段，如name asc,age desc</param>
        /// <returns></returns>
        public async Task<List<T>> Query(Expression<Func<T, bool>> whereExpression, int intPageIndex, int intPageSize, string strOrderByFileds)
        {
            return await Task.Run(() => db.Queryable<T>().OrderByIF(!string.IsNullOrEmpty(strOrderByFileds), strOrderByFileds).WhereIF(whereExpression!=null, whereExpression).ToPageList(intPageIndex, intPageSize));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="intPageIndex"></param>
        /// <param name="intPageSize"></param>
        /// <param name="strOrderByFileds"></param>
        /// <returns></returns>
        public async Task<List<T>> Query(string strWhere, int intPageIndex, int intPageSize, string strOrderByFileds)
        {
            return await Task.Run(() => db.Queryable<T>().OrderByIF(!string.IsNullOrEmpty(strOrderByFileds), strOrderByFileds).WhereIF(!string.IsNullOrEmpty(strWhere), strWhere).ToPageList(intPageIndex, intPageSize));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objId"></param>
        /// <returns></returns>
        public async Task<T> QueryById(object objId)
        {
            return await Task.Run(() => db.Queryable<T>().InSingle(objId));
        }
        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="objId">主键</param>
        /// <param name="blnUseCache">是否启动缓存</param>
        /// <returns></returns>
        public async Task<T> QueryById(object objId, bool blnUseCache = false)
        {
            return await Task.Run(() => db.Queryable<T>().WithCacheIF(blnUseCache).InSingle(objId));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstIds"></param>
        /// <returns></returns>
        public async Task<List<T>> QueryByIds(object[] lstIds)
        {
            return await Task.Run(() => db.Queryable<T>().In(lstIds).ToList());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="intPageIndex"></param>
        /// <param name="intPageSize"></param>
        /// <param name="strOrderByFileds"></param>
        /// <returns></returns>
        public async Task<List<T>> QueryPage(Expression<Func<T, bool>> whereExpression, int intPageIndex = 0, int intPageSize = 20, string strOrderByFileds = null)
        {
            return await Task.Run(() => db.Queryable<T>().OrderByIF(!string.IsNullOrEmpty(strOrderByFileds), strOrderByFileds).WhereIF(whereExpression != null, whereExpression).ToPageList(intPageIndex, intPageSize));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<bool> Update(T obj)
        {
            return await Task.Run(() => db.Updateable<T>(obj).ExecuteCommand()>0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public async Task<bool> Update(T entity, string strWhere)
        {
            return await Task.Run(() => db.Updateable<T>(entity).Where(strWhere).ExecuteCommand()>0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="lstColumns"></param>
        /// <param name="lstIgnoreColumns"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public async Task<bool> Update(T entity, List<string> lstColumns = null, List<string> lstIgnoreColumns = null, string strWhere = "")
        {
            IUpdateable<T> up = await Task.Run(() => db.Updateable(entity));
            if (lstIgnoreColumns != null && lstIgnoreColumns.Count > 0)
            {
                up = await Task.Run(() => up.IgnoreColumns(it => lstIgnoreColumns.Contains(it)));
            }
            if (lstColumns!=null&&lstColumns.Count>0)
            {
                up = await Task.Run(() => up.UpdateColumns(it => lstColumns.Contains(it)));
            }
            if (!string.IsNullOrEmpty(strWhere))
            {
                up = await Task.Run(() => up.Where(strWhere));
            }
            return await Task.Run(() => up.ExecuteCommand()) > 0;
        }
    }
}
