using Microsoft.EntityFrameworkCore;

namespace H5D_Delivery.Mgmt.Backend.Customer.Persistence
{
    public sealed class CustomerContext : DbContext
    {
        public DbSet<Domain.Customer>? Customers { get; set; }

        public CustomerContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var customer = modelBuilder.Entity<Domain.Customer>();
            customer.HasKey(x => x.Id);
            customer.Property(x => x.Name);
            customer.Property(x => x.Address);
            customer.Property(x => x.EMail);
            customer.Property(x => x.PhoneNumber);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //string Thomas: @"Server=.;Database=Auftragsverwaltung;Trusted_Connection=True;";
                //string Angelo: @"Server=KOLLEG-MPC\ZBW;Database=Auftragsverwaltung;Trusted_Connection=True;";
                //string Corina: @"Server=.;Database=AuftragsverwaltungHistory;Trusted_Connection=True;";

                //DATABASE MUSS ZWINGEND - AuftragsverwaltungHistory - HEISSEN!
                string connection = "Data Source = localhost,1433; ; Database=H5D-Db;User Id=sa; Password=123456789;TrustServerCertificate=True";

                optionsBuilder.UseSqlServer(connection);
                optionsBuilder.LogTo(Console.WriteLine);
            }

        }
    }
}
