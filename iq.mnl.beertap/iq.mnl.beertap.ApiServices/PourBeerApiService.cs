using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using iq.mnl.beertap.ApiServices.Helper;
using iq.mnl.beertap.Model;
using iq.mnl.beertap.Repository;
using iq.mnl.beertap.Repository.ModelDto;
using IQ.Platform.Framework.WebApi;

namespace iq.mnl.beertap.ApiServices
{
    public class PourBeerApiService : IApiApplicationServiceAsync<PourBeer, int>
    {
        private readonly IBeerTapRepository _repository;

        private readonly int _almostEmptyThreshold = int.Parse(ConfigurationManager.AppSettings["AlmostEmptyThreshold"]);

        public PourBeerApiService(IBeerTapRepository repository)
        {
            _repository = repository;
        }

        public Task<ResourceCreationResult<PourBeer, int>> CreateAsync(PourBeer resource, IRequestContext context, CancellationToken cancellation)
        {
            try
            {
                context.SetLinkParameter<PourBeer>();
                var beerTapId = context.LinkParameters.Get<LinksParametersSource>().Value.BeerTapId;
                var beerTap = _repository.Get(beerTapId);

                if (resource.Volume > beerTap.Volume)
                {
                    resource.Volume = beerTap.Volume;
                }

                beerTap.Volume = beerTap.Volume - resource.Volume;
                var newStatus = (BeerTapStatus)GetNewStatus(beerTap);

                beerTap.Status = (int)newStatus;
                _repository.Save(beerTap);

                return Task.FromResult(new ResourceCreationResult<PourBeer, int>(new PourBeer
                {
                    Id = beerTapId,
                    Volume = beerTap.Volume
                }));
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private BeerTapStatus GetNewStatus(BeerTapDto beerTap)
        {
            if (beerTap.Volume > _almostEmptyThreshold)
                return BeerTapStatus.GoinDown;

            if ((beerTap.Volume < _almostEmptyThreshold) && (beerTap.Volume > 0))
                return BeerTapStatus.AlmostEmpty;

            return BeerTapStatus.SheIsDryMate;
        }
        
        public Task<IEnumerable<PourBeer>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            throw new System.NotImplementedException();
        }

        public Task<PourBeer> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            return Task.FromResult(new PourBeer());
        }

        public Task<PourBeer> UpdateAsync(PourBeer resource, IRequestContext context, CancellationToken cancellation)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(ResourceOrIdentifier<PourBeer, int> input, IRequestContext context, CancellationToken cancellation)
        {
            throw new System.NotImplementedException();
        }
    }
}
