using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IOToolDataLibrary.Models
{
    public class PricesModel
    {
        public int Id { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a transporter")]
        [DisplayName("Transporter")]
        public int Id_Transporter{ get; set; }


        public string LaneName { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a country")]
        [DisplayName("Origin Country")]
        public int Id_OriginCountry { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a city")]
        [DisplayName("Origin City")]
        public int Id_OriginCity { get; set; }


        public int Id_OriginZip { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a country")]
        [DisplayName("Destination Country")]
        public int Id_DestinationCountry { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a city")]
        [DisplayName("Destination City")]
        public int Id_DestinationCity { get; set; }

        public int Id_DestinationZip { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a type")]
        [DisplayName("Direction / Request Type")]
        public int Id_RequestType { get; set; }
        public int Id_PartnerLocation { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please write a positive value")]
        [DisplayName("Minimum (€)")]
        public decimal Minimum { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please write a positive value")]
        [DisplayName("1-4 Pallets Inclusiv (€)")]
        public decimal From1To4Pallets { get; set; }


        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please write a positive value")]
        [DisplayName("5-8 Pallets Inclusiv (€)")]
        public decimal From5To8Pallets { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please write a positive value")]
        [DisplayName("9-12 Pallets Inclusiv (€)")]
        public decimal From9To12Pallets { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please write a positive value")]
        [DisplayName("13-16 Pallets Inclusiv (€)")]
        public decimal From13To16Pallets { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please write a positive value")]
        [DisplayName("17-20 Pallets Inclusiv (€)")]
        public decimal From17To20Pallets { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please write a positive value")]
        [DisplayName("21-24 Pallets Inclusiv (€)")]
        public decimal From21To24Pallets { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please write a positive value")]
        [DisplayName("25-28 Pallets Inclusiv (€)")]
        public decimal From25To28Pallets { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please write a positive value")]
        [DisplayName("29-32 Pallets Inclusiv (€)")]
        public decimal From29To32Pallets { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please write a positive value")]
        [DisplayName("33-36 Pallets Inclusiv (€)")]
        public decimal From33To36Pallets { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please write a positive value")]
        [DisplayName("37-40 Pallets Inclusiv (€)")]
        public decimal From37To40Pallets { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please write a positive value")]
        [DisplayName("41-44 Pallets Inclusiv (€)")]
        public decimal From41To44Pallets { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please write a positive value")]
        [DisplayName("45-48 Pallets Inclusiv (€)")]
        public decimal From45To48Pallets { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please write a positive value")]
        [DisplayName("49-52 Pallets Inclusiv (€)")]
        public decimal From49To52Pallets { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please write a positive value")]
        [DisplayName("53-56 Pallets Inclusiv (€)")]
        public decimal From53To56Pallets { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please write a positive value")]
        [DisplayName("57-60 Pallets Inclusiv (€)")]
        public decimal From57To60Pallets { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please write a positive value")]
        [DisplayName("61-64 Pallets Inclusiv (€)")]
        public decimal From61To64Pallets { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please write a positive value")]
        [DisplayName("Maximum (€)")]
        public decimal Maximum { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Please write a value")]
        [DisplayName("Shipment Frequency LTL")]
        public string ShipmentFrequencyLTL { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please write a positive value")]
        [DisplayName("Transit Time Groupage (hours)")]
        public int TransitTimeGroupage { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please write a positive value")]
        [DisplayName("Transit Time LTL (hours)")]
        public int TransitTimeLTL { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please write a comment")]
        [DisplayName("Comments LTL")]
        public string CommentsLTL { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please write a positive value")]
        [DisplayName("3.5 tons (€)")]
        public decimal Tons3_5 { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please write a positive value")]
        [DisplayName("Transit time for 3.5 tons (hours)")]
        public int TransitTime3_5Tons { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please write a comment")]
        [DisplayName("Shipment Frequency 3.5 tons")]
        public string ShipmentFrequency3_5Tons { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please write a positive value")]
        [DisplayName("7.5 tons (€)")]
        public decimal Tons7_5 { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please write a comment")]
        [DisplayName("Shipment Frequency 7.5 tons")]
        public string ShipmentFrequency7_5Tons { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please write a positive value")]
        [DisplayName("24 tons (€)")]
        public decimal Tons24 { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please write a comment")]
        [DisplayName("Shipment Frequency 24 tons")]
        public string ShipmentFrequency24Tons { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please write a positive value")]
        [DisplayName("Transit Time FTL (hours)")]
        public int TransitTimeFTL { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please write a comment")]
        [DisplayName("Comments FTL")]
        public string CommentsFTL { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please write a positive value")]
        [DisplayName("Active")]
        public int Active { get; set; }

    }
}
