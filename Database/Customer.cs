namespace Database;
public class Customer
{
    public string Name { get; set; }
    public List<Customer> Customers(string customerReceived)
    {
        
        List<Customer> customers = new();

        customers.Add(new Customer() { Name = "Mikkaiser"});

        return customers;
    }
}
