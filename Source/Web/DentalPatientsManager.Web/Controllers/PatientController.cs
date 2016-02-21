namespace DentalPatientsManager.Web.Controllers
{
    using System.Web.Mvc;
    using Data.Common;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using ViewModels.Patient;
    using Services.Data;
    using Infrastructure.Mapping;
    using System.Linq;
    [Authorize]
    public class PatientController : Controller
    {
        private readonly IPatientsServices patients;

        public PatientController(IPatientsServices patients)
        {
            this.patients = patients;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PatientInputViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var patient = new Patient()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                Address = model.Address,
                Tel = model.Tel,
                Profession = model.Profession,
                DoctorId = this.User.Identity.GetUserId()
            };

            this.patients.Create(patient);

            return this.Redirect("/");

        }

        public ActionResult ListPatients()
        {
            ;

            var patientsToList = this.patients.GetAll()
                .To<PatientViewModel>()
                .ToList();

            var viewModel = new PatientsListViewModel
            {
                Patients = patientsToList
            };

            return this.View(viewModel);
        }
    }
}