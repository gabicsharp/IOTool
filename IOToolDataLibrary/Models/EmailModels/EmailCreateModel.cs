using System;

namespace IOToolDataLibrary.Models.EmailModels
{
    public class EmailCreateModel
    {
        public int Id { get; set; }
        public string RequesterName { get; set; }
        public string RequesterEmail { get; set; }
        public string RequestType { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime ETD { get; set; }
        public DateTime ETA { get; set; }
        public string PalletNr { get; set; }
        public string Weight { get; set; }
        public string CommentRequester { get; set; }
        public string Requester { get; set; }
        public string Receiver { get; set; }
    }
}
