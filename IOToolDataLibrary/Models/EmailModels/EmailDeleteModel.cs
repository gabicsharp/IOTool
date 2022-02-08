namespace IOToolDataLibrary.Models.EmailModels
{
    public class EmailDeleteModel
    {
        public int Id { get; set; }
        public string RequestType { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string RequesterName { get; set; }
        public string RequesterEmail { get; set; }
        public string RequesterCommentForClose { get; set; }
        public string ProcessorName { get; set; }
        public string ProcessorEmail { get; set; }
        public string CommentProcessorForClose { get; set; }

    }
}
