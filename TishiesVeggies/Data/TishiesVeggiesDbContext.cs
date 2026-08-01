using Microsoft.EntityFrameworkCore;

namespace TishiesVeggies.Data
{
    public class TishiesVeggiesDbContext : DbContext
    {
        //Creating Tables in the database
        public DbSet<Fruit> Fruits { get; set; }
        public DbSet<Log> Logs { get; set; }

        //Constructor
        public TishiesVeggiesDbContext(DbContextOptions<TishiesVeggiesDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // store the enum as text ("Fruit"/"Vegie") rather than 0/1,
            // so raw DB data is readable if you ever inspect it
            modelBuilder.Entity<Fruit>()
                .Property(f => f.Category) 
                .HasConversion<string>();

            //Establishing the relationship between the tables
            modelBuilder.Entity<Log>()
                .HasOne(l => l.Fruit)
                .WithMany(f => f.Logs)
                .HasForeignKey(l => l.FruitId)
                .OnDelete(DeleteBehavior.Restrict);

            // seed a starter catalog so the app isn't empty on first run
            modelBuilder.Entity<Fruit>().HasData(
                new Fruit { Id = 1, Name = "Carrot", Category = ItemCategory.Veggie },
                new Fruit { Id = 2, Name = "Broccoli", Category = ItemCategory.Veggie },
                new Fruit { Id = 3, Name = "Peas", Category = ItemCategory.Veggie },
                new Fruit { Id = 4, Name = "Spinach", Category = ItemCategory.Veggie },
                new Fruit { Id = 5, Name = "Apple", Category = ItemCategory.Fruit },
                new Fruit { Id = 6, Name = "Banana", Category = ItemCategory.Fruit },
                new Fruit { Id = 7, Name = "Orange", Category = ItemCategory.Fruit },
                new Fruit { Id = 8, Name = "Grapes", Category = ItemCategory.Fruit },
                new Fruit { Id = 9, Name = "Onion", Category = ItemCategory.Veggie },
                new Fruit { Id = 10, Name = "Sweetcorn", Category = ItemCategory.Veggie }

            );
        }


    }
}
