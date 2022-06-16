using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Data.Infrastructure
{
    public class DataBaseFactory : Disposable, IDataBaseFactory
    {
        readonly PSContext dataContext;
        public PSContext DataContext => dataContext;
        public DataBaseFactory()
        {
            dataContext = new PSContext();
        }

        //protected override void DisposeCore()
        //{
        //    if (DataContext != null)
        //        DataContext.Dispose();
        //}
    }
}
