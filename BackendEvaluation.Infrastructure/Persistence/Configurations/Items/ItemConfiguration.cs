using BackendEvaluation.Domain.Models.Item;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace RD.Infrastructure.Persistence.Configurations;
public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.ToTable("Items", "itm");
        builder.HasKey(c => c.Id);
        builder.HasAlternateKey(x => x.Id);
    }
}