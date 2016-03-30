using System;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using iq.mnl.beertap.ApiServices.Helper;
using iq.mnl.beertap.Model;
using iq.mnl.beertap.Repository;
using IQ.Platform.Framework.WebApi;

namespace iq.mnl.beertap.ApiServices
{
    public class ReplaceKegApiService : IApiApplicationServiceAsync<ReplaceKeg, int>
    {
        private readonly IBeerTapRepository _repository;
        private readonly int _initialBeerVolume = int.Parse(ConfigurationManager.AppSettings["InitialBeerVolume"]);

        public ReplaceKegApiService(IBeerTapRepository repository)
        {
            _repository = repository;
        }

        public Task<ResourceCreationResult<ReplaceKeg, int>> CreateAsync(ReplaceKeg resource, IRequestContext context, CancellationToken cancellation)
        {
            try
            {
                if (resource.Volume == 0)
                    resource.Volume = _initialBeerVolume;

                context.SetLinkParameter<ReplaceKeg>();

                var officeId = context.LinkParameters.Get<LinksParametersSource>().Value.OfficeId;
                var beerTapId = context.LinkParameters.Get<LinksParametersSource>().Value.BeerTapId;

                var result = _repository.Save(resource.ToBeerTapDto(officeId, beerTapId));

                return Task.FromResult(new ResourceCreationResult<ReplaceKeg, int>(new ReplaceKeg
                {
                    Id = result.Id,
                    BeerName = result.BeerName,
                    Volume = result.Volume
                }));
            }

            catch (Exception)
            {
                
                throw;
            }
        }

        public Task DeleteAsync(ResourceOrIdentifier<ReplaceKeg, int> input, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<ReplaceKeg> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            return Task.FromResult(new ReplaceKeg());

        }

        public Task<System.Collections.Generic.IEnumerable<ReplaceKeg>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<ReplaceKeg> UpdateAsync(ReplaceKeg resource, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
