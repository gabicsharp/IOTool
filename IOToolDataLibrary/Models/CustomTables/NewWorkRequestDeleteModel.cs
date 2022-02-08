using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IOToolDataLibrary.Models.CustomTables
{
    public class NewWorkRequestDeleteModel
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string StatusRequest { get; set; }
        public int Id_StatusRequest { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Please write a comment")]
        [DisplayName("Comment")]
        public string Comment { get; set; }
    }
}
