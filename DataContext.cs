using MehdiRahimiProject1.Classes;
using Microsoft.EntityFrameworkCore;

namespace MehdiRahimiProject1;

public class DataContext : DbContext
{
 private DbSet<Buss> Busses;
 private DbSet<Passenger> Passengers;
 private DbSet<Ticket> Tickets;
 
 protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
 {
  optionsBuilder.UseSqlServer("Server=.;Database=BussStation;Trusted_Connection=True;TrustServerCertificate=Yes");
 }

 protected override void OnModelCreating(ModelBuilder modelBuilder)
 {
  modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
 }
}
