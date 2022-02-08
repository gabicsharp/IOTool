using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IOToolDataLibrary.Models.CustomTables
{
    public class NewRequestModel
    {
        public int Id { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a type")]
        [DisplayName("Type")]
        public int RequestTypeId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a location")]
        [DisplayName("From")]
        public int FromId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a location")]
        [DisplayName("To")]
        public int ToId { get; set; }

        //[Required(ErrorMessage = "Please select a date")]
        [DisplayName("Estimated Time of Departure (ETD)")]
        public DateTime ETD { get; set; }


        //[Required(ErrorMessage = "Please select a date")]
        [DisplayName("Estimated Time of Arrival (ETA)")]
        public DateTime ETA { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a number")]
        [DisplayName("Number of pallets (max 64)")]
        public int NrPallets { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a weight in kg")]
        [DisplayName("Weight for all pallets (max 24000 kg)")]
        public int Weight { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Please write a value")]
        [DisplayName("Remarks")]
        public string CommentRequester { get; set; }

        //[Required]
        //[Range(1, int.MaxValue, ErrorMessage = "Please press on calculate button")]
        [DisplayName("Price (€)")]
        public decimal Price { get; set; }

        //[Required]
        //[Range(1, int.MaxValue, ErrorMessage = "Please press on calculate button")]
        [DisplayName("Price per pallet (€)")]
        public decimal PricePallet { get; set; }

        public int PremiumFreight { get; set; }
    }
}
