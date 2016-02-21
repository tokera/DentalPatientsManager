using System.Collections.Generic;

namespace DentalPatientsManager.Web.ViewModels.Patient
{
    public class PatientsListViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<PatientViewModel> Patients { get; set; }
    }
}