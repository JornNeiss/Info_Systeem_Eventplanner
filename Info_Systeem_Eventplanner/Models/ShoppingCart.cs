namespace Info_Systeem_Eventplanner.Models
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }

        public int UserId { get; set; }

        public int TicketId { get; set; }

        public int? Quantity { get; set; }

        public int? TotalPrice { get; set; } 
    }
}

