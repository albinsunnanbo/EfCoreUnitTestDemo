using Microsoft.EntityFrameworkCore;

namespace Core.Entities
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        { }

        public DbSet<FooBar> FooBars { get; set; }
    }

    public class FooBar
    {
        public int FooBarId { get; set; }
        public string Text { get; set; }
    }
}