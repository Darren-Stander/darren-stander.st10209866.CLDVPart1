using CLD.Models;
using Microsoft.AspNetCore.Mvc;

namespace CLD.Controllers
{
    public class ProductController : Controller
    {
        public product prodtbl = new product();

        //

        [HttpPost]
        public ActionResult Products(product products)
        {
            var result2 = prodtbl.insert_product(products);
            return RedirectToAction("Index", "Home");
            
        }

        [HttpGet]
        public ActionResult Product()
        {
            return View(prodtbl);
        }
    }
}
