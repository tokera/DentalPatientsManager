namespace DentalPatientsManager.Web.ViewModels.Patient
{
    using DentalPatientsManager.Data.Models;
    using DentalPatientsManager.Web.Infrastructure.Mapping;

    public class PatientViewModel : IMapFrom<Patient>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Tel { get; set; }

        public string CreatedOn { get; set; }
    }
}