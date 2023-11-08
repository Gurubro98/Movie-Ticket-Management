using System.ComponentModel.DataAnnotations;

namespace Movie_Ticket_Web_API.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Name is Required")]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$",
            ErrorMessage = "Name cann't contain extra space, Special Characters, and numeric Values")]
        [MinLength(3, ErrorMessage = "Name has atleast 3 Charcaters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
    ErrorMessage = "Please Enter a Valid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public bool IsAdmin { get; set; }
    }
}
