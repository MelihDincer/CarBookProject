using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.Controllers
{
    public class ErrorsController : Controller
    {
        [Route("error/403")]
        public IActionResult Forbidden()
        {
            return View();
        }

        [Route("error/404")]
        public IActionResult NotFoundPage()
        {
            return View("NotFound");
        }

        [Route("error/401")]
        public IActionResult UnauthorizedPage()
        {
            return View("Unauthorized");
        }

        [Route("error/400")]
        public IActionResult BadRequestPage()
        {
            return View("BadRequest");
        }

        [Route("error/500")]
        public IActionResult ServerError()
        {
            return View();
        }

        [Route("error/maintenance")]
        public IActionResult Maintenance()
        {
            return View();
        }

        [Route("error/under-construction")]
        public IActionResult UnderConstruction()
        {
            return View();
        }
    }
}
