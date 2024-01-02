using Microsoft.AspNetCore.Mvc;
using Stok_Takip.Context;
using Stok_Takip.Models;


namespace Stok_Takip.Controllers
{
    public class CategoryController : Controller
    {
        private BaseDbContext _context;

        public CategoryController(BaseDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Category> categories = _context.categories.ToList();
            return View(categories);
        }
        [HttpGet]
        public IActionResult YeniCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniCategory(Category category)
        {
            if(!ModelState.IsValid)
            {
                return View("YeniCategory");
            }
            _context.categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index","Category");

        }
        public IActionResult SIL(int id)
        {
            var kategori=_context.categories.Find(id);
            _context.categories.Remove(kategori);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult CategoryGetir(int id)
        {
            var category = _context.categories.Find(id);
            return View("CategoryGetir", category);

        }
        [HttpPost]
        public IActionResult CategoryGetir(Category category)
        {
            var categoryy = _context.categories.Find(category.CategoryId);
            categoryy.CategoryName = category.CategoryName;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
