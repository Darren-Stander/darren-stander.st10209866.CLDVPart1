using CLD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Transactions;

namespace CLD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;

        }

        public IActionResult Index()

        {
            // Retrieve all products from the database
            List<product> products = product.GetAllProducts();

            // Retrieve userID from session
            int? userID = _httpContextAccessor.HttpContext.Session.GetInt32("UserID");

            // Pass products and userID to the view
            ViewData["Products"] = products;
            ViewData["UserID"] = userID;

            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult MyWork()
        {
            return View();
        }

        public IActionResult Product()
        {
            return View();
        }
        public IActionResult Orders()
        {
            var orders = transactionTable.GetAllOrders();

            ViewData["Orders"] = orders;
            return View();
        }

        /*
        public IActionResult Orders()
        {
            return View();
        }
        */

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
