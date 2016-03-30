using System.Collections.Generic;
using System.Linq;
using iq.mnl.beertap.Model;
using iq.mnl.beertap.Repository.ModelDto;

namespace iq.mnl.beertap.ApiServices.Helper
{
    public static class BeerTapExtension
    {
        public static BeerTap ToBeerTapResource(this BeerTapDto dto)
        {
            return new BeerTap
            {
                Id = dto.Id,
                BeerName = dto.BeerName,
                OfficeId = dto.OfficeId,
                Status = (BeerTapStatus)dto.Status,
                Volume = dto.Volume
            };
        }

        public static BeerTapDto ToBeerTapDto(this BeerTap resource)
        {
            return new BeerTapDto
            {
                Id = resource.Id,
                BeerName = resource.BeerName,
                OfficeId = resource.OfficeId,
                Status = (int)resource.Status,
                Volume = resource.Volume
            };
        }

        public static BeerTapDto ToBeerTapDto(this NewBeerTap resource, int officeId)
        {
            return new BeerTapDto
            {
                BeerName = resource.BeerName,
                OfficeId = officeId,
                Status = (int)BeerTapStatus.New,
                Volume = resource.Volume
            };
        }

        public static BeerTapDto ToBeerTapDto(this ReplaceKeg resource, int officeId, int beerTapId)
        {
            return new BeerTapDto
            {
                Id = beerTapId,
                BeerName = resource.BeerName,
                OfficeId = officeId,
                Status = (int)BeerTapStatus.New,
                Volume = resource.Volume
            };
        }

        public static IEnumerable<BeerTap> ToBeerTapsResource(this IEnumerable<BeerTapDto> dto)
        {
            return dto.Select(o => new BeerTap
            {
                Id = o.Id,
                BeerName = o.BeerName,
                OfficeId = o.OfficeId,
                Status = (BeerTapStatus)o.Status,
                Volume = o.Volume

            }).ToList();
        }
    }
}