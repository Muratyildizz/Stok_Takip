using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stok_Takip.Context;
using Stok_Takip.Models;
using System.Net.Sockets;

namespace Stok_Takip.Controllers
{
    public class UrunController : Controller
    {
        private BaseDbContext _context;
        public UrunController(BaseDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Urun()
        {
            List<Urun> uruns = _context.uruns.ToList();
            return View(uruns);
        }
        [HttpGet]
        public IActionResult YeniUrun ()
        {
            //List<SelectListItem> uruns=(from i in _context.categories.ToList()
            //                           select new SelectListItem
            //                           {
            //                               Text=i.CategoryName,
            //                            Value=i.CategoryId.ToString()
            //                           }).ToList();
            //ViewBag.Urun = uruns;
            return View();
        }
        [HttpPost]
        public IActionResult YeniUrun(Urun urun)
        {    
            _context.uruns.Add(urun);
            _context.SaveChanges();
            return RedirectToAction("Urun","Urun");
        }
        public IActionResult SIL(int id)
        {
            var urun = _context.uruns.Find(id);
            _context.uruns.Remove(urun);
            _context.SaveChanges();
            return RedirectToAction("Urun");
        }
        public IActionResult UrunGetir(int id)
        {
            var urun= _context.uruns.Find(id);
            return View("UrunGetir", urun);
        }
        [HttpPost]
        public IActionResult UrunGetir(Urun urun)
        {
            var ur = _context.uruns.Find(urun.UrunId);
            ur.UrunName=urun.UrunName;
            ur.UrunCategory=urun.UrunCategory;
            ur.UrunPrice=urun.UrunPrice;
            ur.Stok=urun.Stok;
            _context.SaveChanges();
            return RedirectToAction("Urun");
        }

    }
}
    