using Microsoft.AspNetCore.Mvc;

namespace App.Mvc.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult ProductCreate()
        {
            return RedirectToAction(nameof(Create));
        }
        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
        public IActionResult Comment()
        {
            return View();
        }
    }
}
