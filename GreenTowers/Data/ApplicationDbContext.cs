using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using GreenTowers.Models.Domain;

namespace GreenTowers.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<IndividualWarning> IndividualWarnigns { get; set; }
        public DbSet<GlobalWarning> GlobalWarnigns { get; set; }
        public DbSet<CommonArea> CommonAreas { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Floor> Floors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5434;Database=pa;Username=postgres;Password=postgres");
        }
    }
}
