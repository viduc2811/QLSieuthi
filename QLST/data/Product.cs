using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLST.data
{
    [Table("Product")]
    public class Product
    {
        [Key] public Guid id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int salePrice { get; set; }
        public int price { get; set; }
        public int? idCat { get; set; }
        [ForeignKey("idCat")]
        public int nameCat { get; set; }
    }
}
