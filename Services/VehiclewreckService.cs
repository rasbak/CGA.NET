using Data.Infrastructure;
using Domain.Entities;
using Service.Patern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class VehiclewreckService : Service<vehicleswreck>, IVehiclewreckService
    {
        private static DatabaseFactory dbf = new DatabaseFactory();
        private static UnitOfWork ut = new UnitOfWork(dbf);

        public VehiclewreckService() : base(ut) { }

        public void GetSort(vehicleswreck va)
        {
            var rec = (from c in dbf.DataContext.vehiclewreck  select c).First();
            dbf.DataContext.SaveChanges();
        }

        //public void addVehiclewreck(vehicleswreck vehicleswreck)
        //{
        //    throw new NotImplementedException();
        //}



        //public void deleteVehiclewreck(vehicleswreck vehicleswreck)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}

            public int count()
        {
            return ut.GetRepository<vehicleswreck>().GetMany(i => i.id != 0).Count();
        }

        public void SaveChange()
        {
            ut.Commit();
        }

        IEnumerable<vehicleswreck> IVehiclewreckService.GetAllVehicle()
        {
            throw new NotImplementedException();
        }
    }
}

