using Blog.Core.IRepository;
using Blog.Core.IServices;
using Blog.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseServices<T> : IBaseServices<T> where T : class, new()
    {
        /// <summary>
        /// 
        /// </summary>
       public IBaseRepository<T> baseRepository;       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task<int> Add(T model)
        {
            return baseRepository.Add(model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task<bool> Delete(T model)
        {
            return baseRepository.delete(model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<bool> DeleteById(object id)
        {
            return baseRepository.deleteById(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public Task<bool> DeleteByIds(object[] ids)
        {
            return baseRepository.deleteByIds(ids);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<List<T>> Query()
        {
            return baseRepository.Query();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public Task<List<T>> Query(string strWhere)
        {
            return baseRepository.Query(strWhere);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public Task<List<T>> Query(Expression<Func<T, bool>> whereExpression)
        {
            return baseRepository.Query(whereExpression);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="strOrderByFileds"></param>
        /// <returns></returns>
        public Task<List<T>> Query(Expression<Func<T, bool>> whereExpression, string strOrderByFileds)
        {
            return baseRepository.Query(whereExpression, strOrderByFileds);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="orderByExpression"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public Task<List<T>> Query(Expression<Func<T, bool>> whereExpression, Expression<Func<T, object>> orderByExpression, bool isAsc = true)
        {
            return baseRepository.Query(whereExpression, orderByExpression, isAsc);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="strOrderByFileds"></param>
        /// <returns></returns>
        public Task<List<T>> Query(string strWhere, string strOrderByFileds)
        {
            return baseRepository.Query(strWhere, strOrderByFileds);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="intTop"></param>
        /// <param name="strOrderByFileds"></param>
        /// <returns></returns>
        public Task<List<T>> Query(Expression<Func<T, bool>> whereExpression, int intTop, string strOrderByFileds)
        {
            return baseRepository.Query(whereExpression, intTop, strOrderByFileds);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="intTop"></param>
        /// <param name="strOrderByFileds"></param>
        /// <returns></returns>
        public Task<List<T>> Query(string strWhere, int intTop, string strOrderByFileds)
        {
            return baseRepository.Query(strWhere, intTop, strOrderByFileds);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="intPageIndex"></param>
        /// <param name="intPageSize"></param>
        /// <param name="strOrderByFileds"></param>
        /// <returns></returns>
        public Task<List<T>> Query(Expression<Func<T, bool>> whereExpression, int intPageIndex, int intPageSize, string strOrderByFileds)
        {
            return baseRepository.Query(whereExpression, intPageIndex, intPageSize, strOrderByFileds);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="intPageIndex"></param>
        /// <param name="intPageSize"></param>
        /// <param name="strOrderByFileds"></param>
        /// <returns></returns>
        public Task<List<T>> Query(string strWhere, int intPageIndex, int intPageSize, string strOrderByFileds)
        {
            return baseRepository.Query(strWhere, intPageIndex, intPageSize, strOrderByFileds);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objId"></param>
        /// <returns></returns>
        public Task<T> QueryByID(object objId)
        {
            return baseRepository.QueryById(objId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objId"></param>
        /// <param name="blnUseCache"></param>
        /// <returns></returns>
        public Task<T> QueryByID(object objId, bool blnUseCache = false)
        {
            return baseRepository.QueryById(objId, blnUseCache);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstIds"></param>
        /// <returns></returns>
        public Task<List<T>> QueryByIDs(object[] lstIds)
        {
            return baseRepository.QueryByIds(lstIds);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="intPageIndex"></param>
        /// <param name="intPageSize"></param>
        /// <param name="strOrderByFileds"></param>
        /// <returns></returns>
        public Task<List<T>> QueryPage(Expression<Func<T, bool>> whereExpression, int intPageIndex = 0, int intPageSize = 20, string strOrderByFileds = null)
        {
            return baseRepository.QueryPage(whereExpression, intPageIndex, intPageSize, strOrderByFileds);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task<bool> Update(T model)
        {
            return baseRepository.Update(model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public Task<bool> Update(T entity, string strWhere)
        {
            return baseRepository.Update(entity,strWhere);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="lstColumns"></param>
        /// <param name="lstIgnoreColumns"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public Task<bool> Update(T entity, List<string> lstColumns = null, List<string> lstIgnoreColumns = null, string strWhere = "")
        {
            return baseRepository.Update(entity, lstColumns, lstIgnoreColumns, strWhere);
        }
    }
}
