using Library.WebApplication.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Library.WebApplication.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Library.WebApplication.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Library.WebApplication.Models.ApplicationDbContext";
        }

        protected override void Seed(Library.WebApplication.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            //var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //if (!roleManager.RoleExists("Admin"))
            //{
            //    var adminRole = new IdentityRole("Admin");
            //    roleManager.Create(adminRole);
            //}

            //if (!roleManager.RoleExists("User"))
            //{
            //    var userRole = new IdentityRole("User");
            //    roleManager.Create(userRole);
            //}

            //if (!context.Users.Any(u => u.Email == "admin@gmail.com"))
            //{
            //    var store = new UserStore<ApplicationUser>(context);
            //    var manager = new UserManager<ApplicationUser>(store);
            //    var user = new ApplicationUser { UserName = "admin@gmail.com" };
   
            //    manager.Create(user, "#Dupa123");
            //    manager.AddToRole(user.Id, "Admin");
            //}
            
        }
    }
}
