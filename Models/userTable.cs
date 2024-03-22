using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CLD.Models
{
   
    public class userTable : Controller
    {

        public static string con_string = "Server=tcp:poe1.database.windows.net,1433;Initial Catalog=darrenstander-sql database;Persist Security Info=False;User ID=darrenstander;Password=stander123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        public static SqlConnection con = new SqlConnection(con_string);
        public IActionResult Index()
        {
            return View();
        }
    }
}
