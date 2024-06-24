using kol2.Models;
using Microsoft.EntityFrameworkCore;

namespace kol2.Context;

public partial class myContext : DbContext
{
    public myContext()
    {
    }

    public myContext(DbContextOptions<myContext> options) : base(options)
    {
    }
    
    public DbSet<Item> Items { get; set; }
    public DbSet<Title> Titles { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<Backpack> Backpacks { get; set; }
    public DbSet<Character_title> CharacterTitles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Item>().HasData(new List<Item>
        {
            new Item {
                IdItem = 1,
                Name = "oksy",
                Weight = 20
            },
            new Item {
                IdItem = 2,
                Name = "Anna",
                Weight = 15
            }
        });
        
        modelBuilder.Entity<Title>().HasData(new List<Title>
        {
            new Title {
                IdTitle = 1,
                Name = "zzz",
            },
            new Title {
                IdTitle = 2,
                Name = "ccc",
            }
        });
        
        modelBuilder.Entity<Character>().HasData(new List<Character>
        {
            new Character {
                IdCharacter = 1,
                FirstName = "roman",
                LastName = "fuskii",
                CurrentWeight = 10,
                MaxWeight = 40
            },
            new Character {
                IdCharacter = 2,
                FirstName = "dd",
                LastName = "vcvc",
                CurrentWeight = 12,
                MaxWeight = 50
            }
        });
        
        modelBuilder.Entity<Backpack>().HasData(new List<Backpack>
        {
            new Backpack {
                IdCharacter = 1,
                IdItem = 2,
                Ammount = 1,
            },
            new Backpack {
                IdCharacter = 2,
                IdItem = 1,
                Ammount = 2,
            },
        });
        
        modelBuilder.Entity<Character_title>().HasData(new List<Character_title>
        {
            new Character_title {
                IdCharacter = 1,
                IdTitle = 1,
                AquiredAt = new DateTime(2024, 12, 05),
            },
            new Character_title {
                IdCharacter = 2,
                IdTitle = 2,
                AquiredAt = new DateTime(2023, 04, 12),
            },
        });
    }
}