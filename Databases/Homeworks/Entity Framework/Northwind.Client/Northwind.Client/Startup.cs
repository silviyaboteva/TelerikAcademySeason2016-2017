using Northwind.Client.Models;
using System;
using System.Linq;

namespace Northwind.Client
{
    public class Startup
    {
        public static void Main()
        {
            //1. Using the Visual Studio Entity Framework designer create a DbContext for the Northwind database
            //Console.WriteLine("Loading...");

            //using (var db = new NorthwindEntities())
            //{
            //    var products = db.Products
            //        .FirstOrDefault(p => p.ProductID == 1);
            //    Console.WriteLine(products.ProductName);
            //}

            //2. Create a DAO class with static methods which provide functionality for inserting, modifying and deleting customers.
            //Console.WriteLine("Inserting...");
            //NorthwindDAOTest.Inserting();

            //Console.WriteLine("Modifying...");
            //NorthwindDAOTest.Modifying();

            //Console.WriteLine("Deleting...");
            //NorthwindDAOTest.Deleting();

            //3. Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
            //var orders = NorthwindDAO.CustomersWithOrdersIn1997ShippedToCanada();

            //foreach(var order in orders)
            //{
            //    Console.WriteLine(order.Customer.CompanyName);
            //}

            //4. Implement previous by using native SQL query and executing it through the DbContext.
            //var orders = NorthwindDAO.CustomersWithOrdersIn1997ShippedToCanadaNativeSQL();

            //foreach (var order in orders)
            //{
            //    Console.WriteLine(order.Customer.CompanyName);
            //}

            //5. Write a method that finds all the sales by specified region and period (start / end dates).
            //var region = "SP";
            //var startDate = new DateTime(1995, 5, 10);
            //var endDate = new DateTime(1996, 12, 4);

            //var sales = NorthwindDAO.SalesBySpecifiedRegionAndperiod(region, startDate, endDate);

            //foreach (var order in sales)
            //{
            //    Console.WriteLine(order.OrderID);
            //}

            //6. Create a database called NorthwindTwin with the same structure as Northwind using the features from DbContext.
            ///Find for the API for schema generation in MSDN or in Google.
            ///
            // The connection string in App.config is changed

            //Console.WriteLine("Cloning...");
            //NorthwindDAO.CloneDatabase();

            //7. Try to open two different data contexts and perform concurrent changes on the same records.

            //Console.Write("Opening data contexts...");
            //NorthwindDAO.StartFirstConnection();
            //NorthwindDAO.PrintActualResult();

            //8. By inheriting the Employee entity class create a class which allows employees to access their corresponding territories as property of type EntitySet<T>.
            //NorthwindDAO.CreateNewClass();
        }
    }
}
