using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace post_office.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public int? BranchId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int Status { get; set; }

        public Role Role { get; set; }
        public Branch Branch { get; set; }
    }
}