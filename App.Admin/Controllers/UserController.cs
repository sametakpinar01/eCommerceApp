using Microsoft.AspNetCore.Mvc;

namespace App.Admin.Controllers
{
    public class UserController : Controller
    {
        [Route("/user/list")]
        public IActionResult List()
        {
            return View();
        }
        [Route("/user/approve")]
        public IActionResult Approve()
        {
            return View();
        }
    }
}
