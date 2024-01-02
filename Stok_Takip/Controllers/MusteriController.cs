using Microsoft.AspNetCore.Mvc;
using Stok_Takip.Context;
using Stok_Takip.Models;

namespace Stok_Takip.Controllers
{
    public class MusteriController : Controller
    {
        private BaseDbContext _context;
        public MusteriController(BaseDbContext context)
        {
            _context = context;
        }
        public IActionResult Musteri(string p)
        {
            var musteri = from d in _context.musteri select d;
            if (!string.IsNullOrEmpty(p))
            {
                musteri = musteri.Where(c => c.MusteriName.Contains(p));
            }
            return View(musteri.ToList());
           // List<Musteri> musteri = _context.musteri.ToList();
           // return View(musteri);
        }
     
        [HttpGet]
        public IActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniMusteri (Musteri musteri)
        {
            _context.musteri.Add(musteri);
            _context.SaveChanges();
            return RedirectToAction("Musteri", "Musteri");

        }
        public IActionResult SIL(int id)
        {
            var musteriSil = _context.musteri.Find(id);
            _context.musteri.Remove(musteriSil);
            _context.SaveChanges();
            return RedirectToAction("Musteri");
        }
        public IActionResult MusteriGetir(int id)
        {
            var müs = _context.musteri.Find(id);
            return View("MusteriGetir", müs);
        }
        [HttpPost]
        public IActionResult MusteriGetir(Musteri musteri)
        {
            var mus = _context.musteri.Find(musteri.MusteriId);
            mus.MusteriName = musteri.MusteriName;
            mus.MusteriSurname=musteri.MusteriSurname;
            _context.SaveChanges();
            return RedirectToAction("Musteri");
        }
    }
}
