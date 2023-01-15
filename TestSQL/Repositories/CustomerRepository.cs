
using Microsoft.Data.SqlClient;
using System.Data;
using TestSQL.Models;

namespace TestSQL.Repositories
{
    internal class CustomerRepository
    {
        public List<CustomerOrder> GetCustomers()
        {
            List<CustomerOrder> data = new List<CustomerOrder>();

            string connectionString = "Server=localhost;Database=W3School;Trusted_Connection=True;TrustServerCertificate=True;";
            string query = @"SELECT c.CustomerID,
	                                c.CustomerName,
	                                c.ContactName,
                                    c.Address,
                                    c.City,
                                    c.PostalCode,
                                    c.Country,
	                                o.OrderID,
                                    o.EmployeeID,
                                    o.OrderDate,
                                    o.ShipperID
                            FROM Customers c
                            JOIN orders o ON c.CustomerID = o.CustomerID
                            JOIN Order_details od ON o.OrderId = od.OrderId
                            JOIN Products p ON od.ProductID = p.ProductID
                            ORDER BY c.CustomerID";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                        while (sqlDataReader.Read())
                        {
                            data.Add(new CustomerOrder()
                            {
                                CustomerId = sqlDataReader.GetInt32("CustomerID"),
                                CustomerName = sqlDataReader.GetString("CustomerName"),
                                ContactName = sqlDataReader.GetString("ContactName"),
                                Address = sqlDataReader.GetString("Address"),
                                City = sqlDataReader.GetString("City"),
                                PostalCode = sqlDataReader.GetString("PostalCode"),
                                Country = sqlDataReader.GetString("Country"),
                                OrderID = sqlDataReader.GetInt32("CustomerID"),
                                EmployeeID = sqlDataReader.GetInt32("EmployeeID"),
                                OrderDate = sqlDataReader.GetDateTime("OrderDate"),
                                ShipperID = sqlDataReader.GetInt32("ShipperID")
                            });
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return data;
        }
    }
}
