using Data.Entities;
using Data;
using Microsoft.AspNetCore.Mvc;
using shop.Helpers;

namespace shop.Controllers
{
    public class FavoritesController : Controller
    {
        const string Key = "Items";
        private readonly shopdbcontext context;

        public FavoritesController(shopdbcontext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var ids = HttpContext.Session.Get<List<int>>(Key);
            ids ??= new List<int>();

            List<Product?> products = ids.Select(id => context.products.Find(id)).ToList();

            return View(products);
        }

        public IActionResult Add(int id)
        {
            List<int>? ids = HttpContext.Session.Get<List<int>>(Key);

            ids ??= new List<int>();

            ids.Add(id);

            HttpContext.Session.Set(Key, ids);

            return RedirectToAction("Products", "Product");
        }

        public IActionResult Remove(int id)
        {
            List<int>? ids = HttpContext.Session.Get<List<int>>(Key);

            ids ??= new List<int>();

            ids.Remove(id);

            HttpContext.Session.Set(Key, ids);

            return RedirectToAction("Index");
        }
    }
}
