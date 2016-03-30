using System.Data.Entity;
using iq.mnl.beertap.Repository.ModelDto;

namespace iq.mnl.beertap.Repository.Context
{
    public interface IBeerTapContext
    {
        DbSet<OfficeDto> Offices { get; set; }
        DbSet<BeerTapDto> BeerTaps { get; set; }

        void SaveDbChanges();
    }
}
