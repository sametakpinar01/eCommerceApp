using Microsoft.AspNetCore.Mvc;

namespace App.Admin.Controllers
{
    public class ProductController : Controller
    {
        [Route("/product/{id}/delete")]
        public IActionResult Delete([FromRoute] int id)
        {
            return View();
        }
    }
}
