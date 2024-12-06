namespace Info_Systeem_Eventplanner.Models
{
    public class Reservations
    {
        public int ReservationId { get; set; }
        public int EventId   { get; set; }
        public int UserId { get; set; }
        public int TicketId     { get; set; }
        public int? Quantity { get; set; }
        public int? TotalPrice { get; set; }

        public AppUser AppUser { get; set; }
        public Event Event { get; set; }
        public ICollection<Ticket> Ticket { get; set; } = new List<Ticket>();
       
    }
}
