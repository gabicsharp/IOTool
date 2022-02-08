namespace IOToolDataLibrary.Models
{
    public class RequestsInfoModel
    {
        public int Id { get; set; }
        public int Id_Request { get; set; }
        public int Id_Requester { get; set; }
        public int Id_Processor { get; set; }
        public string IntervalHoursToPickUp { get; set; }
        public string CommentRequester { get; set; }
        public string CommentProcessor { get; set; }
        public string CommentRequesterForClose { get; set; }
        public string CommentProcessorForClose { get; set; }
        public int Id_RequestStatus { get; set; }
        public int PremiumFreight { get; set; }
    }
}
