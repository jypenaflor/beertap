using System.Collections.Generic;
using iq.mnl.beertap.Repository.ModelDto;

namespace iq.mnl.beertap.Repository
{
    public interface IOfficeRepository : IRepository<OfficeDto, int>
    {
        IEnumerable<OfficeDto> GetAll();
    }
}
