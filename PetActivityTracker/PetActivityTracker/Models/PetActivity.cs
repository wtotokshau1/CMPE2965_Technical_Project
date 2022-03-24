using System.ComponentModel.DataAnnotations;

namespace PetActivityTracker.Models
{
    public class PetActivity
    {
        [Required]
        public int PetActivityID { get; set; } 
        
        [Required]
        public int PetId { get; set; }

        [Required]
        public string Activity { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndTime { get; set; }

        [Required]
        public double Consumption { get; set; }

    }
}
