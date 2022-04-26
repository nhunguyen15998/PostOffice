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
        List<BranchModel> GetListBranch();
        bool ModifyBranch(BranchModel mdl);
        string GetAddressBranch(int id);
        bool RemoveBranches(List<int> ls);
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
            var m = new Branch() { Address = mdl.address, CityId = mdl.cityId, Code = mdl.code, CreatedAt = DateTime.Now, Name = mdl.name, Phone = mdl.phone, ProvinceId = mdl.provinceId, WardId = mdl.wardId, Status = mdl.status };
            _context.Branches.Add(m);
            _context.SaveChanges();
            mdl.id = m.Id;
            return mdl;

        }
        public List<BranchModel> GetListBranch()
        {
            return _context.Branches.Select(x => new BranchModel() { id = x.Id, address = x.Address, cityId = (int)x.CityId, code = x.Code, createdAt = (DateTime)x.CreatedAt, name = x.Name, phone = x.Phone, provinceId = (int)x.ProvinceId, wardId = (int)x.WardId, status = x.Status }).ToList();
        }
        public bool ModifyBranch(BranchModel mdl)
        {
            var m = _context.Branches.FirstOrDefault(x => x.Id == mdl.id);
            if (m != null)
            {
                m.Address = mdl.address;
                m.CityId = mdl.cityId;
                m.CreatedAt = DateTime.Now;
                m.Name = mdl.name;
                m.Phone = mdl.phone;
                m.ProvinceId = mdl.provinceId;
                m.WardId = mdl.wardId;
                m.Status = mdl.status;
                _context.SaveChanges();
                    return true;
            }
            return false;
        }
        public string GetAddressBranch(int id)
        {
            var res = "";
            var m = _context.Branches.FirstOrDefault(x => x.Id == id);
            if (m != null)
            {
                res += m.Address + ", " + _context.VNWards.FirstOrDefault(x => x.Id == m.WardId).Name + ", " + _context.VNCities.FirstOrDefault(x => x.Id == m.CityId).Name + ", " + _context.VNStates.FirstOrDefault(x => x.Id == m.ProvinceId).Name;

            }
            return res;
        }
        public bool RemoveBranches(List<int> ls)
        {
            bool check = true;
            foreach (var item in ls)
            {
                var r = _context.Branches.FirstOrDefault(x => x.Id == item);
                if (r != null)
                {
                    var user = _context.Users.FirstOrDefault(x => x.BranchId == r.Id);
                    if (user == null )
                    {
                        _context.Branches.Remove(r);
                        _context.SaveChanges();
                    }
                    else
                    {
                        check = false;
                    }
                }
            }
            return check;
        }
    }
}
