
using System.ComponentModel.DataAnnotations;
namespace Tutorials.Api.DTO
{
    public class LoginDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }



    }



}