using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CLD.Models
{

    public class ProductDisplayModel
    {
        public int productID { get; set; }
        public string productName { get; set; }
        public decimal productPrice { get; set; }
        public string productCategory { get; set; }
        public bool productAvailability { get; set; }

        public ProductDisplayModel() { }

        //Parameterized Constructor: This constructor takes five parameters (id, name, price, category, availability) and initializes the corresponding properties of ProductDisplayModel with the provided values.
        public ProductDisplayModel(int id, string name, decimal price, string category, bool availability)
        {
            productID = id;
            productName = name;
            productPrice = price;
            productCategory = category;
            productAvailability = availability;
        }

        public static List<ProductDisplayModel> SelectProducts()
        {
            List<ProductDisplayModel> products = new List<ProductDisplayModel>();

            string con_string = "Server=tcp:poe1.database.windows.net,1433;Initial Catalog=darrenstander-sql database;Persist Security Info=False;User ID=darrenstander;Password=stander123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT productID, productName, productPrice, productCategory, productAvailability FROM productTable";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductDisplayModel product = new ProductDisplayModel();
                    product.productID = Convert.ToInt32(reader["productID"]);
                    product.productName = Convert.ToString(reader["productName"]);
                    product.productPrice = Convert.ToDecimal(reader["productPrice"]);
                    product.productCategory = Convert.ToString(reader["productCategory"]);
                    product.productAvailability = Convert.ToBoolean(reader["productAvailability"]);
                    products.Add(product);
                }
                reader.Close();
            }
            return products;
        }
    }
}
