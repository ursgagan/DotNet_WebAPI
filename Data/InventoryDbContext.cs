using InventoryAPIs.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace InventoryAPIs.Data
{
    public class InventoryDbContext : DbContext
    {
       // private static readonly string ICS = $"Server=DESKTOP-4UQI8GH;Database=InventoryDb;IntegratedSecurity=True;Trusted_Connection=True;";
        public InventoryDbContext() : base()
        {
            Database.SetInitializer<InventoryDbContext>(new CreateDatabaseIfNotExists<InventoryDbContext>());
        }
       
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Category> Category { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
   

}