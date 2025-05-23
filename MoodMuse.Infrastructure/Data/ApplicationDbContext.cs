using Microsoft.EntityFrameworkCore;
using MoodMuse.Core.Models;

namespace MoodMuse.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<MoodEntry> MoodEntries { get; set; }
    public DbSet<MusicRecommendation> MusicRecommendations { get; set; }
    public DbSet<MovieRecommendation> MovieRecommendations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<MoodEntry>()
            .HasOne(m => m.User)
            .WithMany(u => u.MoodEntries)
            .HasForeignKey(m => m.UserId);
    }
} 