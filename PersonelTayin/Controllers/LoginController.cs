using Microsoft.AspNetCore.Mvc;
using PersonelTayin.Models;
using Microsoft.AspNetCore.Http;

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
            var personel = _context.Personeller.FirstOrDefault(p => p.SicilNo == sicilNo && p.Sifre == sifre);

            if (personel != null)
            {
                // Kullanıcı ID’sini session’a yaz
                HttpContext.Session.SetInt32("PersonelId", personel.Id);
                HttpContext.Session.SetString("Yetki", personel.Yetki);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Hata = "Sicil numarası veya şifre hatalı.";
            return View();
        }

        public IActionResult Cikis()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
