using System;

namespace IOToolDataLibrary.Models.EmailModels
{
    public class EmailUpdateModel
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string RequestType { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string RequesterName { get; set; }
        public string RequesterEmail { get; set; }
        public string RequesterComment { get; set; }
        public string ProcessorName { get; set; }
        public string ProcessorEmail { get; set; }
        public string ProcessorComment { get; set; }
        public string AWB { get; set; }
        public decimal Price { get; set; }
        public string TransportType { get; set; }
        
    }
}
