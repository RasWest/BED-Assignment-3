using BED_Assignment_3.Data;
using BED_Assignment_3.Models;
using BED_Assignment_3.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BED_Assignment_3.Models;

namespace BED_Assignment_3.Pages;

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
        DbContextOptions<MorgenmadsBuffetDBContext> option = new DbContextOptions<MorgenmadsBuffetDBContext>();
        using (var context = new MorgenmadsBuffetDBContext(option))
        {
            var list = context.Reservations.Where(r => r.Date.Date == Input.Date.Date).ToList();

            int totalAdult = 0;
            int totalChildren = 0;
            int total = 0;
            int checkedInAdult = 0;
            int checkedInChildren = 0;
            int totalCheckedIn = 0;
            foreach (Resevation model in list)
            {
                totalAdult += model.NumberOfAdults;
                totalChildren += model.NumberOfChildren;
                total = total + totalChildren;
                checkedInAdult += model.CheckedInAdults;
                checkedInChildren += model.CheckedInChildren;
                totalCheckedIn = checkedInAdult + checkedInChildren;
            }

            ViewData["Adult"] = $"{totalAdult}";
            ViewData["Children"] = $"{totalChildren}";
            ViewData["Total"] = $"{total}";
            ViewData["CheckedInAdult"] = $"{checkedInAdult}";
            ViewData["CheckedInChildren"] = $"{checkedInChildren}";
            ViewData["CheckedInTotal"] = $"{totalCheckedIn}";
            ViewData["NotCheckedIn"] = $"{total - totalCheckedIn}";
        }
    }
}
