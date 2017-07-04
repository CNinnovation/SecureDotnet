using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Text;

namespace MyWebAppSample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult SqlSample(string id)
        {
            string connectionString = @"server=(localdb)\mssqllocaldb;database=Northwind;trusted_connection=true";
            var sqlConnection = new SqlConnection(connectionString);
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = "SELECT * FROM Customers WHERE City = " + id;
            sqlConnection.Open();
            using (SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
            {
                StringBuilder sb = new StringBuilder();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        sb.Append(reader[i]);
                    }
                    sb.AppendLine();
                }

                ViewBag.Data = sb.ToString();
            }
            // string sql = $"SELECT * FROM Customers WHERE City={id}";
            return View();

        }
    }
}
