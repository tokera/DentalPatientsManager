namespace DentalPatientsManager.Web.Controllers
{
    using System.Web.Mvc;

    public class ToothStatusController : Controller
    {
        [HttpGet]
        public ActionResult Add(int number)
        {
            this.ViewBag.ToothNumber = number;
            return this.View();
        }
    }
}