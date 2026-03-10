using Microsoft.EntityFrameworkCore;
using SecurityDemo.Models;

namespace SecurityDemo;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<SecretNote> Notes { get; set; } 
    public DbSet<UserProfile> UserProfiles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // 1. Seed UserProfiles
        modelBuilder.Entity<UserProfile>().HasData(
            new UserProfile { Id = 1, Name = "Admin", password = "password123", userRole = Role.Admin },
            new UserProfile { Id = 2, Name = "Olle", password = "123", userRole = Role.User },
            new UserProfile { Id = 3, Name = "Sara", password = "password", userRole = Role.User }
        );

        // 2. Seed SecretNotes (10 stycken)
        modelBuilder.Entity<SecretNote>().HasData(
            new SecretNote { Id = 1, Content = "Olles hemliga recept", OwnerId = "Olle" },
            new SecretNote { Id = 2, Content = "Admin: Serverlösenord 'Admin123'", OwnerId = "Admin" },
            new SecretNote { Id = 3, Content = "Sara: Min dagbok", OwnerId = "Sara" },
            new SecretNote { Id = 4, Content = "Admin: Mötesanteckningar", OwnerId = "Admin" },
            new SecretNote { Id = 5, Content = "Olle: Tandläkare kl 10", OwnerId = "Olle" },
            new SecretNote { Id = 6, Content = "Sara: Köp presenter", OwnerId = "Sara" },
            new SecretNote { Id = 7, Content = "Admin: Budget 2026", OwnerId = "Admin" },
            new SecretNote { Id = 8, Content = "Olle: Kom ihåg mjölk", OwnerId = "Olle" },
            new SecretNote { Id = 9, Content = "Sara: Semesterplaner", OwnerId = "Sara" },
            new SecretNote { Id = 10, Content = "Admin: Systemfixar", OwnerId = "Admin" }
        );
    }
}