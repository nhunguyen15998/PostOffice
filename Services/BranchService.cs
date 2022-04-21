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
        IEnumerable<ReadBranchModel> GetBranchesByConditions(int cityId);
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
                                                    wardId = y.WardId,
                                                    wardName = x.wardName,
                                                    cityId = y.CityId, 
                                                    cityName = x.cityName,
                                                    provinceId = y.ProvinceId,
                                                    provinceName = x.stateName,
                                                    countryId = y.CountryId,
                                                    countryName = x.countryName,
                                                    statusValue = y.Status == (int)Helpers.Helpers.DefaultStatus.Activated ?
                                                            Helpers.Helpers.DefaultStatus.Activated.ToString() : Helpers.Helpers.DefaultStatus.Deactivated.ToString()
                                                })
                                                .Where(x => x.statusValue == Helpers.Helpers.DefaultStatus.Activated.ToString())
                                                .ToList<ReadBranchModel>();
                return branches;

            }catch(Exception ex){
                var a = ex.Message;
                throw;
            }
        }
        public IEnumerable<ReadBranchModel> GetBranchesByConditions(int cityId)
        {
            try{
                var branches = this.GetAll().Where(x => x.cityId == cityId).ToList();
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
