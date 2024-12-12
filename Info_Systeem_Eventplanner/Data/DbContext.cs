using Info_Systeem_Eventplanner.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Info_Systeem_Eventplanner.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Ticket> Tickets { get; set; } // Voeg DbSet voor Ticket toe

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relatie tussen AppUser en Reservation (een User kan meerdere Reservations hebben)
            modelBuilder.Entity<Reservation>()
                .HasOne(e => e.AppUser)
                .WithMany(m => m.reservations)
                .HasForeignKey(e => e.UserID);

            // Relatie tussen Event en Reservation (een Event kan meerdere Reservations hebben)
            modelBuilder.Entity<Reservation>()
                .HasOne(e => e.Event)
                .WithMany(ev => ev.Reservations)
                .HasForeignKey(e => e.EventID);

            // Seed data voor AppUser
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser { UserID = 1, Name = "Jörn Neiss", Email = "JornNeiss@gmail.com" },
                new AppUser { UserID = 2, Name = "Charles Benschop", Email = "CharlesBenschop@gmail.com" },
                new AppUser { UserID = 3, Name = "Joop Buyt", Email = "JoopBuyt@gmail.com" }
            );

            // Seed data voor Event
            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    EventID = 1,
                    EventName = "AC Milan - Napoli",
                    EventDescription = "Een spannende Serie A wedstrijd tussen 2 titelkandidaten Ac Milan en Napoli.",
                    DateTime = DateTime.Now.AddDays(43),
                    MaxParticipants = 100,
                    ImagePath = "/images/ACMilan"
                },
                new Event
                {
                    EventID = 2,
                    EventName = "Alemannia Aachen - RW Essen",
                    EventDescription = "De spannende 3. Bundesliga wedstrijd tussen Alemannia Aachen en RW Essen.",
                    DateTime = DateTime.Now.AddDays(12),
                    MaxParticipants = 10000,
                    ImagePath = "/images/Alemannia"
                },
                new Event
                {
                    EventID = 3,
                    EventName = "Roda JC - MVV Maastricht",
                    EventDescription = "De derby van het zuiden de Keukenkampioen divisie wedstrijd tussen Roda JC Kerkrade en MVV Maastricht.",
                    DateTime = DateTime.Now.AddDays(27),
                    MaxParticipants = 14000,
                    ImagePath = "/images/RodaJCMVV"
                }
            );

            // Seed data voor Reservation
            modelBuilder.Entity<Reservation>().HasData(
                new Reservation { ReservationID = 1, UserID = 1, EventID = 1 },
                new Reservation { ReservationID = 2, UserID = 2, EventID = 2 },
                new Reservation { ReservationID = 3, UserID = 3, EventID = 3 }
            );

            // Seed data voor Ticket
            modelBuilder.Entity<Ticket>().HasData(
                new Ticket { TicketId = 1, TicketPrice = 39, IsReserved = true, EventID = 1 }, // Verwijzing naar EventID 1
                new Ticket { TicketId = 2, TicketPrice = 20, IsReserved = false, EventID = 2 }, // Verwijzing naar EventID 2
                new Ticket { TicketId = 3, TicketPrice = 15, IsReserved = false, EventID = 3 }  // Verwijzing naar EventID 3
            );
        }
    }
}



