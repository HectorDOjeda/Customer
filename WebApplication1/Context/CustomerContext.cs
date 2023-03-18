using Microsoft.EntityFrameworkCore;

namespace Customer.Context
{
    public class CustomerContext : DbContext
    {
        public DbSet<Customer.Models.Customer> Customer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=CustomerDB.db");

        public CustomerContext(DbContextOptions<CustomerContext> options)
    : base(options)
        {
        }
    }
}
