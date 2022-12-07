using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BED_Assignment_3.Models
{
    public class Reservation
    {
        public int RestaurantId { get; set; }
        [Required]
        [Display(Name = "Room number")]
        public int RoomNumber { get; set; }
        [Display(Name = "Adults")]
        public int NumbersOfAdults { get; set; }
        [Display(Name = "Children")]
        public int NumbersOfChildren { get; set; }
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
        [Display(Name = "checkedInAdult")]
        public int checkedInAdult { get; set; }
        [Display(Name = "checkedInChildren")]
        public int checkedInChildren { get; set; }

    }
}
