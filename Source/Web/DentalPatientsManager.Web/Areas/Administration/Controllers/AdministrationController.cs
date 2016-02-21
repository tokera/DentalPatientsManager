namespace DentalPatientsManager.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using DentalPatientsManager.Common;
    using DentalPatientsManager.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministrationController : BaseController
    {
    }
}
