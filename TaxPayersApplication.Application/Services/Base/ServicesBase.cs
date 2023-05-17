using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaxPayersApplication.DataAccess.Repositories.Base;
using TaxPayersApplication.Domain.Base;

namespace TaxPayersApplication.Application.Services.Base
{
    public class ServicesBase<T> : IServicesBase<T> where T : BaseEntity, new()
    {
        protected readonly IBaseRepository<T> _repository;
        public ServicesBase(IBaseRepository<T> repository)
        {
            _repository = repository;
        }
        public virtual int Create(T entity) => _repository.Create(entity);
 
        public virtual void CreateRange(List<T> entity) => _repository.CreateRange(entity);

        public virtual void Delete(int Id) => _repository.Delete(Id);

        public virtual IQueryable<T> FindAll() => _repository.FindAll();

        public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => _repository.FindByCondition(expression);

        public virtual T GetOne(int Id) => _repository.GetOne(Id);
 
        public virtual T Update(T entity) => _repository.Update(entity);

        public bool Exist(Expression<Func<T, bool>> expression) => _repository.Exist(expression);

        public T LastOne() => _repository.LastOne();

        public void UpdateRange(List<T> entity) => _repository.UpdateRange(entity);

        public T FirstOrDefault(Expression<Func<T, bool>> expression) => _repository.FirstOrDefault(expression);
    }
}
