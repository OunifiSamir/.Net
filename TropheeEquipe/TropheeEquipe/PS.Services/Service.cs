using PS.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace PS.Services
{
    public class Service<T> : IService<T> where T : class
    {
        readonly IUnitOfWork uow;
        readonly IRepository<T> repo;
        public Service(IUnitOfWork uow)
        {
            this.uow = uow;
            repo = uow.GetRepository<T>();
        }
        public void Add(T obj)
        {
            repo.Add(obj);
        }

        public void Commit()
        {
            uow.Commit();
        }

        public void Delete(T obj)
        {
            repo.Delete(obj);
        }

        public void Delete(Expression<Func<T, bool>> condition)
        {
            repo.Delete(condition);
        }

        public T Get(Expression<Func<T, bool>> condition)
        {
            return repo.Get(condition);
        }

        public IEnumerable<T> GetAll()
        {
            return repo.GetAll();
        }

        public T GetById(int id)
        {
            return repo.GetById(id);
        }

        public T GetById(string id)
        {
            return repo.GetById(id);
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> condition = null)
        {
            return repo.GetMany(condition);
        }

        public void Update(T obj)
        {
            repo.Update(obj);
        }
    }
}
