using PS.Data.Infrastructure;
using PS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Services
{
   public class TropheeService : Service<Trophee> , ITropheeService
    {
        public TropheeService(IUnitOfWork uow) : base(uow)
        {

        }
    }
}
