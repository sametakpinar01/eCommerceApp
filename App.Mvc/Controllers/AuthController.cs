using App.Data;
using App.Data.Entities;
using App.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace App.Mvc.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _dbContext;
        public AuthController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("/register")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost("/register")]
        public async Task<IActionResult> Register([FromForm] RegisterModel user)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Lütfen bilgilerinizi eksiksiz giriniz !");
            }

            var existingUser = _dbContext.Users.FirstOrDefault(u => u.Email == user.Email);

            if (existingUser is not null)
            {
                return BadRequest("Bu Email adresi zaten kayıtlı !");
            }

            var newUser = new UserEntity
            {
                Email = user.Email,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                RoleId = 3

            };

            _dbContext.Users.Add(newUser);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Login));
        }
        [HttpGet]
        [Route("Auth/Login")]
        public async Task<IActionResult> Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UserLogin([FromForm] LoginModel user, string? returnUrl = null)
        {
            if (!ModelState.IsValid)
                return BadRequest("Kullanıcı bilgilerini eksiksiz giriniz.");

            var existingUser = _dbContext.Users
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Email == user.Email);

            if (existingUser is null || existingUser.Password != user.Password)
                return BadRequest("Email veya şifre hatalı.");

            // Kullanıcı bilgileri doğruysa CLAIMS oluştur
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Email, existingUser.Email),
        new Claim(ClaimTypes.Name, existingUser.FirstName + " " + existingUser.LastName),
        new Claim(ClaimTypes.Role, existingUser.Role.Name) // Admin / Buyer / Seller
    };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            // Kullanıcıyı cookie ile oturum başlat
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            // Eğer bir yönlendirme adresi varsa oraya git
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            // Yoksa anasayfaya git
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Logout()
        {
            return View();
        }

    }
}
