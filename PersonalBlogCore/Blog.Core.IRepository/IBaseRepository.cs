using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.IRepository
{
    public interface IBaseRepository<T> where T:class
    {
        //通过id查询
        Task<T> QueryById(object objId);        
        Task<T> QueryById(object objId, bool blnUseCache = false);
        //查询数据集
        Task<List<T>> QueryByIds(object[] lstIds);
        //新增一条
        Task<int> Add(T obj);        
        //通过id删除
        Task<int> deleteById(object id);
        //通过实体删除
        Task<int> delete(T model);
        //批量更新
        Task<int> deleteByIds(object[] lstIds);
        //更新
        Task<int> Update(T obj);
        Task<bool> Update(T entity, string strWhere);
        Task<bool> Update(T entity, List<string> lstColumns = null, List<string> lstIgnoreColumns = null, string strWhere = "");
        Task<List<T>> Query();
        Task<List<T>> Query(string strWhere);
        Task<List<T>> Query(Expression<Func<T, bool>> whereExpression);
        Task<List<T>> Query(Expression<Func<T, bool>> whereExpression, string strOrderByFileds);
        Task<List<T>> Query(Expression<Func<T, bool>> whereExpression, Expression<Func<T, object>> orderByExpression, bool isAsc = true);
        Task<List<T>> Query(string strWhere, string strOrderByFileds);
        Task<List<T>> Query(Expression<Func<T, bool>> whereExpression, int intTop, string strOrderByFileds);
        Task<List<T>> Query(string strWhere, int intTop, string strOrderByFileds);
        Task<List<T>> Query(
            Expression<Func<T, bool>> whereExpression, int intPageIndex, int intPageSize, string strOrderByFileds);
        Task<List<T>> Query(string strWhere, int intPageIndex, int intPageSize, string strOrderByFileds);
        Task<List<T>> QueryPage(Expression<Func<T, bool>> whereExpression, int intPageIndex = 0, int intPageSize = 20, string strOrderByFileds = null);
    }
}
}
