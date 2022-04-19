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

        public ServiceModel SaveService(ServiceModel mdl)
        {
            return null;
        }
    }
}
