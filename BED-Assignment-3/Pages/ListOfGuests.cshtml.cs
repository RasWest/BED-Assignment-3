using BED_Assignment_3.Data;
using BED_Assignment_3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;




namespace BED_Assignment_3.Pages
{
    [Authorize("Receptionist")]

    public class ListOfGuestsModel : PageModel
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


                int checkedInAdult = 0;
                int checkedInChildren = 0;
                foreach (Reservation model in list)
                {
                    checkedInAdult += model.checkedInAdult;
                    checkedInChildren += model.checkedInChildren;
                }

                ViewData["CheckedInAdult"] = $"{checkedInAdult}";
                ViewData["CheckedInChildren"] = $"{checkedInChildren}";

            }
        }

    }
}
