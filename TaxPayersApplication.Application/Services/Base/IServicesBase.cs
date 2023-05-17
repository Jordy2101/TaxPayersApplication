using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TaxPayersApplication.Application.Services.Base
{
    public interface IServicesBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        T FirstOrDefault(Expression<Func<T, bool>> expression);
        bool Exist(Expression<Func<T, bool>> expression);
        T GetOne(int Id);
        T LastOne();
        int Create(T entity);
        void CreateRange(List<T> entity);
        void UpdateRange(List<T> entity);
        T Update(T entity);
        void Delete(int Id);
    }
}
