using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using PersonelTayin.Helpers;
using PersonelTayin.Models;
using PersonelTayinUygulamasi.Controllers;

namespace PersonelTayin.Controllers
{
    public class AdminController : Controller
    {
        private readonly UygulamaDbContext _context;

        public AdminController(UygulamaDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var yetki = HttpContext.Session.GetString("Yetki");

            if (string.IsNullOrEmpty(yetki) || yetki != "Admin")
            {
                return RedirectToAction("Index", "Login");
            }

            var talepler = _context.TayinTalepleri
                .Include(t => t.Personel)
                .OrderByDescending(t => t.BasvuruTarihi)
                .ToList();

            return View(talepler);
        }





        [HttpPost]
        public IActionResult DurumuGuncelle(int talepId, string yeniDurum)
        {
            var talep = _context.TayinTalepleri.FirstOrDefault(t => t.Id == talepId);

            if (talep != null)
            {
                talep.Durum = yeniDurum;
                _context.SaveChanges();
            }
            Helpers.LogHelper.Log(talepId + " numaralı talep güncellendi.");
            return RedirectToAction("Index");
        }



        [HttpPost]
        public IActionResult TalepSil(int id)
        {
            var talep = _context.TayinTalepleri.FirstOrDefault(t => t.Id == id);

            if (talep != null)
            {
                _context.TayinTalepleri.Remove(talep);
                _context.SaveChanges();

                Helpers.LogHelper.Log($"Admin ID {HttpContext.Session.GetInt32("PersonelId")} → Talep silindi (ID: {id})");


            } 

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult TalepDuzenle(int id)
        {
            var talep = _context.TayinTalepleri.FirstOrDefault(t => t.Id == id);
            return View(talep);
        }

       

        public IActionResult Istatistik()
        {
            var toplam = _context.TayinTalepleri.Count();
            var onaylanan = _context.TayinTalepleri.Count(t => t.Durum == "Onaylandı");
            var reddedilen = _context.TayinTalepleri.Count(t => t.Durum == "Reddedildi");
            var bekleyen = _context.TayinTalepleri.Count(t => t.Durum == "Bekliyor");

            ViewBag.Toplam = toplam;
            ViewBag.Onaylanan = onaylanan;
            ViewBag.Reddedilen = reddedilen;
            ViewBag.Bekleyen = bekleyen;

            return View();
        }


    }
}






