using Library.WebApplication.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Library.WebApplication.Startup))]
namespace Library.WebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                var adminRole = new IdentityRole("Admin");
                roleManager.Create(adminRole);

                var user = new ApplicationUser();
                user.Email = "admin@admin.com";
                string adminPassword = "#Dupa123";

                var userCreation = userManager.Create(user, adminPassword);
                if (userCreation.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }

            if (!roleManager.RoleExists("User"))
            {
                var userRole = new IdentityRole("User");
                roleManager.Create(userRole);
            }
        }
    }
}
