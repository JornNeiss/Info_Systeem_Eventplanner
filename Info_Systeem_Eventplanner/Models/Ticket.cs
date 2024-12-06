namespace Info_Systeem_Eventplanner.Models
{
    public class Ticket
    {
        public required int TicketId {  get; set; }
        public required int EventID { get; set; }
        public required float TicketPrice { get; set; }
        public required int UserID { get; set; }
        public bool? IsReserved { get; set; }
    }
}
