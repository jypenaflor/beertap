using iq.mnl.beertap.Model;
using iq.mnl.beertap.Repository.ModelDto;
using System.Collections.Generic;
using System.Linq;

namespace iq.mnl.beertap.ApiServices.Helper
{
    public static class OfficeExtension
    {
        public static Office ToOfficeResource(this OfficeDto dto)
        {
            return new Office
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }

        public static OfficeDto ToOfficeDto(this Office resource)
        {
            return new OfficeDto
            {
                Id = resource.Id,
                Name = resource.Name
            };
        }

        public static IEnumerable<Office> ToOfficesResource(this IEnumerable<OfficeDto> dto)
        {
            return dto.Select(o => new Office
            {
                Id = o.Id, Name = o.Name
            }).ToList();
        }
    }
}
