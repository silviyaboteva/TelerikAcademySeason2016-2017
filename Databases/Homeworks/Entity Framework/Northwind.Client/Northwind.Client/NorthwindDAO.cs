using System.Linq;
using Northwind.Client.Models;
using System.Collections.Generic;
using System;

namespace Northwind.Client
{
    public static class NorthwindDAO
    { 
        public static int InsertCustomer(Customer customer)
        {
            var affectedRows = 0;

            using (var dbContext = new NorthwindEntities())
            {
                dbContext.Customers.Add(customer);
                affectedRows = dbContext.SaveChanges();
            }

            return affectedRows;
        }

        public static int ModifyCustomerCompanyName(string customerId, string newCompanyName)
        {
            var affectedRows = 0;

            using (var dbContext = new NorthwindEntities())
            {
                var targetCustomer = dbContext.Customers.Find(customerId);
                targetCustomer.CompanyName = newCompanyName;
                affectedRows = dbContext.SaveChanges();
            }

            return affectedRows;
        }

        public static int DeleteCustomer(string customerId)
        {
            var affectedRows = 0;

            using (var dbContext = new NorthwindEntities())
            {
                var customersToDelete = dbContext.Customers.Where(c => c.CustomerID == customerId);

                if (customersToDelete.Count() > 0)
                {
                    foreach (var customer in customersToDelete)
                    {
                        dbContext.Customers.Remove(customer);
                    }
                }

                affectedRows = dbContext.SaveChanges();
            }

            return affectedRows;
        }

        public static ICollection<Order> CustomersWithOrdersIn1997ShippedToCanada()
        {
            using (var dbContext = new NorthwindEntities())
            {
                var year = 1997;
                var shipCountry = "Canada";
                var result = dbContext.Orders
                        .Where(sc => sc.ShipCountry == shipCountry && sc.OrderDate.Value.Year == year);

                return result.ToList();
            }
        }

        public static ICollection<Order> CustomersWithOrdersIn1997ShippedToCanadaNativeSQL()
        {
            using (var dbContext = new NorthwindEntities())
            {
                var query = "SELECT * FROM Orders WHERE ShipCountry = 'Canada' AND YEAR(OrderDate) = 1997";
                var result = dbContext.Orders.SqlQuery(query);

                return result.ToList();
            }
        }

        public static ICollection<Order> SalesBySpecifiedRegionAndperiod(string region, DateTime startDate, DateTime endDate)
        {
            using (var dbContext = new NorthwindEntities())
            {
                var result = dbContext.Orders
                    .Where(o => o.ShipRegion == region && (o.OrderDate >= startDate && o.RequiredDate <= endDate)).ToList();
                return result;
            }
        }

        public static void CloneDatabase()
        {
            using (var northwindEntities = new NorthwindEntities())
            {
                northwindEntities.Database.CreateIfNotExists();
                Console.WriteLine("\rNumbers of customers: " + northwindEntities.Customers.Count());
            }
        }

        public static void StartFirstConnection()
        {
            using (var firstConnection = new NorthwindEntities())
            {
                PrintWhatFirstUserSees(firstConnection);
                StartSecondConnection(firstConnection);
                PrintWhatFirstUserSeesAfterChanges(firstConnection);
            }
        }

        public static void StartSecondConnection(NorthwindEntities firstConnection)
        {
            using (var secondConnection = new NorthwindEntities())
            {
                PrintWhatSecondUserSees(secondConnection);
                firstConnection.SaveChanges();
                secondConnection.SaveChanges();
                PrintWhatSecondUserSeesAfterChanges(secondConnection);
            }
        }

        public static void PrintWhatFirstUserSees(NorthwindEntities firstConnection)
        {
            Console.WriteLine("\rUser1 see: {0}\n", firstConnection.Employees.First().FirstName);
            var firstEmployee1 = firstConnection.Employees.First();
            firstEmployee1.FirstName = "1";
            Console.WriteLine("User1 changes the name with new value: {0}\n", firstConnection.Employees.First().FirstName);
        }

        public static void PrintWhatFirstUserSeesAfterChanges(NorthwindEntities firstConnection)
        {
            Console.WriteLine("After all changes:");
            Console.WriteLine("User1 see: {0}\n", firstConnection.Employees.First().FirstName);
        }

        public static void PrintWhatSecondUserSees(NorthwindEntities secondConnection)
        {
            Console.WriteLine("User2 see: {0}\n", secondConnection.Employees.First().FirstName);
            var firstEmployee2 = secondConnection.Employees.First();
            firstEmployee2.FirstName = "2";
            Console.WriteLine("User2 changes the name with new value: {0}\n", secondConnection.Employees.First().FirstName);
        }

        public static void PrintWhatSecondUserSeesAfterChanges(NorthwindEntities secondConnection)
        {
            Console.WriteLine("After all changes:");
            Console.WriteLine("User2 see: {0}\n", secondConnection.Employees.First().FirstName);
        }

        public static void PrintActualResult()
        {
            using (var northwindEntities = new NorthwindEntities())
            {
                Console.WriteLine("Actual result: {0}\n", northwindEntities.Employees.First().FirstName);
            }
        }

        public static void CreateNewClass()
        {
            // See file -> Northwind.Models -> `Employee.cs

            //using (var dbContext = new NorthwindEntities())
            //{
            //    foreach (var employee in dbContext.Employees.Include("Territories"))
            //    {
            //        var correspondingTerritories = employee.CorrespondingTerritories.Select(c => c.TerritoryID);
            //        var correspondingTerritoriesAsString = string.Join(", ", correspondingTerritories);
            //        Console.WriteLine("{0} -> Territory IDs: {1}", employee.FirstName, correspondingTerritoriesAsString);
            //    }
            //}
        }
    }
}
