using YumBlazor.Data;

namespace YumBlazor.Utility
{
    public static class SD
    {
        public static string Role_Admin { get; set; } = "Admin";
        public static string Role_Customer { get; set; } = "Customer";

        public static string StatusPending = "Pending";
        public static string StatusReadyForPickUp = "ReadyForPickUp";
        public static string StatusCompleted = "Completed";
        public static string StatusCncelled = "Cancelled";

        public static List<OrderDetail> ConvertShoppingCartListToOrderDetail(List<ShoppingCart> shoppingCarts) 
        { 
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            foreach (var cart in shoppingCarts)
            {
                OrderDetail orderDetail = new OrderDetail
                {
                    ProductId = cart.ProductId,
                    Count = cart.Count,
                    Price = Convert.ToDouble(cart.Product.Price),
                    productName = cart.Product.Name,
                };
                orderDetails.Add(orderDetail);
            }
            return orderDetails;
        }   
    }
}
