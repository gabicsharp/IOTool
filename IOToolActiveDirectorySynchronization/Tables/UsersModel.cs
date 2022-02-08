namespace IOToolActiveDirectorySynchronization.Tables
{
    public class UsersModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Function { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }
        public string CostCenter { get; set; }
        public string Email { get; set; }
        public string WindowsAccount { get; set; }
        public string AccountRights { get; set; }
        public int Active { get; set; }
    }
}
