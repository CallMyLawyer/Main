using MehdiRahimiProject1.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MehdiRahimiProject1.EntityMapps;

public class BussEntityMapp : IEntityTypeConfiguration<Buss>
{
    public void Configure(EntityTypeBuilder<Buss> builder)
    {
        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(_ => _.Name).HasMaxLength(50).IsRequired();
        builder.Property(_ => _.SetTypeOfBuss).IsRequired();
        builder.Property(_ => _.Origin).HasMaxLength(50).IsRequired();
        builder.Property(_ => _.Destination).HasMaxLength(50).IsRequired();
        builder.Property(_ => _.TicketPrice).IsRequired();
    }
}