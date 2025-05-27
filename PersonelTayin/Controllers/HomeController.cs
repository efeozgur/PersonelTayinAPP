using Microsoft.AspNetCore.Mvc;
using PersonelTayin.Models;


namespace PersonelTayinUygulamasi.Controllers
{
    public class HomeController : Controller
    {

        private readonly UygulamaDbContext _context;


        public HomeController(UygulamaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            int? personelId = HttpContext.Session.GetInt32("PersonelId");

            if (personelId == null)
                return RedirectToAction("Index", "Login");

            var personel = _context.Personeller.FirstOrDefault(p => p.Id == personelId);
            var talepler = _context.TayinTalepleri.Where(t => t.PersonelId == personelId).ToList();

            ViewBag.Personel = personel;
            ViewBag.Talepler = talepler;

            return View();
        }








        //Kontrolleri yaptýktan sonra Yeni Talebi Kaydediyoruz
        [HttpGet]
        public IActionResult YeniTalep()
        {
            ViewBag.Adliyeler = GetAdliyeListesi();
            return View();
        }

        [HttpPost]
        public IActionResult YeniTalep(string talepTuru, string tercihAdliye, string aciklama)
        {
            int? personelId = HttpContext.Session.GetInt32("PersonelId");
            if (personelId == null)
                return RedirectToAction("Index", "Login");

            var yeniTalep = new TayinTalebi
            {
                TalepTuru = talepTuru,
                TercihAdliye = tercihAdliye,
                Aciklama = aciklama,
                BasvuruTarihi = DateTime.Now,
                PersonelId = personelId.Value
            };

            _context.TayinTalepleri.Add(yeniTalep);
            _context.SaveChanges();

            ViewBag.Mesaj = "Tayin talebiniz baþarýyla kaydedildi.";
            ViewBag.Adliyeler = GetAdliyeListesi();
            return View();
        }

        // Geçici olarak adliye listesi üretelim. Database eklenip oradan çekilebilir. 
        private List<string> GetAdliyeListesi()
        {
            return new List<string>
        {
            "Adana Adliyesi",
            "Adýyaman Adliyesi",
            "Ankara Adliyesi",
            "Ýstanbul Adliyesi",
            "Ýzmir Adliyesi",
            "Bursa Adliyesi",
            "Erzurum Adliyesi",
            // Listeyi tamamlarsýn — 81 il merkezi
        };

        }
    }

}
