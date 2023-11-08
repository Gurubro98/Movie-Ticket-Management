using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Ticket_Web_API.Models
{
    public class BookingCart
    {
        public int Id { get; set; }
        public int? MovieId { get; set; }
        public virtual Movie? Movie { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User? User { get; set;}
    }
}
