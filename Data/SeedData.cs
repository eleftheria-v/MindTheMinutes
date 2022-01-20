using Meeting_Minutes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Meeting_Minutes.Data
{
    public class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {

                // For sample purposes seed both with the same password.
                // Password is set with the following:
                // dotnet user-secrets set SeedUserPW <pw>
                // The admin user can do anything

                var adminID = await EnsureUser(serviceProvider, "123456", "admin@admin.com","Jason","Statham","1111111111");
                await EnsureRole(serviceProvider, adminID, "Administrator");  // Seeds an Administrator and User role

                var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();
                if (roleManager.FindByNameAsync("User").Result != null)
                {
                    await roleManager.CreateAsync(new IdentityRole("User"));
                }

                SeedDB(context);
            }
        }

        private static async Task<string> EnsureUser(IServiceProvider serviceProvider,
                                            string testUserPw, string UserName, string Firstname, string Lastname, string PhoneNumber)
        {
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                user = new ApplicationUser { UserName = UserName, Firstname = Firstname, Lastname = Lastname, PhoneNumber = PhoneNumber };
                await userManager.CreateAsync(user, testUserPw);
            }

            return user.Id;
        }

        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider,
                                                                      string uid, string role)
        {
            IdentityResult IR = null;
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (roleManager == null)
            {
                throw new Exception("roleManager null");
            }

            // User role
            if (!await roleManager.RoleExistsAsync("User"))
            {
                IR = await roleManager.CreateAsync(new IdentityRole("User"));
            }

            // Administrator role
            if (!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new IdentityRole(role));
            }

            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByIdAsync(uid);

            IR = await userManager.AddToRoleAsync(user, role);

            return IR;
        }

        public static void SeedDB(ApplicationDbContext context)
        {
            if (context.Meetings.FirstOrDefault(m => m.Title == "My Seeded Test Meeting") == null 
                && context.Meetings.FirstOrDefault(m => m.Title == "My Second Seeded Test Meeting") == null)
            {
                context.Add<Meeting>(new Meeting { Title = "My Seeded Test Meeting",
                                                    CreatedBy = "jimmy", 
                                                    Participants = "someRandomPeopleIPaidForTestings",
                                                    CreatedDate = DateTime.Now, 
                                                    DateUpdated = DateTime.Now,
                                                    MeetingDate = DateTime.Today.AddDays(1) });

                context.Add<Meeting>(new Meeting {  Title = "My Second Seeded Test Meeting",
                                                    CreatedBy = "jimmy",
                                                    Participants = "puppies",
                                                    CreatedDate = DateTime.Now,
                                                    DateUpdated = DateTime.Now,
                                                    MeetingDate = DateTime.Today.AddDays(2)
                });
                context.SaveChanges();
            }
            else
            {

            }
            
        }
    }
}
