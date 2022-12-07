using System.Security.Claims;
using Microsoft.AspNetCore.Identity;



namespace BED_Assignment_3.Data
{
    public class SeedData
    {
        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            // User information
            const string UserEmail = "Mir@localhost.dk";
            const string receptionistPassword = "Mir1£";
            const string RestaurantEmail = "Zeyara@localhost.dk";
            const string RestaurantPassword = "Zeyara12£";

            // Overordnet tjek af userManager
            if (userManager == null)
                throw new ArgumentNullException(nameof(userManager));

            // Receptionist seed
            if (userManager.FindByNameAsync(UserEmail).Result == null)
            {
                var user = new IdentityUser();
                user.UserName = UserEmail;
                user.Email = UserEmail;
                user.EmailConfirmed = true;
                IdentityResult result = userManager.CreateAsync(user, receptionistPassword).Result;

                if (result.Succeeded)
                {
                    var receptionistUser = userManager.FindByNameAsync(UserEmail).Result;
                    var claims = new List<Claim>()
                    {
                        new Claim("Receptionist", "true"),

                    };
                    var claimAdded = userManager.AddClaimsAsync(receptionistUser, claims).Result;
                }
            }

            // Waiter seed
            if (userManager.FindByNameAsync(RestaurantEmail).Result == null)
            {
                var user = new IdentityUser();
                user.UserName = RestaurantEmail;
                user.Email = RestaurantEmail;
                user.EmailConfirmed = true;
                IdentityResult result = userManager.CreateAsync(user, RestaurantPassword).Result;

                if (result.Succeeded)
                {
                    var waiterUser = userManager.FindByNameAsync(RestaurantEmail).Result;
                    var claims = new List<Claim>()
                    {
                        new Claim("Restaurant", "true"),

                    };

                    var claimAdded = userManager.AddClaimsAsync(waiterUser, claims).Result;
                }

            }
        }

    }
}
