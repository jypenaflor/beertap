using System.Collections.Generic;
using iq.mnl.beertap.Repository.ModelDto;

namespace iq.mnl.beertap.Repository
{
    public interface IBeerTapRepository : IRepository<BeerTapDto, int>
    {
        IEnumerable<BeerTapDto> GetAllByOfficeId(int officeId);
    }
}
