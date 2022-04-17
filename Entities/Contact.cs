using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace post_office.Entities
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime? CreatedAt { get; set; }
        [DefaultValue(0)]
        public int IsRead { get; set; }
        [DefaultValue(0)]
        public int IsReplied { get; set; }
        public int ReplierId { get; set; }

        public User Replier { get; set; }
    }
}