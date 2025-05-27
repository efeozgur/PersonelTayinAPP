using Microsoft.AspNetCore.Mvc;
using PersonelTayin.Models;

namespace PersonelTayin.Controllers
{
    public class PersonelController : Controller
    {

        private readonly UygulamaDbContext _context;

        public PersonelController(UygulamaDbContext context)
        {
            _context = context;
        }


        public ActionResult Index()
        {
            return View();
        }

    
        public ActionResult Details(int id)
        {
            return View();
        }

        public IActionResult PersonelKayit(string adSoyad, string sicilNo, string unvan, string gorevYeri, string sifre, string cinsiyet)
        {
            var personel = new Personel
            {
                AdSoyad = adSoyad,
                SicilNo = sicilNo,  
                Unvan = unvan,
                GorevYeri = gorevYeri,
                Sifre = sifre,
                Cinsiyet= cinsiyet,
            };
            _context.Personeller.Add(personel);
            _context.SaveChanges();
            ViewBag.Message = "Personel kaydı başarıyla eklendi.";
            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Edit(int id)
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonelController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }



        public List<string> UnvanListesi()
        {
            var liste = new List<string>
            {
                "Yazı İşleri Müdürü",
                "Zabıt Katibi",
                "Mübaşir",
                "Memur",
                "Hizmetli",
            };
           
            return liste;
        }
    }
}
