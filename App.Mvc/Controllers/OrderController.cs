using Microsoft.AspNetCore.Mvc;

namespace App.Mvc.Controllers
{
    public class OrderController : Controller
    {
        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([FromForm] int testveri)
        {
            return View();
        }
        [Route("/order/{id}/details")]
        public IActionResult Details(int id)
        {
            return View();
        }
    }
}
