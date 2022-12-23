using Microsoft.EntityFrameworkCore;


namespace WebProje.Entities
{
    public class WebProjeDbContext : DbContext
    {
        public WebProjeDbContext(DbContextOptions options) : base(options)
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
    }
}
//(localdb)\MSSQLLocalDB