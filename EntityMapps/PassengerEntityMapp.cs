using MehdiRahimiProject1.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MehdiRahimiProject1.EntityMapps;

public class PassengerEntityMapp : IEntityTypeConfiguration<Passenger>
{
    public void Configure(EntityTypeBuilder<Passenger> builder)
    {
        builder.HasOne<Buss>()
            .WithMany();
        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Id).ValueGeneratedOnAdd();
        builder.Property(_ => _.FirstName).HasMaxLength(50).IsRequired();
        builder.Property(_ => _.LastName).HasMaxLength(50).IsRequired();
        builder.Property(_ => _.PassengerSeat).IsRequired();
    }
}