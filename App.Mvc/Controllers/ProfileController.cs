using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using App.Data;
using Microsoft.EntityFrameworkCore;

namespace ETicaret.MVC.Controllers
{
    [Authorize(Roles = "Buyer")]
    public class ProfileController : Controller
    {
        private readonly AppDbContext _context;

        public ProfileController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize] 

        [HttpGet]
        public IActionResult Index()
        {
            // Giriş yapan kullanıcının email bilgisi
            string email = User.FindFirst(ClaimTypes.Email)?.Value;

            if (email == null)
                return RedirectToAction("Login", "Auth");

            var user = _context.Users
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Email == email);

            if (user == null)
                return RedirectToAction("Login", "Auth");

            return View(user);
        }

        [HttpGet]
        public IActionResult BecomeSeller()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BecomeSellerRequest()
        {
            ViewBag.Message = "Satıcı olma talebiniz alınmıştır. Lütfen onaylanmasını bekleyin.";
            return View("BecomeSeller");
        }
    }
}

