using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskMonopoly.Domain.Entities;

namespace TaskMonopoly.Persistence.EntityTypeConfigurations
{
    public class BoxConfiguration : IEntityTypeConfiguration<Box>
    {
        public void Configure(EntityTypeBuilder<Box> builder)
        {
            builder.HasKey(box => box.Id);
        }
    }
}
