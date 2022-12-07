using BED_Assignment_3.Data;
using BED_Assignment_3.Hubs;
using BED_Assignment_3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BED_Assignment_3.Pages
{ 
public class KitchenModel : PageModel
{

    [BindProperty]
    public InputModel Input { get; set; } = new InputModel();

    public class InputModel
    {
        public DateTime Date { get; set; } = DateTime.Now.Date;
    }

    public void OnPost()
    {
        OnGet();
    }

        public void OnGet()
        {
            DbContextOptions<ApplicationDbContext> option = new DbContextOptions<ApplicationDbContext>();
            using (var context = new ApplicationDbContext(option))
            {
                var list = context.Reservations.Where(r => r.Date.Date == Input.Date.Date).ToList();

                int totalAdult = 0;
                int totalChildren = 0;
                int checkedInAdult = 0;
                int checkedInChildren = 0;
                foreach (Reservation model in list)
                {
                    totalAdult += model.NumbersOfAdults;
                    totalChildren += model.NumbersOfChildren;
                    checkedInAdult += model.checkedInAdult;
                    checkedInChildren += model.checkedInChildren;
                }

                ViewData["Adult"] = $"{totalAdult}";
                ViewData["Children"] = $"{totalChildren}";
                ViewData["Total"] = $"{totalAdult + totalChildren}";
                ViewData["CheckedInAdult"] = $"{checkedInAdult}";
                ViewData["CheckedInChildren"] = $"{checkedInChildren}";
                ViewData["CheckedInTotal"] = $"{checkedInAdult + checkedInChildren}";
                ViewData["NotCheckedIn"] = $"{(totalAdult + totalChildren) - (checkedInAdult + checkedInChildren)}";
            }
        }  }
}