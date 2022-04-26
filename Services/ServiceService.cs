using post_office.Entities;
using post_office.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Services
{
    public interface IServiceService
    {
        ServiceModel SaveService(ServiceModel mdl);
        IEnumerable<ServiceModel> GetServiceById(int serviceId);
        List<ServiceModel> GetListService();
        ServiceModel GetService(int id);
        bool ModifyService(ServiceModel model);
        bool RemoveServices(List<int> ls);
    }
    public class ServiceService : IServiceService
    {
        private DataContext _context;
        public ServiceService (DataContext ct)
        {
            _context = ct;
        }

        public ServiceModel SaveService(ServiceModel mdl)
        {
           var w =new Service() { Name = mdl.name, Content = mdl.content, CreatedAt = DateTime.Now, Status = mdl.status };
            _context.Services.Add(w);
            _context.SaveChanges();
            mdl.id =w.Id ;
            return mdl;
        }

        public IEnumerable<ServiceModel> GetServiceById(int serviceId)
        {
            try{
                return _context.Services.Where(x => serviceId != 0 ? x.Id == serviceId : true)
                                        .Where(x => x.Status == (int) Helpers.Helpers.DefaultStatus.Activated)
                                        .Select(x => new ServiceModel{id = x.Id, name = x.Name}).ToList();
            }catch(Exception ex){
                var a = ex.Message;
                throw;
            }
        }

        public bool ModifyService(ServiceModel model)
        {
            var w = _context.Services.FirstOrDefault(x => x.Id == model.id);
            if (w != null)
            {
                w.Name = model.name;
                w.Content = model.content;
                w.Status = model.status;
                _context.SaveChanges();
                return true;
            }
            return false;

        }

        public List<ServiceModel> GetListService()
        {
            var w= _context.Services.Select(mdl => new ServiceModel() {id=mdl.Id, name = mdl.Name, content = mdl.Content, createdAt =(DateTime)mdl.CreatedAt, status = mdl.Status }).ToList();
            return w;
        }
        public ServiceModel GetService(int id)
        {
            return _context.Services.Select(mdl => new ServiceModel() { id = mdl.Id, name = mdl.Name, content = mdl.Content, createdAt = (DateTime)mdl.CreatedAt, status = mdl.Status }).FirstOrDefault(x => x.id == id);
        }
        public bool  RemoveServices(List<int> ls)
        {
            bool check = true;
            foreach (var item in ls)
            {
                var r = _context.Services.FirstOrDefault(x => x.Id == item);
                if (r != null)
                {
                    
                        _context.Services.Remove(r);
                        _context.SaveChanges();
                   
                }
            }
            return check;
        }
    }
}
