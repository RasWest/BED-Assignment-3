using BED_Assignment_3.Data;
using BED_Assignment_3.Hubs;
using BED_Assignment_3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;


namespace BED_Assignment_3.Pages
{
    [Authorize("Receptionist")]
    public class ReceptionModel : PageModel
    {
        public IHubContext<Notification> _Notification;

        public ReceptionModel(IHubContext<Notification> Notification)
        {
            _Notification = Notification;
        }
        public Reservation Reservations { get; set; }
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
            [Display(Name = "Date")]
            public DateTime Date { get; set; }
        }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            Reservations = new Reservation
            {
                NumbersOfAdults = Input.NumbersOfAdults,
                NumbersOfChildren = Input.NumbersOfChildren,
                Date = Input.Date,
                RoomNumber = Input.RoomNumber
            };

            DbContextOptions<ApplicationDbContext> option = new DbContextOptions<ApplicationDbContext>();
            using (var context = new ApplicationDbContext(option))
            {
                if (!context.Reservations.Any(x => x.RoomNumber == Reservations.RoomNumber
                && x.Date == Reservations.Date))
                {
                    context.Reservations.Add(Reservations);
                    await context.SaveChangesAsync();
                    await _Notification.Clients.All.SendAsync("ReceiveMessage");
                }
            }

            return LocalRedirect("~/Reception");
        }

    }
    }
