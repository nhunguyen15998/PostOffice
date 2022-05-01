using post_office.Entities;
using post_office.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Services
{
    public interface IContactServices
    {
        DataContext GetDataContext();
        void SendMessage(ContactModel mdl);
        List<ContactModel> GetListContact();

    }
    public class ContactService : IContactServices
    {
        private DataContext ct;
        public ContactService(DataContext context)
        {
            ct = context;
        }
        public DataContext GetDataContext()
        {
            return ct;
        }
        public void SendMessage(ContactModel mdl)
        {
            var w = new Contact() { Email = mdl.email, CreatedAt = DateTime.Now, IsRead = false, IsReplied = false, Message = mdl.message, Name = mdl.name, Phone = mdl.phone, Subject = mdl.subject, ReplierId = null};
            ct.Contacts.Add(w);
            ct.SaveChanges();
        }
        public List<ContactModel> GetListContact()
        {
            return ct.Contacts.Select(x => new ContactModel() { id = x.Id, createdAt = (DateTime)x.CreatedAt, email = x.Email, isRead = x.IsRead, isReply = x.IsReplied, message = x.Message, name = x.Name, phone = x.Phone, ReplierId = x.ReplierId, subject = x.Subject }).ToList();
        }
    }

    }
