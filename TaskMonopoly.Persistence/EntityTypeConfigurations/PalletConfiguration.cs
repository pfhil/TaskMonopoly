using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskMonopoly.Domain.Entities;

namespace TaskMonopoly.Persistence.EntityTypeConfigurations
{
    public class PalletConfiguration : IEntityTypeConfiguration<Pallet>
    {
        public void Configure(EntityTypeBuilder<Pallet> builder)
        {
            builder.HasKey(pallet => pallet.Id);
            builder.Property(pallet => pallet.Id).ValueGeneratedNever();
        }
    }
}
