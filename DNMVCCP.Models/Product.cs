using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DNMVCCP.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Book Title")]
        [MinLength(2)]
        [MaxLength(30)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string ISBN { get; set; } = string.Empty;
        
        [Required]
        public string Author { get; set; } = string.Empty;

        [Required]
        [DisplayName("List Price")]
        [Range(1, 1000)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ListPrice { get; set; }
        
        [Required]
        [DisplayName("Price for 1-50")]
        [Range(1, 1000)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        
        [Required]
        [DisplayName("Price for 50+")]
        [Range(1, 1000)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price50 { get; set; }
        
        [Required]
        [DisplayName("Price for 100+")]
        [Range(1, 1000)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price100 { get; set; }
    }
}