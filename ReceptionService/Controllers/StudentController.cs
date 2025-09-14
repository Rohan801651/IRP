using Microsoft.AspNetCore.Mvc;

namespace ReceptionService.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



    }
}
