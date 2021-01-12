using EntityFrameWork_BaiTapLon.DataAcces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository_BaiTapLon
{
    public class QLSinhVienRepository<T> : IQSinhVienRepository<T> where  T:class
    {
        private QLSVDatabaseContext databaseContext;
        public QLSinhVienRepository()
        {
            databaseContext = new QLSVDatabaseContext();
        }
        public T Add(T entity)
        {
            var result = databaseContext.Set<T>().Add(entity);
            databaseContext.SaveChanges();
            return result;
        }

        public void Delete(object id)
        {
            var resul = databaseContext.Set<T>().Find(id);
            if(resul != null)
            {
                databaseContext.Set<T>().Remove(resul);
                databaseContext.SaveChanges();
            }
        }

        public T GetByCondition(Expression<Func<T, bool>> expression)
        {
            return databaseContext.Set<T>().FirstOrDefault();
        }

        public T GetById(object id)
        {
            return databaseContext.Set<T>().Find(id);
        }

        public IEnumerable<T> GetByWhere(Expression<Func<T, bool>> expression)
        {

            return databaseContext.Set<T>().Where(expression);
        }

        public T Update(T entity)
        {
            var resul = databaseContext.Set<T>().Attach(entity);
            databaseContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            databaseContext.SaveChanges();
            return resul;
        }
    }
}
