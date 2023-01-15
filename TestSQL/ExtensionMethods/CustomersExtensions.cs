using System.Text;
using TestSQL.Models;

namespace TestSQL.ExtensionMethods
{
    internal static class CustomersExtensions
    {
        public static List<Customer> ToCustomerList(this List<CustomerOrder> customerOrders)
        {
            var groupedCustomers = customerOrders.GroupBy(co => new
            {
                CustomerId = co.CustomerId,
                CustomerName = co.CustomerName,
                ContactName = co.ContactName,
                Address = co.Address,
                City = co.City,
                PostalCode = co.PostalCode,
                Country = co.Country,
            })
            .Select(c => new Customer
            {
                CustomerId = c.Key.CustomerId,
                CustomerName = c.Key.CustomerName,
                ContactName = c.Key.ContactName,
                Address = c.Key.Address,
                City = c.Key.City,
                PostalCode = c.Key.PostalCode,
                Country = c.Key.Country,
                Orders = c.Select(o => new Order
                {
                    OrderDate = o.OrderDate,
                    EmployeeID = o.EmployeeID,
                    OrderID = o.OrderID,
                    ShipperID = o.ShipperID,
                }).ToList()
            }).ToList();

            return groupedCustomers;
        }

        public static void PrintToScreen(this List<Customer> customers)
        {
            StringBuilder sb = new StringBuilder();
            customers.ForEach(c =>
                {
                    sb.AppendLine(@$"{c.ContactName} | {c.ContactName} | {c.Address} | {c.City} | {c.PostalCode} | {c.Country}");
                    c.Orders.ForEach(o =>
                    {
                        sb.AppendLine(@$"{"\t"} {o.OrderDate.ToShortDateString()} {o.EmployeeID} {o.ShipperID}");
                    });
                    sb.AppendLine();
                });
            Console.WriteLine(sb);
        }
    }
}
