using System.ComponentModel.DataAnnotations;

namespace PetActivityTracker.Models
{
    public class Users
    {
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
