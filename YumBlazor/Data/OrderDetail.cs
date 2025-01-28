using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YumBlazor.Data
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderHeaderId { get; set; }
        [ForeignKey(nameof(OrderHeaderId))]
        public OrderHeader  OrderHeader { get; set; }
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product  Product { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]

        public double Price { get; set; }
        [Required]

        public string productName { get; set; }

    }
}
