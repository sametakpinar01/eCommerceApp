using App.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace App.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Route("/about-us")]
        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();

        }
        [HttpGet]
        public IActionResult Listing()
        {

            return View();
        }
        [HttpGet]
        [Route("/product/{categoryName}-{title}-{id}/details")]
        public IActionResult ProductDetail([FromRoute] string categoryName, [FromRoute] string title , [FromRoute] int id)
        {
            return View();
        }



    };

};