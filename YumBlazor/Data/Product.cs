using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YumBlazor.Data
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1,1000)]
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? SpecialTag { get; set; }
        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public virtual Category? Category { get; set; }
        public string? ImageUrl { get; set; }
    }
}
