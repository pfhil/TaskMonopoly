using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TaskMonopoly.Application.Common.Interfaces;
using TaskMonopoly.Domain.Entities;

namespace TaskMonopoly.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Box> Boxes { get; set; }
        public DbSet<Pallet> Pallets { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
