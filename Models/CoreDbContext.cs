using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace eQERPGYF_WebAPI.Models
{
    public partial class CoreDbContext : DbContext
    {
        public CoreDbContext()
        {
        }

        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<States> States { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Taluk> Taluk { get; set; }
        public virtual DbSet<Blocks> Blocks { get; set; }
        public virtual DbSet<Village> village { get; set; }
        public virtual DbSet<PinCode> PinCode { get; set; }
        public virtual DbSet<Farmer> Farmer { get; set; }
        public virtual DbSet<FarmDetails> FarmDetails { get; set; }
        public virtual DbSet<FarmingType> FarmingType { get; set; }
        public virtual DbSet<Crops> Crops { get; set; }
        public virtual DbSet<LiveStock> LiveStock { get; set; }
        public virtual DbSet<IrrigationFacility> IrrigationFacility { get; set; }
        public virtual DbSet<PushNotification> PushNotification { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration["ConnectionStrings:SqlServerConnection"]);
        }
    }
}