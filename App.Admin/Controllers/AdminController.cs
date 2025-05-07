using Microsoft.AspNetCore.Mvc;

namespace App.Admin.Controllers
{
    public class AdminController : Controller
    {
        [Route("/admin/profile")]
        public IActionResult AdminProfile()
        {
            return View();
        }
    }
}
