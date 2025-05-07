using Microsoft.AspNetCore.Mvc;

namespace App.Admin.Controllers
{
    public class CommentController : Controller
    {
        [Route("/comment/list")]
        public IActionResult List()
        {
            return View();
        }
        public IActionResult Approve()
        {
            return View();
        }
    }
}
