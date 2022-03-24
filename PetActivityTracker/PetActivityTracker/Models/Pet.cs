using System.ComponentModel.DataAnnotations;

namespace PetActivityTracker.Models
{
    public class Pet
    {
        [Required]
        public int PetId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string PetName { get; set; }

        public int FoodConsumption { get; set; }
        public int WaterConsumption { get; set; }

    }
}
