namespace Info_Systeem_Eventplanner.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string? EventName { get; set; }
        public string? EventCategory { get; set; }
        public string? EventLocation { get; set; }
        public string? EventDescription { get; set; }
        public int? EventMaxVisitors { get; set; }

        public ICollection<Reservations> Reservations { get; set; } = new List<Reservations>();
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
