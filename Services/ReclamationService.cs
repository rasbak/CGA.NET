using Domain.Entities;
using Service.Patern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;

namespace Services
{
    public class ReclamationService : Service<report>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork utwk = new UnitOfWork(dbf);
        public ReclamationService() : base(utwk)
        {
        }
      
    }
}
