using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IOToolDataLibrary.Models
{
    public class TransportersModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Please write a business name")]
        [DisplayName("Transporter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please write a email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Please write a phone number")]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a country")]
        [DisplayName("Country")]
        public int Id_Country { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a city")]
        [DisplayName("City")]
        public int Id_City { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Please write an address")]
        [DisplayName("Address")]
        public string Address { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Please write an zip code")]
        [DisplayName("Zip")]
        public string Zip { get; set; }

        public string Alias { get; set; }

        public int Active { get; set; }
    }
}
