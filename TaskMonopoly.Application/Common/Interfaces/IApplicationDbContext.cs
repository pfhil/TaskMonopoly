using Microsoft.EntityFrameworkCore;
using TaskMonopoly.Domain.Entities;

namespace TaskMonopoly.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Box> Boxes { get; set; }
        DbSet<Pallet> Pallets { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
