using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TaxPayersApplication.DataAccess.Repositories.Base
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        T FirstOrDefault(Expression<Func<T, bool>> expression);
        bool Exist(Expression<Func<T, bool>> expression);
        T GetOne(int Id);
        T LastOne();
        void CreateRange(List<T> entities);
        void UpdateRange(List<T> entity);
        int Create(T entity);
        T Update(T entity);
        void Delete(int Id);
    }
}
