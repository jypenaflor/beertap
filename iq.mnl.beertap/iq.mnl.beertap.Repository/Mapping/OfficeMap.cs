using System.Data.Entity.ModelConfiguration;
using iq.mnl.beertap.Repository.ModelDto;

namespace iq.mnl.beertap.Repository.Mapping
{
    public class OfficeMap : EntityTypeConfiguration<OfficeDto>
    {
        public OfficeMap()
        {
            HasKey(t => t.Id);
            ToTable("Office");

            Property(t => t.Name).HasColumnName("Name");
        }
    }
}
