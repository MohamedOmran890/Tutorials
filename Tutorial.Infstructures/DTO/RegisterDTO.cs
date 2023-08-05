
using System.ComponentModel.DataAnnotations;
namespace Tutorial.Infstructures.DTO
{

    public class RegisterDTO
    {

        [Required]
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]

        public string PhoneNumber { get; set; }
        [Required]
        public bool Gender { get; set; }

        public int Age { get; set; }




    }


}