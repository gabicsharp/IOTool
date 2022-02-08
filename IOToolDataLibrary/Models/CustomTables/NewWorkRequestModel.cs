namespace IOToolDataLibrary.Models.CustomTables
{
    public class NewWorkRequestModel
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string StatusRequest { get; set; }
        public int Id_StatusRequest { get; set; }
    }
}
