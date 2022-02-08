using System.ComponentModel.DataAnnotations;

namespace IOToolDataLibrary.Models
{
    public class SuppliersModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Please write a business name")]
        public string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a country")]
        public int Id_Country { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a city")]
        public int Id_City { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Please write an address")]
        public string Address { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Please write an zip code")]
        public string Zip { get; set; }

        public int Active { get; set; }

        public int Home { get; set; }

    }
}
