namespace DentalPatientsManager.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DentalPatientsManager.Common;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            const string AdministratorUserName = "admin@admin.com";
            const string AdministratorPassword = "admin";

            if (!context.Roles.Any())
            {
                // Create admin role
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = GlobalConstants.AdministratorRoleName };
                roleManager.Create(role);

                // Create admin user
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore)
                {
                    PasswordValidator = new PasswordValidator
                    {
                        RequiredLength = 5,
                        RequireNonLetterOrDigit = false,
                        RequireDigit = false,
                        RequireLowercase = false,
                        RequireUppercase = false,
                    }
                };
                var user = new ApplicationUser { UserName = AdministratorUserName, Email = AdministratorUserName };
                userManager.Create(user, AdministratorPassword);

                // Assign user to admin role
                userManager.AddToRole(user.Id, GlobalConstants.AdministratorRoleName);
            }
        }
    }
}
