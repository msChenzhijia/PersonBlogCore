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
    public class BaseServices<T> : IBaseServices<T> where T : class, new()
    {
       public IBaseRepository<T> baseRepository;       
        public Task<int> Add(T model)
        {
            return baseRepository.Add(model);
        }

        public Task<bool> Delete(T model)
        {
            return baseRepository.delete(model);
        }

        public Task<bool> DeleteById(object id)
        {
            return baseRepository.deleteById(id);
        }

        public Task<bool> DeleteByIds(object[] ids)
        {
            return baseRepository.deleteByIds(ids);
        }

        public Task<List<T>> Query()
        {
            return baseRepository.Query();
        }

        public Task<List<T>> Query(string strWhere)
        {
            return baseRepository.Query(strWhere);
        }

        public Task<List<T>> Query(Expression<Func<T, bool>> whereExpression)
        {
            return baseRepository.Query(whereExpression);
        }

        public Task<List<T>> Query(Expression<Func<T, bool>> whereExpression, string strOrderByFileds)
        {
            return baseRepository.Query(whereExpression, strOrderByFileds);
        }

        public Task<List<T>> Query(Expression<Func<T, bool>> whereExpression, Expression<Func<T, object>> orderByExpression, bool isAsc = true)
        {
            return baseRepository.Query(whereExpression, orderByExpression, isAsc);
        }

        public Task<List<T>> Query(string strWhere, string strOrderByFileds)
        {
            return baseRepository.Query(strWhere, strOrderByFileds);
        }

        public Task<List<T>> Query(Expression<Func<T, bool>> whereExpression, int intTop, string strOrderByFileds)
        {
            return baseRepository.Query(whereExpression, intTop, strOrderByFileds);
        }

        public Task<List<T>> Query(string strWhere, int intTop, string strOrderByFileds)
        {
            return baseRepository.Query(strWhere, intTop, strOrderByFileds);
        }

        public Task<List<T>> Query(Expression<Func<T, bool>> whereExpression, int intPageIndex, int intPageSize, string strOrderByFileds)
        {
            return baseRepository.Query(whereExpression, intPageIndex, intPageSize, strOrderByFileds);
        }

        public Task<List<T>> Query(string strWhere, int intPageIndex, int intPageSize, string strOrderByFileds)
        {
            return baseRepository.Query(strWhere, intPageIndex, intPageSize, strOrderByFileds);
        }

        public Task<T> QueryByID(object objId)
        {
            return baseRepository.QueryById(objId);
        }

        public Task<T> QueryByID(object objId, bool blnUseCache = false)
        {
            return baseRepository.QueryById(objId, blnUseCache);
        }

        public Task<List<T>> QueryByIDs(object[] lstIds)
        {
            return baseRepository.QueryByIds(lstIds);
        }

        public Task<List<T>> QueryPage(Expression<Func<T, bool>> whereExpression, int intPageIndex = 0, int intPageSize = 20, string strOrderByFileds = null)
        {
            return baseRepository.QueryPage(whereExpression, intPageIndex, intPageSize, strOrderByFileds);
        }

        public Task<bool> Update(T model)
        {
            return baseRepository.Update(model);
        }

        public Task<bool> Update(T entity, string strWhere)
        {
            return baseRepository.Update(entity,strWhere);
        }

        public Task<bool> Update(T entity, List<string> lstColumns = null, List<string> lstIgnoreColumns = null, string strWhere = "")
        {
            return baseRepository.Update(entity, lstColumns, lstIgnoreColumns, strWhere);
        }
    }
}
