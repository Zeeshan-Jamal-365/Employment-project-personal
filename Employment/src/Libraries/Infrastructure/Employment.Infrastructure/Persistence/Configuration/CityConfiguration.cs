using Employment.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employment.Infrastructure.Persistence.Configuration;
public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("Cities");
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.State).WithMany(x => x.Cities).HasForeignKey(x => x.StateId).IsRequired(true);
    }
}
