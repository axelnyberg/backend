namespace Back_end.Models
{
    public class PostReport
    {
        public int ID { get; set; }
        public int PostID { get; set; }
        public string ApplicationUserID { get; set; }
        public string text { get; set; }
    }
}