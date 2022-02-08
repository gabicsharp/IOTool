using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IOToolDataLibrary.Models.CustomTables
{
    public class NewRequestEditModel
    {
        public int Id { get; set; }

        [DisplayName("Status")]
        public string Status { get; set; }

        [DisplayName("Type")]
        public string RequestType { get; set; }

        [DisplayName("From")]
        public string From { get; set; }

        [DisplayName("To")]
        public string To { get; set; }

        [DisplayName("ETD")]
        public DateTime ETD { get; set; }

        [DisplayName("ETA")]
        public DateTime ETA { get; set; }

        [DisplayName("Number of pallets")]
        public int PalletNr { get; set; }

        [DisplayName("Weight (kg)")]
        public int Weight { get; set; }

        [DisplayName("Requester remakrs")]
        public string CommentRequester { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a value")]
        [DisplayName("Forwarder")]
        public int Id_Transporter { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a value")]
        [DisplayName("Transport type")]
        public int Id_TransportType { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a value")]
        [DisplayName("Material type")]
        public int Id_Material { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please write a value")]
        [DisplayName("AWB")]
        public string AWB { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please write a value")]
        [DisplayName("BillNr")]
        public string BillNr { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a price")]
        [DisplayName("Price (€)")]
        public decimal Price { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a value")]
        [DisplayName("Premium Freight")]
        public int PremiumFreight { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a value")]
        [DisplayName("Cost Center")]
        public int Id_CostCenter { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please write a comment")]
        [DisplayName("Comment")]
        public string CommentProcessor { get; set; }

        public int Id_RequestStatus { get; set; }
        public int Id_Processor { get; set; }

    }
}
