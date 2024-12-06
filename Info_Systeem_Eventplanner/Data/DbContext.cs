using Info_Systeem_Eventplanner.Models;
using Microsoft.EntityFrameworkCore;

namespace Info_Systeem_Eventplanner.Data
{

public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet-properties voor je nieuwe entiteiten
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Reservations> Reservations { get; set; }

        // Configuratie van de relaties
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ShoppingCart en AppUser: 1-op-1 relatie
            modelBuilder.Entity<ShoppingCart>()
                .HasOne(s => s.AppUser)
                .WithOne(u => u.ShoppingCart)
                .HasForeignKey<ShoppingCart>(s => s.UserId);

            // Ticket en ShoppingCart: 1-op-veel relatie
            modelBuilder.Entity<Ticket>()
                .HasMany(t => t.ShoppingCarts)  // Ticket heeft veel ShoppingCarts
                .WithMany(sc => sc.Tickets);


            base.OnModelCreating(modelBuilder);

            // Ticket en Event: 1-op-veel relatie
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Event)
                .WithMany(e => e.Tickets)
                .HasForeignKey(t => t.EventID);

            // Reservation en AppUser: 1-op-veel relatie
            modelBuilder.Entity<Reservations>()
                .HasOne(r => r.AppUser)
                .WithMany(u => u.Reservations)
                .HasForeignKey(r => r.UserId);

            // Reservation en Event: 1-op-veel relatie
            modelBuilder.Entity<Reservations>()
                .HasOne(r => r.Event)
                .WithMany(e => e.Reservations)
                .HasForeignKey(r => r.EventId);

            base.OnModelCreating(modelBuilder); // Roep de basisimplementatie aan
        }
    }

}

