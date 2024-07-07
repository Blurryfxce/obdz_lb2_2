namespace obdz_lb2_2;

using Microsoft.EntityFrameworkCore;
using obdz_lb2_2.Models;

public class ApplicationDbContext : DbContext
{
    public DbSet<Theater> Theaters { get; set; }
    public DbSet<Screen> Screens { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Showtime> Showtimes { get; set; }
    public DbSet<Viewer> Viewers { get; set; }
    public DbSet<Ticket> Tickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseOracle("User Id=c##sanax;Password=bebra;Data Source=//localhost:1521/XE");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Theater>(entity =>
        {
            entity.HasKey(e => e.TheaterId);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Phone).HasMaxLength(15);
            entity.HasMany(e => e.Screens)
                .WithOne(e => e.Theater)
                .HasForeignKey(e => e.TheaterId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Screen>(entity =>
        {
            entity.HasKey(e => e.ScreenId);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Capacity).IsRequired();

            entity.HasOne(d => d.Theater)
                .WithMany(p => p.Screens)
                .HasForeignKey(d => d.TheaterId);
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.MovieId);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Duration).IsRequired();
            entity.Property(e => e.Genre).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(500);
        });

        modelBuilder.Entity<Showtime>(entity =>
        {
            entity.HasKey(e => e.ShowtimeId);
            entity.Property(e => e.StartTime).IsRequired();
            entity.Property(e => e.EndTime).IsRequired();

            entity.HasOne(d => d.Screen)
                .WithMany(p => p.Showtimes)
                .HasForeignKey(d => d.ScreenId);

            entity.HasOne(d => d.Movie)
                .WithMany(p => p.Showtimes)
                .HasForeignKey(d => d.MovieId);
        });

        modelBuilder.Entity<Viewer>(entity =>
        {
            entity.HasKey(e => e.ViewerId);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId);

            entity.HasOne(d => d.Viewer)
                .WithMany(p => p.Tickets)
                .HasForeignKey(d => d.ViewerId);

            entity.HasOne(d => d.Showtime)
                .WithMany(p => p.Tickets)
                .HasForeignKey(d => d.ShowtimeId);
        });
    }
}
