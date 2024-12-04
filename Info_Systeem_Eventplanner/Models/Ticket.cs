namespace Info_Systeem_Eventplanner.Models
{
    public class Ticket
    {
        public int TicketId {  get; set; }
        public int EventID { get; set; }
        public int UserID { get; set; }
        public bool? IsReserved { get; set; }
    }
}
