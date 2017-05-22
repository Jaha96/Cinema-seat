using Microsoft.AspNet.Identity.EntityFramework;

namespace EntertainmentWorldTicket.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}