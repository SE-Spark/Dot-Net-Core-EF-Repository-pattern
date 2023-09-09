using System.ComponentModel.DataAnnotations;

namespace chakito.Models
{
    public class Person
    {
        public int ID { get; set; }
        [Required]
        public string? name { get; set; }
        [Required]
        public string? email { get; set; }   

    }
}
