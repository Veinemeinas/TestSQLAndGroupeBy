// See https://aka.ms/new-console-template for more information
using TestSQL.ExtensionMethods;
using TestSQL.Models;
using TestSQL.Repositories;

Console.WriteLine("Program start...\n");
CustomerRepository customerRepository = new CustomerRepository();

Query query = new Query()
{
    Parameters = new Dictionary<string, object>
    {
        { "CustomerId", 2 }
    }
};

List<Customer> data = customerRepository.GetCustomers(query).ToCustomerList();
data.PrintToScreen();
Console.WriteLine("Program finished...");
Console.ReadLine();