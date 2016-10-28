using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Back_end.Models
{
    public class Post
    {
        public int ID { get; set; }
        [Required]
        public string ApplicationUserID { get; set; }
        public int Longitude { get; set; }
        public int Latitude { get; set; }
        public string Text { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public DateTime DateTime { get; set; }
        public ICollection<PostPoint> Points { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<PostReport> Reports { get; set; }
    }
}