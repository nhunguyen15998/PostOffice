using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace post_office.Entities
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public int Title { get; set; }
        public string Thumbnail { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedAt { get; set; }

    }
}