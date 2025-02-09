namespace Project.Models
{
    public class Context : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<GameDevice> GameDevice { get; set; }

        public Context(DbContextOptions options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameDevice>()
                .HasKey(e => new { e.DeviceId, e.GameId });

            modelBuilder.Entity<Device>()
                .HasData(new Device[]
                {
                    new Device {Id = 1 , Name = "PlayStation" , Icon = "bi bi-playstation"},
                    new Device {Id = 2 , Name = "xbox" , Icon = "bi bi-xbox"},
                    new Device {Id = 3 , Name = "Nintendo Switch" , Icon = "bi bi-nintendo-switch"},
                    new Device {Id = 4 , Name = "PC" , Icon = "bi bi-pc-display"},
                });

            modelBuilder.Entity<Categorie>()
            .HasData(new Categorie[]
            {
                new Categorie {Id = 1 , Name = "Sports" },
                new Categorie {Id = 2 , Name = "Action" },
                new Categorie {Id = 3 , Name = "Adventure" },
                new Categorie {Id = 4 , Name = "Racing" },
                new Categorie {Id = 5 , Name = "Fighting" },
                new Categorie {Id = 6 , Name = "Film" },
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
