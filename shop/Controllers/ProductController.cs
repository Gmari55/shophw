using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Data;
using Data.Entities;

namespace shop.Controllers
{
    public class ProductController : Controller
    {
        public void Loadcategories()
        {
            ViewBag.CategoryList=new SelectList( context.Categories.ToList(),"Id","Name");
        }
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
            var products = this.context.products.OrderByDescending(c => c.datecreate).ThenBy(c => c.datecreate).ToList();

            return View(products);
        }

        public IActionResult Details(int id)
        {
            var item = context.products.Find(id);

            if (item == null)
                return NotFound();
            ViewBag.Category = context.Categories.Find(item.CategoryId).Name;

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

        [HttpGet]
        public IActionResult Create()
        {
            Loadcategories();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {

            if (!ModelState.IsValid)
            {
                Loadcategories();
                return View("Create");
            }

            product.datecreate = DateTime.Now;

            context.products.Add(product);
            context.SaveChanges();

            return RedirectToAction("Products");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Loadcategories();
            var item = context.products.Find(id);
            if (item == null)
                return NotFound();

          
            return View(item);

        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {

            if (!ModelState.IsValid)
            {
                Loadcategories();
                return View("Edit");
            }



            context.products.Update(product);
            context.SaveChanges();

            return RedirectToAction("AdminPanel");

        }


        }
}
