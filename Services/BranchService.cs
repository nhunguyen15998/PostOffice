using post_office.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using post_office.Entities;
using Microsoft.EntityFrameworkCore;

namespace post_office.Services
{
    public interface IBranchService
    {
        //client
        IEnumerable<ReadBranchModel> GetBranchesByConditions(int cityId, int branchId);
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
        public IEnumerable<ReadBranchModel> GetBranchesByConditions(int cityId, int branchId)
        {
            try{
                var branches = _context.Branches.Where(x => x.Status == (int)Helpers.Helpers.DefaultStatus.Activated)
                                                .Where(x => cityId != 0 ? x.CityId == cityId : true)
                                                .Where(x => branchId != 0 ? x.Id == branchId : true)
                                                .Select(y => new ReadBranchModel{
                                                    id = y.Id,
                                                    name = y.Name,
                                                    phone = y.Phone,
                                                    address = y.Address,
                                                    wardId = y.WardId,
                                                    wardName = y.Ward.Name,
                                                    cityId = y.CityId, 
                                                    cityName = y.City.Name,
                                                    provinceId = y.ProvinceId,
                                                    provinceName = y.Province.Name,
                                                    statusValue = y.Status == (int)Helpers.Helpers.DefaultStatus.Activated ?
                                                            Helpers.Helpers.DefaultStatus.Activated.ToString() : Helpers.Helpers.DefaultStatus.Deactivated.ToString()
                                                })
                                                .ToList();
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
