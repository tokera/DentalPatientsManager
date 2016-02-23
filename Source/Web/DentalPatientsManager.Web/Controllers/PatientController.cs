namespace DentalPatientsManager.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Data;
    using ViewModels.Patient;

    [Authorize]
    public class PatientController : Controller
    {
        const int ItemsPerPage = 5;

        private readonly IPatientsServices patients;

        private readonly IToothStatusServices toothStatus;


        public PatientController(IPatientsServices patients, IToothStatusServices toothStatus)
        {
            this.patients = patients;
            this.toothStatus = toothStatus;
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

            return this.Redirect("/Patient/ListPatients");

        }

        [HttpGet]
        public ActionResult ListPatients(string sortBy = "date", string search = "", int id = 1)
        {
            var page = id;
            var allItemsCount = this.patients.GetAll(sortBy, search, this.User.Identity.GetUserId()).Count();
            var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);
            var itemsToSkip = (page - 1) * ItemsPerPage;
            var patientsToList = this.patients.GetAll(sortBy, search, this.User.Identity.GetUserId())
                .Skip(itemsToSkip).Take(ItemsPerPage)
                .To<PatientViewModel>().ToList();

            var viewModel = new PatientsListViewModel
            {
                CurrentPage = page,
                TotalPages = totalPages,
                Patients = patientsToList
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var patient = this.patients.GetById(id);
            var tootStatusForPatient = this.toothStatus.GetAllByPatientId(id).ToList();
            var model = new PatientDetailsViewModel
            {
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Age = patient.Age,
                Address = patient.Address,
                Tel = patient.Tel,
                Profession = patient.Profession,
                ToothStatus = tootStatusForPatient
            };

            this.TempData["PatientId"] = id;

            return this.View(model);
        }
    }
}