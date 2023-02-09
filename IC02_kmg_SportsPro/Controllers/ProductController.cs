using IC02_kmg_SportsPro.Models;
using Microsoft.AspNetCore.Mvc;

namespace IC02_kmg_SportsPro.Controllers
{
    public class ProductController : Controller
    {
        private SportsProContext context { get; set; }
        //dependency injection via constructor below
        public ProductController(SportsProContext ctx) 
        {
            context = ctx;
        }
        public IActionResult List()
        {
            var products = context.Products.OrderBy(p => p.ReleaseDate).ToList();
            return View(products);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Title = "Add";
            return View("AddEdit", new Product()); //Pass an empty Product object
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Title = "Edit";
            var product = context.Products.Find(id);
            return View("AddEdit", product);
        }
        [HttpPost]
        public IActionResult Save(Product product) 
        {
            if (ModelState.IsValid)
            { 
                if (product.ProductID == 0)
                {
                    context.Products.Add(product);  
                }
                else
                {
                    context.Products.Update(product);   
                }
                context.SaveChanges();
                return RedirectToAction("List");   
            }
            else
            {
                if (product.ProductID == 0)
                {
                    ViewBag.Action = "Add";
                }
                else
                {
                    ViewBag.Action = "Edit";
                }
                return View(product);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = context.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
