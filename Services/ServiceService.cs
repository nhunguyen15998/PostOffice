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
    }
}
