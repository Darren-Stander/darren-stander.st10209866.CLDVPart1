using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;


namespace CLD.Models
{
    
    public class product
    {
        public static string con_string = "Server=tcp:poe1.database.windows.net,1433;Initial Catalog=darrenstander-sql database;Persist Security Info=False;User ID=darrenstander;Password=stander123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";


        public static SqlConnection con = new SqlConnection(con_string);


        public int productID { get; set; }

        public string Name { get; set; }

        public string Price { get; set; }

        public string Category { get; set; }

        public string Availability { get; set; }



        public int insert_product(product product)
        {

            try
            {

                string sql = "INSERT INTO productTable (productName, productPrice, productCategory, productAvailability) VALUES (@Name, @Price, @Category, @Availability)";
                //public static string con_string = "Integrated Security=SSPI;Persist Security Info=False;User ID=\"\";Initial Catalog=test;Data Source=labVMH8OX\\SQLEXPRESS";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@Category", product.Category);
                cmd.Parameters.AddWithValue("@Availability", product.Availability);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                // For now, rethrow the exception
                throw ex;
            }


        }


        // Method to retrieve all products from the database
        public static List<product> GetAllProducts()
        {
            List<product> products = new List<product>();

            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT * FROM productTable";
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    product product = new product();
                    product.productID = Convert.ToInt32(rdr["productID"]);
                    product.Name = rdr["productName"].ToString();
                    product.Price = rdr["productPrice"].ToString();
                    product.Category = rdr["productCategory"].ToString();
                    product.Availability = rdr["productAvailability"].ToString();

                    products.Add(product);
                }
            }

            return products;
        }
    }
}



    

