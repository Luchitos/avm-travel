using System.Data.Entity;
using System.Reflection.Emit;
using AVMTravel.Core.Entities;

namespace AVMTravel.Infrastructure.Data
{
    public class AvmTravelDbContext : DbContext
    {
        public AvmTravelDbContext() : base("name=AVMTravelDb")
        {
        }

        public DbSet<Tour> Tours { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Reserva>()
                .HasRequired(r => r.Tour);
        }
    }
}

//modelBuilder.Entity<Reserva>()
//    .HasRequired(r => r.Tour)
//    .WithMany(t => t.Reservas)
//    .HasForeignKey(r => r.TourId);