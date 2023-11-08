using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Ticket_Web_API.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        [Display(Name = "Movie Name")]
        [Required(ErrorMessage = "Movie Name is Required")]
        [MinLength(2, ErrorMessage = "Movie Name contain  Charcater between 2 and 15")]

        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Date is Required")]
        public string? Date { get; set; }

        [Required(ErrorMessage = "Genre Name is Required")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Cast Name is Required")]
        public string Cast { get; set; }


        [ForeignKey("User")]
        public string? UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
