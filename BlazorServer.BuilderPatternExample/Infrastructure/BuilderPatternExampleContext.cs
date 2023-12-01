using BlazorServer.BuilderPatternExample.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.BuilderPatternExample.Infrastructure
{
    public class BuilderPatternExampleContext : DbContext
    {
        public BuilderPatternExampleContext(DbContextOptions<BuilderPatternExampleContext> options) : base(options) { }

        DbSet<CustomPc> CustomPcs => Set<CustomPc>();
        DbSet<Cpu> Cpus => Set<Cpu>();
        DbSet<Gpu> Gpus => Set<Gpu>();
        DbSet<Ram> Rams => Set<Ram>();
        DbSet<HardDrive> HardDrives => Set<HardDrive>();
        DbSet<PcLevel> PcLevels => Set<PcLevel>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PcLevel>().HasData(
                new PcLevel { Id = 1, Description = "Base Model", Name = "Base Model", Slug = "BASE"},    
                new PcLevel { Id = 2, Description = "Mid Model", Name = "Mid Model", Slug = "MID"},    
                new PcLevel { Id = 3, Description = "Top Model", Name = "Top Model", Slug = "TOP"}    
            );

            modelBuilder.Entity<Cpu>().HasData(
                new Cpu { Id = 1, BaseSpeed = "1.5gHz", Cores = 4, Cost = 100, Description = "Intel i5", Name ="Intel i5", Slug = "BASE" },    
                new Cpu { Id = 2, BaseSpeed = "2.2gHz", Cores = 10, Cost = 250, Description = "Intel i7", Name ="Intel i7", Slug = "MID" },    
                new Cpu { Id = 3, BaseSpeed = "3gHz", Cores = 20, Cost = 500, Description = "Intel i9", Name ="Intel i9", Slug = "TOP" }    
            );

            modelBuilder.Entity<Gpu>().HasData(
                new Gpu { Id = 1, Cost = 300, Description = "NVIDIA GeForce RTX 2070", Name = "NVIDIA GeForce RTX 2070", Slug = "BASE" },
                new Gpu { Id = 2, Cost = 500, Description = "NVIDIA GeForce RTX 3070", Name = "NVIDIA GeForce RTX 3070", Slug = "MID" },
                new Gpu { Id = 3, Cost = 800, Description = "NVIDIA GeForce RTX 4070", Name = "NVIDIA GeForce RTX 4070", Slug = "TOP" }
            );

            modelBuilder.Entity<Ram>().HasData(
                new Ram { Id = 1, Cost = 50, Description = "8GB DDR5", Name = "8GB DDR5", RamAmount = 8, Type = "DDR5", Slug = "BASE"},    
                new Ram { Id = 2, Cost = 100, Description = "16GB DDR5", Name = "16GB DDR5", RamAmount = 16, Type = "DDR5", Slug = "MID"},    
                new Ram { Id = 3, Cost = 175, Description = "32GB DDR5", Name = "32GB DDR5", RamAmount = 32, Type = "DDR5", Slug = "TOP"}    
            );

            modelBuilder.Entity<HardDrive>().HasData(
                new HardDrive { Id = 1, Cost = 50, Description = "256GB SSD", Name = "256GB SSD", Size = 256, Type = "SSD", Slug = "BASE"},
                new HardDrive { Id = 2, Cost = 100, Description = "512GB SSD", Name = "512GB SSD", Size = 512, Type = "SSD", Slug = "MID"},
                new HardDrive { Id = 3, Cost = 200, Description = "1024GB SSD", Name = "1024GB SSD", Size = 1024, Type = "SSD", Slug = "TOP"}
            );

            modelBuilder.Entity<CustomPc>().HasData(
                new CustomPc { Id = 1, HardDriveId = 3, Name = "Fletcher Top Pc", GpuId = 3, CustomerName = "Fletcher", CpuId = 3, PcLevelId = 3, RamId = 3, Slug = "None", TotalCost = 1675, Description = "Fletche Top Pc" }    
            );
        }
    }
}
