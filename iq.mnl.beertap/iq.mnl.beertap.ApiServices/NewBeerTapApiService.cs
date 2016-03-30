using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using iq.mnl.beertap.ApiServices.Helper;
using iq.mnl.beertap.Model;
using iq.mnl.beertap.Repository;
using IQ.Platform.Framework.WebApi;

namespace iq.mnl.beertap.ApiServices
{
    public class NewBeerTapApiService : IApiApplicationServiceAsync<NewBeerTap, int>
    {
        private readonly IBeerTapRepository _repository;
        private readonly int _initialBeerVolume = int.Parse(ConfigurationManager.AppSettings["InitialBeerVolume"]);

        public NewBeerTapApiService(IBeerTapRepository repository)
        {
            _repository = repository;
        }

        public Task<ResourceCreationResult<NewBeerTap, int>> CreateAsync(NewBeerTap resource, IRequestContext context, CancellationToken cancellation)
        {
            try
            {
                if (resource.Volume == 0)
                    resource.Volume = _initialBeerVolume;

                context.SetLinkParameter<NewBeerTap>(0);
                var officeId = context.LinkParameters.Get<LinksParametersSource>().Value.OfficeId;

                var result = _repository.Save(resource.ToBeerTapDto(officeId));
                return Task.FromResult(new ResourceCreationResult<NewBeerTap, int>(new NewBeerTap
                {
                    Id = result.Id,
                    BeerName = result.BeerName,
                    Volume = result.Volume
                }));
            }
            catch (Exception)
            {
                throw ;
            }
        }

        public Task<IEnumerable<NewBeerTap>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            throw new System.NotImplementedException();
        }

        public Task<NewBeerTap> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            return Task.FromResult(new NewBeerTap()); 
        }

        public Task<NewBeerTap> UpdateAsync(NewBeerTap resource, IRequestContext context, CancellationToken cancellation)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(ResourceOrIdentifier<NewBeerTap, int> input, IRequestContext context, CancellationToken cancellation)
        {
            throw new System.NotImplementedException();
        }
    }
}
