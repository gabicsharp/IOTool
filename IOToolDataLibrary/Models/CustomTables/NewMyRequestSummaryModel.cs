using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IOToolDataLibrary.Models.CustomTables
{
    public class NewMyRequestSummaryModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Please enter a value")]
        [DisplayName("Type")]
        public string RequestType { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Please enter a value")]
        [DisplayName("From")]
        public string From { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Please enter a value")]
        [DisplayName("To")]
        public string To { get; set; }

        [Required]
      //  [MinLength(8, ErrorMessage = "Please select a date")]
        [DisplayName("ETD")]
        public DateTime ETD { get; set; }

        [Required]
      //  [MinLength(8, ErrorMessage = "Please select a date")]
        [DisplayName("ETA")]
        public DateTime ETA { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive value")]
        [DisplayName("Nr Pallets")]
        public int PalletNr { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive value")]
        [DisplayName("Weight")]
        public int Weight { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Please enter a comment")]
        [DisplayName("Comment")]
        public string CommentRequester { get; set; }

        [DisplayName("Status")]
        public string Status { get; set; }
    }
}
