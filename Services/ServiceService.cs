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
        IEnumerable<ServiceModel> GetService(int serviceId);
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
           mdl.id =w.Id ;
            return mdl;
        }

        public IEnumerable<ServiceModel> GetService(int serviceId)
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
    }
}
