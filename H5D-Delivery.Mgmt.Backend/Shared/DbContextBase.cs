using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace H5D_Delivery.Mgmt.Backend.Shared
{
    public class DbContextBase<T> : DbContext where T : DbItem
    {
        public DbSet<T>? DbSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connection = "Data Source = localhost,1433; ; Database=H5D-Db;User Id=sa; Password=H@a123456789;TrustServerCertificate=True";

                optionsBuilder.UseSqlServer(connection);
                optionsBuilder.LogTo(Console.WriteLine);
            }
        }
    }
}
