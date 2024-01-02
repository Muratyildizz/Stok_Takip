using Microsoft.AspNetCore.Mvc;
using Stok_Takip.Context;
using Stok_Takip.Models;

namespace Stok_Takip.Controllers
{
    public class SatisController : Controller
    {
        private BaseDbContext _context;
        public SatisController(BaseDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Satis> satis = _context.Satis.ToList();
            return View(satis);

        }
        [HttpGet]
        public IActionResult YeniSatis()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniSatis(Satis satis)
        {
            _context.Satis.Add(satis);
            _context.SaveChanges();
            return RedirectToAction("Index", "Satis");
        }



    }
}
