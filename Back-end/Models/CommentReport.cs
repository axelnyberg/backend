namespace Back_end.Models
{
    public class CommentReport
    {
        public int ID { get; set; }
        public int CommentID { get; set; }
        public string ApplicationUserID { get; set; }
        public string text { get; set; }
    }
}