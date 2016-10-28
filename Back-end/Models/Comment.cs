using System;
using System.Collections.Generic;

namespace Back_end.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public int PostID { get; set; }
        public string ApplicationUserID { get; set; }
        public string Text { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public ICollection<CommentPoint> Points { get; set; }
        public DateTime DateTime { get; set; }
        public ICollection<CommentReport> Reports { get; set; }
    }
}