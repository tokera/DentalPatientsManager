namespace DentalPatientsManager.Web.Areas.Administration.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;
    using DentalPatientsManager.Data;
    using DentalPatientsManager.Data.Models;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    [Authorize(Roles = "Administrator")]
    public class UsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ApplicationUsers_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<ApplicationUser> applicationusers = db.Users;
            DataSourceResult result = applicationusers.ToDataSourceResult(request, applicationUser => new {
                Id = applicationUser.Id,
                FirstName = applicationUser.FirstName,
                LastName = applicationUser.LastName,
                Email = applicationUser.Email,
                PhoneNumber = applicationUser.PhoneNumber,
                UserName = applicationUser.UserName
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ApplicationUsers_Create([DataSourceRequest]DataSourceRequest request, ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                var userStore = new UserStore<ApplicationUser>(db);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = applicationUser.Email, Email = applicationUser.Email, FirstName = applicationUser.FirstName, LastName = applicationUser.LastName };
                userManager.Create(user, "123456");

                //var entity = new ApplicationUser
                //{
                //    FirstName = applicationUser.FirstName,
                //    LastName = applicationUser.LastName,
                //    Email = applicationUser.Email,
                //    EmailConfirmed = applicationUser.EmailConfirmed,
                //    PasswordHash = applicationUser.PasswordHash,
                //    SecurityStamp = applicationUser.SecurityStamp,
                //    PhoneNumber = applicationUser.PhoneNumber,
                //    PhoneNumberConfirmed = applicationUser.PhoneNumberConfirmed,
                //    TwoFactorEnabled = applicationUser.TwoFactorEnabled,
                //    LockoutEndDateUtc = applicationUser.LockoutEndDateUtc,
                //    LockoutEnabled = applicationUser.LockoutEnabled,
                //    AccessFailedCount = applicationUser.AccessFailedCount,
                //    UserName = applicationUser.UserName
                //};

                //db.Users.Add(entity);
                db.SaveChanges();
                //applicationUser.Id = entity.Id;
            }

            return Json(new[] { applicationUser }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ApplicationUsers_Update([DataSourceRequest]DataSourceRequest request, ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                var entity = new ApplicationUser
                {
                    Id = applicationUser.Id,
                    FirstName = applicationUser.FirstName,
                    LastName = applicationUser.LastName,
                    Email = applicationUser.Email,
                    UserName = applicationUser.UserName
                };

                db.Users.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { applicationUser }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ApplicationUsers_Destroy([DataSourceRequest]DataSourceRequest request, ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                var entity = new ApplicationUser
                {
                    Id = applicationUser.Id,
                    FirstName = applicationUser.FirstName,
                    LastName = applicationUser.LastName,
                    Email = applicationUser.Email,
                    EmailConfirmed = applicationUser.EmailConfirmed,
                    PasswordHash = applicationUser.PasswordHash,
                    SecurityStamp = applicationUser.SecurityStamp,
                    PhoneNumber = applicationUser.PhoneNumber,
                    PhoneNumberConfirmed = applicationUser.PhoneNumberConfirmed,
                    TwoFactorEnabled = applicationUser.TwoFactorEnabled,
                    LockoutEndDateUtc = applicationUser.LockoutEndDateUtc,
                    LockoutEnabled = applicationUser.LockoutEnabled,
                    AccessFailedCount = applicationUser.AccessFailedCount,
                    UserName = applicationUser.UserName
                };

                db.Users.Attach(entity);
                db.Users.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { applicationUser }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
