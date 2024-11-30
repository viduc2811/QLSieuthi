using Microsoft.EntityFrameworkCore;
using QLST.Models;


namespace QLST.data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions option) : base(option)
        { }
            #region DbSet
                public DbSet<Product> ProductVN { get; set; }
                public DbSet<Category> Categories { get; set; }
            #endregion

    }
}
