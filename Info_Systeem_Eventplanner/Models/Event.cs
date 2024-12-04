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
    }
}
