using Domain.Entities;
using Service.Patern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IVehiclewreckService:IService<vehicleswreck>
    {
        //void addVehiclewreck(vehicleswreck vehicleswreck);
        //void deleteVehiclewreck(vehicleswreck vehicleswreck);
        IEnumerable<vehicleswreck> GetAllVehicle();

        void SaveChange();
    }
}
