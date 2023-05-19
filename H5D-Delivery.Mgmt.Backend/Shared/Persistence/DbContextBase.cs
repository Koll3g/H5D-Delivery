using Microsoft.EntityFrameworkCore;

namespace H5D_Delivery.Mgmt.Backend.Shared.Persistence
{
    public class DbContextBase<T> : DbContext where T : DbItem
    {
        public DbSet<T>? DbSet { get; set; }

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
    }
}
