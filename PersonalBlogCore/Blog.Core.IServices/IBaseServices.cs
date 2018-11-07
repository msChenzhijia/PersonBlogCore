using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.IServices
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseServices<T>where T:class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objId"></param>
        /// <returns></returns>
        Task<T> QueryByID(object objId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objId"></param>
        /// <param name="blnUseCache"></param>
        /// <returns></returns>
        Task<T> QueryByID(object objId, bool blnUseCache = false);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstIds"></param>
        /// <returns></returns>
        Task<List<T>> QueryByIDs(object[] lstIds);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<int> Add(T model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteById(object id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> Delete(T model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<bool> DeleteByIds(object[] ids);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> Update(T model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        Task<bool> Update(T entity, string strWhere);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="lstColumns"></param>
        /// <param name="lstIgnoreColumns"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        Task<bool> Update(T entity, List<string> lstColumns = null, List<string> lstIgnoreColumns = null, string strWhere = "");
        /// <summary>
        /// 
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
