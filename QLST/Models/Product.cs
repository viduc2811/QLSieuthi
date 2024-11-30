namespace QLST.Models
{
    public class Product
    {
        public string name { get; set; }
        public double price{ get; set; }
    }
    public class ProductVN: Product
    {
        public Guid idProduct { get; set; }
    }
}
