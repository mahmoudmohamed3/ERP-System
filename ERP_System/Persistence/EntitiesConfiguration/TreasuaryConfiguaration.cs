

namespace ERP_System.Persistence.EntitiesConfiguration
{
    public class TreasuaryConfiguaration : IEntityTypeConfiguration<Treasury>
    {
        public void Configure(EntityTypeBuilder<Treasury> builder)
        {
            builder.HasIndex(x=> x.TreasuryID).IsUnique();

            builder.Property(x => x.TreasuryName).HasMaxLength(100);

        }
    }
}
