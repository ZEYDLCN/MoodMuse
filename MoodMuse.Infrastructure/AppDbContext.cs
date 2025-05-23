using Microsoft.EntityFrameworkCore;
using MoodMuse.Core;

namespace MoodMuse.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!; // Düzeltme
    public DbSet<MoodEntry> MoodEntries { get; set; } = null!; // Düzeltme
    public DbSet<MusicRecommendation> MusicRecommendations { get; set; } = null!; // Düzeltme
    public DbSet<MovieRecommendation> MovieRecommendations { get; set; } = null!; // Düzeltme

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasMany(u => u.MoodEntries)
            .WithOne(m => m.User)
            .HasForeignKey(m => m.UserId);
    }
}