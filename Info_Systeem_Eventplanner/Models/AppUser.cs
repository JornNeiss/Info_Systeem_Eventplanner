using System.ComponentModel.DataAnnotations;

namespace Info_Systeem_Eventplanner.Models
{
    public class AppUser
    {
        public int AppUserId { get; set; }
        public required string UserName { get; set; }
        public required string UserPasword { get; set; }
        public int? UserAge { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPhone { get; set; }
        public required bool IsAdmin { get; set; }
    }
}
