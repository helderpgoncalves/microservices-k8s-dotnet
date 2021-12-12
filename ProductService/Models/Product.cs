using System.ComponentModel.DataAnnotations;

namespace ProductService.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public key Description { get; set; }

        [Required]
        public string Price { get; set; }

        [Required]
        public string Category { get; set; }
    }
}
