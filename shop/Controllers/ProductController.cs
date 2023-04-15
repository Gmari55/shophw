using Microsoft.AspNetCore.Mvc;
using shop.Data;
using shop.Entities;

namespace shop.Controllers
{
    public class ProductController : Controller
    {
        private readonly shopdbcontext context;
        public ProductController(shopdbcontext context)
        {
            this.context = context;
        }
        public IActionResult AdminPanel()
        {
            var products = this.context.products.ToList();

            return View(products);
        }
        public IActionResult Products() 
        {
            var products = this.context.products.ToList();

            return View(products);
        }

        public IActionResult Details(int id)
        {
            
            var item = context.products.Find(id);

            if (item == null)
                return NotFound();

            return View(item);
        }

        public IActionResult Delete(int id)
        {
            var item = context.products.Find(id);

            if (item == null)
                return NotFound();

            context.products.Remove(item);
            context.SaveChanges();

            return RedirectToAction("AdminPanel");
        }

    }
}
