using MehdiRahimiProject1.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MehdiRahimiProject1.EntityMapps;

public class TicketEntityMap : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.HasOne<Passenger>()
            .WithMany();
        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Id).ValueGeneratedOnAdd();
        builder.Property(_ => _.ChooseTicketType).IsRequired();
        builder.Property(_ => _.TicketName).HasMaxLength(50).IsRequired();
    }
}