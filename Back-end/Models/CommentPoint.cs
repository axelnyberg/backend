namespace Back_end.Models
{
    public class CommentPoint
    {
        public int ID { get; set; }
        public int CommentID { get; set; }
        public string ApplicationUserID { get; set; }
        public int value { get; set; }
    }
}