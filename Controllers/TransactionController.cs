using CLD.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CLD.Controllers
{
    public class TransactionController : Controller
    {
        private string GetConnectionString()
        {
            return "Server=tcp:poe1.database.windows.net,1433;Initial Catalog=darrenstander-sql database;Persist Security Info=False;User ID=darrenstander;Password=stander123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }

        public IActionResult Orders()
        {
            List<transactionTable> transactions;

            try
            {
                transactions = new List<transactionTable>();

                using (var connection = new SqlConnection(GetConnectionString()))
                {
                    connection.Open();
                    using (var command = new SqlCommand("SELECT * FROM transactionTable", connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                transactions.Add(new transactionTable
                                {
                                    transactionID = Convert.ToInt32(reader["transactionID"]),
                                    userID = Convert.ToInt32(reader["userID"]),
                                    productID = Convert.ToInt32(reader["productID"]),
                                    transactionDate = Convert.ToDateTime(reader["transactionDate"]),
                                    transactionAmount = Convert.ToDecimal(reader["transactionAmount"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the error for debugging
                Console.WriteLine($"Error retrieving transactions: {ex.Message}");

                // Handle the error gracefully in the view (e.g., display an error message)
                ViewData["ErrorMessage"] = "An error occurred while fetching transactions.";
                return View("Orders"); // You might have a specific error view
            }

            return View("Orders", transactions); // Pass the list to the view
        }

        [HttpPost]
        public IActionResult PlaceOrder(int userID, int productID, int price)
        {
            try
            {
                using (var connection = new SqlConnection(GetConnectionString()))
                {
                    connection.Open();

                    var sql = "INSERT INTO transactionTable (transactionID, userID, productID, transactionDate, transactionAmount) " +
                              "VALUES (@transactionID, @userID, @productID, @transactionDate, @transactionAmount)";

                    using (var command = new SqlCommand(sql, connection))
                    {
                        var random = new Random();
                        var randomNumber = random.Next(1, 1001); // Generate a random transactionID

                        command.Parameters.AddWithValue("@transactionID", randomNumber);
                        command.Parameters.AddWithValue("@userID", userID);
                        command.Parameters.AddWithValue("@productID", productID);
                        command.Parameters.AddWithValue("@transactionAmount", price);
                        command.Parameters.AddWithValue("@transactionDate", DateTime.Now);

                        command.ExecuteNonQuery();
                    }
                }

                return RedirectToAction("Index", "Home"); // Redirect to a success page
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine($"Error placing order: {ex.Message}");

                // Handle the error in the view (display an error message)
                ViewData["ErrorMessage"] = "An error occurred while placing the order.";
                return View("PlaceOrder"); // Or a specific error view
            }
        }
    }
}
