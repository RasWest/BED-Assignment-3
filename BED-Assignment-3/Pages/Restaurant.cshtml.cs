using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using BED_Assignment_3.Data;
using BED_Assignment_3.Models;
using BED_Assignment_3.Hubs;


namespace BED_Assignment_3.Pages
{
    [Authorize("Restaurant")]
    public class RestaurantModel : PageModel
    {
        public Reservation Restaurants { get; set; }
        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();
        public class InputModel
        {
            [Display(Name = "Room number")]
            public int RoomNumber { get; set; }
            [Display(Name = "Adults")]
            public int NumbersOfAdults { get; set; }

            [Display(Name = "Children")]
            public int NumbersOfChildren { get; set; }
        }
        public IHubContext<Notification> _Notification;

        public RestaurantModel(IHubContext<Notification> Notification)
        {
            _Notification = Notification;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {


            DbContextOptions<ApplicationDbContext> option = new DbContextOptions<ApplicationDbContext>();
            using (var context = new ApplicationDbContext(option))
            {
                if (context.Reservations.Any(r => r.RoomNumber == Input.RoomNumber && r.Date == DateTime.Now.Date))
                {
                    Reservation Restaurants = await context.Reservations.FirstAsync(r => r.RoomNumber == Input.RoomNumber && r.Date == DateTime.Now.Date);

                    if (Restaurants.NumbersOfAdults <= Input.NumbersOfAdults && Restaurants.NumbersOfChildren <= Input.NumbersOfChildren)
                    {
                        Restaurants.checkedInAdult = Input.NumbersOfAdults;
                        Restaurants.checkedInChildren = Input.NumbersOfChildren;

                        await context.SaveChangesAsync();
                        await _Notification.Clients.All.SendAsync("ReceiveMessage");
                    }
                }
            }

            return LocalRedirect("~/Restaurant");

        }

    }
}
