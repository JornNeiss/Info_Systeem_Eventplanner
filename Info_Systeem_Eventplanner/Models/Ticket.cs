using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Info_Systeem_Eventplanner.Models
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }

        [ForeignKey("Event")]
        public int EventID { get; set; } // Foreignkey Event 
        public Event Event { get; set; } // Navigatie naar Event

        [Required]
        public float TicketPrice { get; set; }

        public bool? IsReserved { get; set; }
    }
}

