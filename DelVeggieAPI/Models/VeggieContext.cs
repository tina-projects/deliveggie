using Microsoft.EntityFrameworkCore;

namespace DelVeggieAPI.Models
{
    public class VeggieContext : DbContext
    {
        public VeggieContext(DbContextOptions<VeggieContext> options)
            : base(options)
        {
        }

        public DbSet<Veggie> Veggies { get; set; }
    }
}