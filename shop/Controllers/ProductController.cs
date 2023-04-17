using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
       ViewBag.CategoryList=new SelectList( context.Categories.ToList(),"Id","Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {

            if (!ModelState.IsValid)
            {

                return View("Create");
            }



            context.products.Add(product);
            context.SaveChanges();

            return RedirectToAction("Products");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.CategoryList = new SelectList(context.Categories.ToList(), "Id", "Name");
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

                return View("Edit");
            }



            context.products.Update(product);
            context.SaveChanges();

            return RedirectToAction("AdminPanel");

        }


        }
}
