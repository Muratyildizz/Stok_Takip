using Microsoft.AspNetCore.Mvc;
using Stok_Takip.Context;
using Stok_Takip.Models;

namespace Stok_Takip.Controllers
{
    public class LoginController : Controller
    {
        private readonly BaseDbContext _context;

        public LoginController(BaseDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login p)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(p.KullanıcıName))
            {
                return BadRequest("Kullanıcı adı boş olamaz.");
            }

            if (string.IsNullOrWhiteSpace(p.Sifre))
            {
                return BadRequest("Şifre boş olamaz.");
            }

            // Check database for a match
            var adminuser = _context.logins.FirstOrDefault(x => x.KullanıcıName == p.KullanıcıName && x.Sifre == p.Sifre);

            if (adminuser != null)
            {
                // Bilgiler doğru, kullanıcıyı sayfaya yönlendir
                return RedirectToAction("Index", "Category");
            }
            else
            {
                // Bilgiler yanlış, hata mesajı döndür
                return BadRequest("Kullanıcı adı veya şifre yanlış.");
            }

        }
    }
}
