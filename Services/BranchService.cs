using post_office.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using post_office.Entities;

namespace post_office.Services
{
    public interface IBranchService
    {
        //client
        IEnumerable<ReadBranchModel> GetAll();
        BranchModel SaveBranch(BranchModel mdl);
    }

    public class BranchService : IBranchService
    {
        private DataContext _context;

        public BranchService(DataContext context)
        {
            _context = context;
        }
        
        //client
        public IEnumerable<ReadBranchModel> GetAll()
        {
            try{
                var branches = _context.Wards.Join(_context.Cities, x => x.city_id, y => y.id, (x, y) => new {wardName = x.name, cityName = y.name, stateId = y.state_id})
                                                .Join(_context.States, x => x.stateId, y => y.id, (x, y) => new {wardName = x.wardName, cityName = y.name, stateName = y.name, countryId = y.country_id})
                                                .Join(_context.Countries, x => x.countryId, y => y.id, (x, y) => new {wardName = x.wardName, cityName = y.name, stateName = y.name, countryName = y.name, countryId = y.id})
                                                .Join(_context.Branches, x => x.countryId, y => y.CountryId, (x, y) => new ReadBranchModel{
                                                    id = y.Id,
                                                    name = y.Name,
                                                    phone = y.Phone,
                                                    //headUserName = y.,
                                                    address = y.Address,
                                                    wardName = x.wardName,
                                                    cityName = x.cityName,
                                                    provinceName = x.stateName,
                                                    countryName = x.countryName,
                                                    statusValue = y.Status == (int)Helpers.Helpers.DefaultStatus.Activated ?
                                                            Helpers.Helpers.DefaultStatus.Activated.ToString() : Helpers.Helpers.DefaultStatus.Deactivated.ToString()
                                                })
                                                .ToList<ReadBranchModel>();
                return branches;

            }catch(Exception ex){
                var a = ex.Message;
                throw;
            }
        }

        public BranchModel SaveBranch(BranchModel mdl)
        {
            return null;
        }
    }
}
