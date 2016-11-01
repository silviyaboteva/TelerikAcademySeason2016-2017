using System;
using Northwind.Client.Models;

namespace Northwind.Client
{
    public class NorthwindDAOTest
    {
        public static void Inserting()
        {
            var customer = new Customer()
            {
                CustomerID = "TEST",
                CompanyName = "UNKNOWN",
                ContactName = "UNNAMED",
                ContactTitle = "NO-TITLE"
            };

            var affectedRows = NorthwindDAO.InsertCustomer(customer);

            Console.WriteLine("\rInsert -> ({0} affected row(s))", affectedRows);
        }

        public static void Modifying()
        {
            var affectedRows = NorthwindDAO.ModifyCustomerCompanyName("TEST", "NEW-NAME");

            Console.WriteLine("Modify -> ({0} affected row(s))", affectedRows);
        }

        public static void Deleting()
        {
            var affectedRows = NorthwindDAO.DeleteCustomer("TEST");

            Console.WriteLine("Delete -> ({0} affected row(s))", affectedRows);
        }
    }
}
