
using Microsoft.Data.SqlClient;
using System.Data;
using TestSQL.Models;

namespace TestSQL.Repositories
{
    internal class CustomerRepository
    {
        public List<CustomerOrder> GetCustomers(Query queryParam = null)
        {
            List<CustomerOrder> data = new List<CustomerOrder>();
            string customerId = queryParam?.Parameters["CustomerId"].ToString();

            var customerQuery = string.IsNullOrEmpty(customerId) ? "" : @"WHERE c.CustomerID = @CustomerId";

            string connectionString = "Server=localhost;Database=W3School;Trusted_Connection=True;TrustServerCertificate=True;";
            string query = @$"SELECT c.CustomerID,
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
                            {customerQuery}
                            ORDER BY c.CustomerID";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("@CustomerId", queryParam?.Parameters["CustomerId"]));
                        //sqlCommand.Parameters.AddWithValue("@CustomerId", queryParam?.Parameters["CustomerId"].ToString());
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
            catch
            {
                throw;
            }

            return data;
        }
    }
}
