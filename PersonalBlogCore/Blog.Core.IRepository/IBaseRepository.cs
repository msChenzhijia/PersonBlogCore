using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.IRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseRepository<T> where T:class
    {
        /// <summary>
        /// 通过id查询
        /// </summary>
        /// <param name="objId"></param>
        /// <returns></returns>
        Task<T> QueryById(object objId);        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objId"></param>
        /// <param name="blnUseCache"></param>
        /// <returns></returns>
        Task<T> QueryById(object objId, bool blnUseCache = false);
        /// <summary>
        /// 查询数据集
        /// </summary>        
        /// <param name="lstIds"></param>        
        /// <returns></returns>
        Task<List<T>> QueryByIds(object[] lstIds);
        /// <summary>
        /// 新增一条
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        Task<int> Add(T obj);
        /// <summary>
        /// 通过id删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> deleteById(object id);
        /// <summary>
        /// 通过实体删除        
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> delete(T model);
        /// <summary>
        /// 批量删除        
        /// </summary>
        /// <param name="lstIds"></param>
        /// <returns></returns>
        Task<bool> deleteByIds(object[] lstIds);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        Task<bool> Update(T obj);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        Task<bool> Update(T entity, string strWhere);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="lstColumns"></param>
        /// <param name="lstIgnoreColumns"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        Task<bool> Update(T entity, List<string> lstColumns = null, List<string> lstIgnoreColumns = null, string strWhere = "");
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        Task<List<T>> Query();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        Task<List<T>> Query(string strWhere);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        Task<List<T>> Query(Expression<Func<T, bool>> whereExpression);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="strOrderByFileds"></param>
        /// <returns></returns>
        Task<List<T>> Query(Expression<Func<T, bool>> whereExpression, string strOrderByFileds);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="orderByExpression"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        Task<List<T>> Query(Expression<Func<T, bool>> whereExpression, Expression<Func<T, object>> orderByExpression, bool isAsc = true);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="strOrderByFileds"></param>
        /// <returns></returns>
        Task<List<T>> Query(string strWhere, string strOrderByFileds);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="intTop"></param>
        /// <param name="strOrderByFileds"></param>
        /// <returns></returns>
        Task<List<T>> Query(Expression<Func<T, bool>> whereExpression, int intTop, string strOrderByFileds);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="intTop"></param>
        /// <param name="strOrderByFileds"></param>
        /// <returns></returns>
        Task<List<T>> Query(string strWhere, int intTop, string strOrderByFileds);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="intPageIndex"></param>
        /// <param name="intPageSize"></param>
        /// <param name="strOrderByFileds"></param>
        /// <returns></returns>
        Task<List<T>> Query(Expression<Func<T, bool>> whereExpression, int intPageIndex, int intPageSize, string strOrderByFileds);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="intPageIndex"></param>
        /// <param name="intPageSize"></param>
        /// <param name="strOrderByFileds"></param>
        /// <returns></returns>
        Task<List<T>> Query(string strWhere, int intPageIndex, int intPageSize, string strOrderByFileds);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="intPageIndex"></param>
        /// <param name="intPageSize"></param>
        /// <param name="strOrderByFileds"></param>
        /// <returns></returns>
        Task<List<T>> QueryPage(Expression<Func<T, bool>> whereExpression, int intPageIndex = 0, int intPageSize = 20, string strOrderByFileds = null);
    }
}

