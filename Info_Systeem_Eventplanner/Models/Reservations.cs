namespace Info_Systeem_Eventplanner.Models
{
    public class Reservations
    {
        public int ReservationId { get; set; }
        public int UserId { get; set; }
        public int TicketId     { get; set; }
        public int? Quantity { get; set; }
        public int? TotalPrice { get; set; }
    }
}
