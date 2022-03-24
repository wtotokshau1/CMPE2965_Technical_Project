using System.ComponentModel.DataAnnotations;

namespace PetActivityTracker.Models
{
    public class User
    {
        //public int Id { get; set; }
        [Required]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
