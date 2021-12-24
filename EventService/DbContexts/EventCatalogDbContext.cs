using EventService.Entities;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;

namespace EventService.DbContexts
{
    public class EventCatalogDbContext : DbContext
    {
        public EventCatalogDbContext(DbContextOptions<EventCatalogDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var concertId = new Random().Next(1000);
            var basketballId = new Random().Next(1000);
            var baseballId = new Random().Next(1000);
            var footballId = new Random().Next(1000);
            var hockeyId = new Random().Next(1000);

            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = concertId,
                Name = "Concerts"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = basketballId,
                Name = "Basketball"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = baseballId,
                Name = "Baseball"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = footballId,
                Name = "Football"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = hockeyId,
                Name = "Hockey"
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventId = new Random().Next(1000),
                Name = "John Egbert Live",
                Price = 65,
                Artist = "John Egbert",
                Date = Timestamp.FromDateTimeOffset(DateTime.Now.AddMonths(6)),
                Description = "Join John for his farwell tour across 15 continents. John really needs no introduction since he has already mesmerized the world with his banjo.",
                ImageUrl = "/img/banjo.jpg",
                CategoryId = concertId
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventId = new Random().Next(1000),
                Name = "Utah Jazz @ San Antonio Spurs",
                Price = new Random().Next(500),
                Artist = "",
                Date = Timestamp.FromDateTimeOffset(DateTime.Now.AddMonths(9)),
                Description = "The Jazz visit San Antonio!",
                ImageUrl = "/img/UtahAtSA.jpg",
                CategoryId = basketballId
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventId = new Random().Next(1000),
                Name = "Los Angeles Dodgers @ San Francisco Giants",
                Price = new Random().Next(500),
                Artist = "",
                Date = Timestamp.FromDateTimeOffset(DateTime.Now.AddMonths(9)),
                Description = "The Dodgers visit Oracle Park to take on the MLB leading Giants!",
                ImageUrl = "/img/dodgersAtGiants.jpg",
                CategoryId = baseballId
            });
        }
    }
}
