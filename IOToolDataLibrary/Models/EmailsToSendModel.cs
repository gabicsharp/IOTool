namespace IOToolDataLibrary.Models
{
    public class EmailsToSendModel
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Body { get; set; }
        public int Flag { get; set; }
    }
}
