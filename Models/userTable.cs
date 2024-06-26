﻿using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CLD.Models
{
   
    public class userTable
    {
        

        public static string con_string = "Server=tcp:poe1.database.windows.net,1433;Initial Catalog=darrenstander-sql database;Persist Security Info=False;User ID=darrenstander;Password=stander123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        public static SqlConnection con = new SqlConnection(con_string);

        public string Name {  get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public int insert_User(userTable a)
        {
            string sql = "INSERT INTO userTable (userName, userSurname, userEmail) VALUES (@Name, @Surname, @Email)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Name", a.Name);
            cmd.Parameters.AddWithValue("@Surname", a.Surname);
            cmd.Parameters.AddWithValue("@Email", a.Email);
            con.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowsAffected;
        }
        
    }
}
