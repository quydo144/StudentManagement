using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository_BaiTapLon
{
    public interface IRepositoryBase<T>
    {
        T GetByCondition(Expression<Func<T, bool>> expression);

        IEnumerable<T> GetByWhere(Expression<Func<T, bool>> expression);
        T Add(T entity);
        T Update(T entity);
        void Delete(object id);

    }
}
