using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Data.Infrastructure
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<T> GetRepository<T>() where T:class;
        void Commit();
    }
}
