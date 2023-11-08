using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Ticket_Web_App.Models
{
    public class BookingCart
    {
        public int Id { get; set; }
        public int? MovieId { get; set; }
        public virtual Movie? Movie { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
    }
}
