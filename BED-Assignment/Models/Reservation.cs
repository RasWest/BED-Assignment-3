using System.ComponentModel.DataAnnotations;

namespace BED_Assignment_3.Models
{
    public class Reservation
    {
        public int RestaurantId { get; set; }
        [Required]

        [Display(Name = "Room number")]
        public int RoomNumber { get; set; }
        [Display(Name = "Number of adults")]
        public int NumberOfAdults { get; set; }
        [Display(Name = "Number of Children")]
        public int NumberOfChildren { get; set; }
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
        [Display(Name = "Checked in adults")]
        public int CheckedInAdults { get; set; }
        [Display(Name = "Checked in children")]
        public int CheckedInChildren { get; set; }

    }
}
