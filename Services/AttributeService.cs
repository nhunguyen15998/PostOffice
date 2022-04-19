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
        bool ModifyAttribute(AttributeModel model);
    }
    public class AttributeService : IAttributeService
    {
        private DataContext ct;
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
            var m = new Entities.Attribute() { Name = mdl.name, Type = mdl.type, CreatedAt = DateTime.Now };
            ct.Attributes.Add(m);
            ct.SaveChanges();
            mdl.id = m.Id;
            return mdl;
        }
        public List<AttributeModel> GetListAttribute()
        {
            var w= ct.Attributes.Select(x => new AttributeModel() { id = x.Id, name = x.Name, type = x.Type, createdAt = (DateTime)x.CreatedAt }).ToList();
            return w ?? null;
        }
        public bool ModifyAttribute(AttributeModel mdl)
        {
            var w = ct.Attributes.FirstOrDefault(x => x.Id == mdl.id);
            if (w != null)
            {
                w.Name = mdl.name;
                w.Type = mdl.type;
                ct.SaveChanges();
                return true;
            }

            return false;
        }
    }

}
