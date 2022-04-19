using post_office.Entities;
using post_office.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Services
{
  
        public interface IAttributeService
        {
            AttributeModel SaveAttribute(AttributeModel mdl);
            DataContext GetDataContext();
            List<AttributeModel> GetListAttribute();
        }
        public class AttributeService : IAttributeService
        {
            private  DataContext ct;
            public AttributeService(DataContext context)
            {
                ct = context;
            }
            public DataContext GetDataContext()
            {
                return ct;
            }
            public AttributeModel SaveAttribute(AttributeModel mdl)
            {
                ct.Attributes.Add(new Entities.Attribute() { Name = mdl.name, Type = mdl.type, CreatedAt = DateTime.Now });
                ct.SaveChanges();
                return mdl;
            }
        public List<AttributeModel> GetListAttribute()
        {
            return ct.Attributes.Select(x => new AttributeModel() { id = x.Id, name = x.Name, type=x.Type, createdAt = (DateTime)x.CreatedAt }).ToList();

        }
    }
    
}
