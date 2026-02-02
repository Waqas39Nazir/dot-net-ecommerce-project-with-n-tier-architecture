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

        [DisplayName("Image")]
        public string? ImageUrl { get; set; }

        //Creating a Relation between Product Table & Category Table
        // As Category Table is dependent on Product Table
        // There Category Table will have the foreign key
        [DisplayName("Category")]
        public int CategoryId { get; set; } // This is the foreign key name as CategoryId
        [ForeignKey("CategoryId")] // Foreign key constraint using Foreign Ket Data Annotation
        public Category Category { get; set; } // Reference to the Category Table for Foreign Key
    }
}