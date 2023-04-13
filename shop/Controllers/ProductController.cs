using Microsoft.AspNetCore.Mvc;
using shop.Models;

namespace shop.Controllers
{
    public class ProductController : Controller
    {
        static List<Product> products = new List<Product>()
        {
            new Product() { Id = 1, Name = "MacBook Pro 2019", Price = 1200, Category = "Electronics" },
            new Product() { Id = 2, Name = "Samsung S23 Ultra", Price = 1050, Category = "Electronics" },
            new Product() { Id = 3, Name = "Adidas T-Shirt", Price = 570, Category = "Clothes" },
            new Product() { Id = 4, Name = "Google Glass 2", Price = 840, Category = "Accesories" }
        };
        public IActionResult Index()
        {

            return View(products);
        }

        public IActionResult Details(int id)
        {
            var item = products.FirstOrDefault(x => x.Id == id);

            if (item == null)
                return NotFound();

            return View(item);
        }

        public IActionResult Delete(int id)
        {
            var item = products.FirstOrDefault(x => x.Id == id);

            if (item == null)
                return NotFound();

            products.Remove(item);

            return RedirectToAction("Index");
        }

    }
}
