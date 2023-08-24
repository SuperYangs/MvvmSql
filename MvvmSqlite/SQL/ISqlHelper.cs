using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Tool
{
    public interface ISqlHelper<T> where T : class, new()
    {

        void SetConnectionConfig(string sqlPath, DbType dbType);
        void CodeFirst();
        /// <summary>
        /// 增加单条数据
        /// </summary>
        /// <param name="model">实体对象</param>
        /// <returns>操作是否成功</returns>
        Task<bool> Add(T model);

        /// <summary>
        /// 增加多条数据
        /// </summary>
        /// <param name="list">实体集合</param>
        /// <returns>操作是否成功</returns>
        Task<bool> AddRange(List<T> list);

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="columns"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        Task<bool> UpdateDate(Expression<Func<T, T>> columns, Expression<Func<T, bool>> where);

        // <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        Task<List<T>> GetAll();
        ISugarQueryable<TResult> Select<TResult>(Expression<Func<T, TResult>> expression);
        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <returns></returns>
        Task<T> GetByWhereFirst(Expression<Func<T, bool>> where);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task<List<T>> GetByWhere(Expression<Func<T, bool>> where);
        Task<System.Data.DataTable> GetToDataTable(Expression<Func<T, bool>> where);

        Task<int> GetByCount(Expression<Func<T, bool>> where);

        Task<T> GetInSingle(object pkValue);

        Task<bool> DelelteInSingle(T pkValue);

        Task<int> DelelteByWhere(Expression<Func<T, bool>> where);
    }
}
