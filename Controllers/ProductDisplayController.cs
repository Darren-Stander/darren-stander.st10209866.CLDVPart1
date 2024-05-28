using CLD.Models;
using Microsoft.AspNetCore.Mvc;


namespace CLD.Controllers

// ON his privacy page is where the cart thingy is..
{

    namespace CLD.Controllers
    {

        public class ProductDisplayController : Controller
        {
            [HttpGet]
            public IActionResult Index()

            {
                // Just need to edit the transcationatable later onwards//


                var products = ProductDisplayModel.SelectProducts();         //remove the comments just adding them so I can run the project with no errors
                return View(products);
            }

        }
    }
}
                


