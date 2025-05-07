using Microsoft.AspNetCore.Mvc;

namespace App.Mvc.Controllers
{
    public class CartController : Controller
    {
        public IActionResult AddProduct()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
    }
}
