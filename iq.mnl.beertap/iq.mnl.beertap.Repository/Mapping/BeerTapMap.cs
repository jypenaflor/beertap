using System.Data.Entity.ModelConfiguration;
using iq.mnl.beertap.Repository.ModelDto;

namespace iq.mnl.beertap.Repository.Mapping
{
    public class BeerTapMap : EntityTypeConfiguration<BeerTapDto>
    {
        public BeerTapMap()
        {
            HasKey(t => t.Id);
            ToTable("BeerTap");

            Property(t => t.BeerName).HasColumnName("BeerName");
            Property(t => t.OfficeId).HasColumnName("OfficeId");
            Property(t => t.Volume).HasColumnName("Volume");
            Property(t => t.Status).HasColumnName("Status");
        }
    }
}