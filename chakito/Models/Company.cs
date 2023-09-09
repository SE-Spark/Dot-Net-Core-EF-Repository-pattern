using System.ComponentModel.DataAnnotations;

namespace chakito.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required]
        public string? name { get; set; }

        [Required]
        public string? location { get; set; }
    }
}
