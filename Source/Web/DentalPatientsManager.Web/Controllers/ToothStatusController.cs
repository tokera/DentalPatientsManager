namespace DentalPatientsManager.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Common;
    using Data.Models;
    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels.ToothStatus;

    public class ToothStatusController : Controller
    {
        private readonly IToothStatusServices toothStatus;

        public ToothStatusController(IToothStatusServices toothStatus)
        {
            this.toothStatus = toothStatus;
        }

        [HttpGet]
        public ActionResult Add(int number, int id)
        {
            this.TempData["PatientId"] = id;
            this.TempData["ToothNumber"] = number;

            var curToothStatus = this.toothStatus.ExistsToothStatus(number, id);
            if (curToothStatus != 0)
            {
                return this.Redirect($"/ToothStatus/Details/{curToothStatus}?toothNumber={number}");
            }

            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(int toothNumber, ToothStatusInputViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var newModel = new ToothStatus
            {
                ToothNumber = toothNumber,
                Status = model.Status,
                Diagnose = model.Diagnose,
                TreatmentPlan = model.TreatmentPlan,
                PatientId = (int)this.TempData["PatientId"]
            };

            this.toothStatus.Add(newModel);

            return this.Redirect($"/Patient/Details/{newModel.PatientId}");
        }

        [HttpGet]
        public ActionResult Details(int id, int toothNumber)
        {
            var toothStatus = this.toothStatus.GetById(id);
            var newModel = new ToothStatusViewModel
            {
                ToothNumber = toothNumber,
                PatientName = toothStatus.Patient.FirstName,
                Status = toothStatus.Status,
                Diagnose = toothStatus.Diagnose,
                TreatmentPlan = toothStatus.TreatmentPlan,
                CreatedOn = toothStatus.CreatedOn
            };

            return this.View(newModel);
        }
    }
}