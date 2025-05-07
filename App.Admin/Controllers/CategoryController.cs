using Microsoft.AspNetCore.Mvc;

namespace App.Admin.Controllers
{
    public class CategoryController : Controller
    {
        [HttpGet]
        [Route("category/create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([FromForm]string title, string description, string icon)
        {
            if (title == null)
            {
                return BadRequest();
            }

            return View();
        }
        [Route("category/edit")]
        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit([FromRoute] int id)
        {
            return View();
        }
        [Route("category/{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            return RedirectToAction(nameof(Edit));
        }
    }
}
