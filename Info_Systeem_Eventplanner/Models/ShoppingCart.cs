namespace Info_Systeem_Eventplanner.Models
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }

        public int UserId { get; set; }

        public int TicketId { get; set; }

        public int? Quantity { get; set; }

        public int? TotalPrice { get; set; }

        // Navigatie naar AppUser
        public AppUser AppUser { get; set; }

        // Correcte naam van de collectie van Tickets
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
