using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLST.data
{
    [Table("Category")]
    public class Category
    {
        [Key] public int idCat { get; set; }
        public string nameCat { get; set; }
        public virtual ICollection<Product> ProductVN { get; set; }
    }
}
