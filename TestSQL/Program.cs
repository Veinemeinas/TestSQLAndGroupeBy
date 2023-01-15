// See https://aka.ms/new-console-template for more information
using TestSQL.ExtensionMethods;
using TestSQL.Models;
using TestSQL.Repositories;

Console.WriteLine("Program start...\n");
CustomerRepository customerRepository = new CustomerRepository();
List<Customer> data = customerRepository.GetCustomers().ToCustomerList();
data.PrintToScreen();
Console.WriteLine("Program finished...");
Console.ReadLine();