namespace IOToolDataLibrary.Models
{
    public class SmtpModel
    {
        public int Id { get; set; }
        public string Server { get; set; }
        public int Port { get; set; }
        public string EmailSender { get; set; }
        public int Active { get; set; }
    }
}
