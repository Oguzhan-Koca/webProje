using Microsoft.EntityFrameworkCore;


namespace WebProje.Models.Entities
{
    public class YeniDbContext : DbContext
    {
        public YeniDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Hakkimizda> Hakkimizda { get; set; }
        public DbSet<Urun> Urun { get; set; }
        public DbSet<Iletisim> Iletisim { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<Kimlik> Kimlik { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<Yorum> Yorum { get; set; }
        public DbSet<Yeni> Yeni { get; set; }
    }
}
//(localdb)\MSSQLLocalDB