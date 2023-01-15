namespace TestSQL.Models
{
    internal class Order
    {
        public int OrderID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime OrderDate { get; set; }
        public int ShipperID { get; set; }
    }
}
