using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PersonelTayin.Models;

namespace PersonelTayin.Controllers
{
    public class LoginController : Controller
    {
        private readonly UygulamaDbContext _context;

        public LoginController(UygulamaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string sicilNo, string sifre)
        {

            var person = _context.Personeller.FirstOrDefault(p => p.SicilNo == sicilNo);

            if (person == null)
            {
                ViewBag.Hata = "Sicil numarası bulunamadı.";
                return View();
            }


            var passwordHasher = new PasswordHasher<Personel>();
            var sonuc = passwordHasher.VerifyHashedPassword(person, person.Sifre, sifre);

            if (sonuc == PasswordVerificationResult.Failed)
            {
                ViewBag.Hata = "Şifre hatalı.";
                return View();
            }
            else
            {
                // Şifre doğruysa, kullanıcıyı giriş yapmış olarak işaretle
                HttpContext.Session.SetInt32("PersonelId", person.Id);
                HttpContext.Session.SetString("Yetki", person.Yetki);
                return RedirectToAction("Index", "Home");
            }


        }

        public IActionResult Cikis()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
