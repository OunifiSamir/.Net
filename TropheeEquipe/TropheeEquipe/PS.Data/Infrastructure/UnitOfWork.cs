using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        IDataBaseFactory dbf;
        public UnitOfWork(IDataBaseFactory dbf)
        {
            this.dbf = dbf;
        }
        public void Commit()
        {
            dbf.DataContext.SaveChanges();
        }

        public void Dispose()
        {
            dbf.Dispose();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(dbf);
        }
    }
}
