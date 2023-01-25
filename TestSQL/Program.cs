// See https://aka.ms/new-console-template for more information
using TestSQL.ExtensionMethods;
using TestSQL.Models;
using TestSQL.Repositories;

Console.WriteLine("Program start...\n");
List<Customer> customers = new List<Customer>();
CustomerRepository customerRepository = new CustomerRepository();

Query query = new Query()
{
    Parameters = new Dictionary<string, object>
    {
        { "CustomerId", 2 }
    }
};

try
{
    customers = customerRepository.GetCustomers(query).ToCustomerList();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    return;
}

customers.PrintToScreen();
Console.WriteLine("Program finished...");
Console.ReadLine();