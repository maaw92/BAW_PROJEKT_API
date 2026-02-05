using Core_Api_Test.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class DefaultDbContext : DbContext
{
    public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<MovieEvent> MovieEvents { get; set; }
    public DbSet<Seat> Seats { get; set; }
    public DbSet<SeatReservation> Reservations { get; set; }
}