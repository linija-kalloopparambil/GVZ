using Microsoft.EntityFrameworkCore;
using Pizza_API.Data.Model;

namespace Pizza_API.Data
{
    public class PizzaContext : DbContext
    {
        public PizzaContext(DbContextOptions<PizzaContext> options) : base(options)
        {

        }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Topping> Toppings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Topping>()
               .HasOne(_ => _.Pizza)
               .WithMany(y => y.Toppings)
               .HasForeignKey(p => p.PizzaId);


        }
    }
}
