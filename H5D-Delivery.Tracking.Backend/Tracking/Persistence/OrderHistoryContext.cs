using H5D_Delivery.Tracking.Backend.Tracking.Domain;
using Microsoft.EntityFrameworkCore;

namespace H5D_Delivery.Tracking.Backend.Tracking.Persistence
{
    public class OrderHistoryContext : DbContext
    {
        public DbSet<OrderHistory>? OrderHistory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#if DEBUG
                string connection =
                    "Data Source = localhost,1433; ; Database=H5D-Db;User Id=sa; Password=H@a123456789;TrustServerCertificate=True";
#else
                string connection =
                    "Data Source = 10.5.0.21,1433; ; Database=H5D-Db;User Id=sa; Password=H@a123456789;TrustServerCertificate=True";
#endif
                optionsBuilder.UseSqlServer(connection);
                optionsBuilder.LogTo(Console.WriteLine);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var item = modelBuilder.Entity<OrderHistory>();
            item.HasKey(x => x.Id);
            item.Property(x => x.DateTime);
            item.Property(x => x.Status);
            item.Property(x => x.CustomerName);

            item.ToTable("OrderHistory");

            base.OnModelCreating(modelBuilder);
        }
    }
}
