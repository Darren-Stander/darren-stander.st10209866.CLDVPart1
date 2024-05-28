using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CLD.Models
{
    //commit to github
    public class transactionTable
    {
        private static string _conString = "Server=tcp:poe1.database.windows.net,1433;Initial Catalog=darrenstander-sql database;Persist Security Info=False;User ID=darrenstander;Password=stander123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public static SqlConnection Con = new(_conString);

        public int transactionID { get; set; }
        public int userID { get; set; }
        public int productID { get; set; }
        public DateTime transactionDate { get; set; }
        public decimal transactionAmount { get; set; }

        // Retrieve orders
        public static List<transactionTable> GetAllOrders()
        {
            var transactions = new List<transactionTable>();

            using var con = new SqlConnection(_conString);
            const string sql = "SELECT * FROM transactionTable";
            var cmd = new SqlCommand(sql, con);
            Console.WriteLine("SQLLLLLLL");
            Console.WriteLine("SQLLLLLLL"); 

            con.Open();
            var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                var transaction = new transactionTable
                {
                    transactionID = Convert.ToInt32(rdr["transactionID"]),
                    userID = Convert.ToInt32(rdr["userID"]),
                    productID = Convert.ToInt32(rdr["productID"]),
                    transactionDate = Convert.ToDateTime(rdr["transactionDate"]),
                    transactionAmount = Convert.ToDecimal(rdr["transactionAmount"])
                };
                transactions.Add(transaction);
            }

            return transactions;
        }
    }
}
    
