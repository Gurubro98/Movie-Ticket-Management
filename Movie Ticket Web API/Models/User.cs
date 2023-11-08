using Microsoft.AspNetCore.Identity;

namespace Movie_Ticket_Web_API.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public virtual ICollection<Movie>? Movie { get; set; }
    }
}
