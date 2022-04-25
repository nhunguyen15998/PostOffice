using post_office.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Services
{
    public interface IAddressServices
    {
        DataContext GetDataContext();
        List<VNState> GetListStates();
        List<VNCity> GetListCityByStateID(int stateID);
        List<VNWard> GetListWardByCityID(int cityID);

    }
    public class AddressServices : IAddressServices
    {
        private DataContext ct;
        public AddressServices(DataContext context)
        {
            ct = context;
        }
        public DataContext GetDataContext()
        {
            return ct;
        }

        public List<VNState> GetListStates()
        {
            var w= ct.VNStates.OrderBy(x=>x.Name).ToList();
            return w;
        }
        public List<VNCity> GetListCityByStateID(int stateID)
        {
            return ct.VNCities.Where(x => x.StateId == stateID).OrderBy(x => x.Name).ToList();
        }
        public List<VNWard> GetListWardByCityID(int cityID)
        {
            return ct.VNWards.Where(x => x.CityId == cityID).OrderBy(x => x.Name).ToList();
        }


    }
}
