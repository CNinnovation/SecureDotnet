using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Text;
using MyWebAppSample.Models;

namespace MyWebAppSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly NorthwindModel _northwindModel;
        public HomeController(NorthwindModel northwindModel)
        {
            _northwindModel = northwindModel;
        }
        
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

        public IActionResult SqlSample2(string id)
        {
            var q = from c in _northwindModel.Customers
                    where c.City == id
                    select c;

            string[] data = q.Select(c => $"{c.CompanyName} {c.ContactName}").ToArray();

            ViewBag.Data = string.Join(",", data);

            return View("SqlSample");

            //_northwindModel.Customers.Where(c => c.City == id)
        }

        public IActionResult Echo(string id)
        {
            ViewBag.Data = id;
            return View();
        }

        public string Echo2(string id) => id;
    }
}
