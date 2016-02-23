namespace DentalPatientsManager.Web.Administration.ViewModels.User
{
    using DentalPatientsManager.Data.Models;
    using DentalPatientsManager.Web.Infrastructure.Mapping;

    public class UserViewModel : IMapFrom<ApplicationUser>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}