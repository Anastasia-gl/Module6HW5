using System.ComponentModel.DataAnnotations;

namespace Module6HW5.Models
{
    public class RegisterUser
    {
        [Required]
        public string UserName { get;set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get;set; }

        [Required]
        [Compare("Password", ErrorMessage = "Confirm Password")]
        public string ConfirmPassword { get;set; }
    }
}
