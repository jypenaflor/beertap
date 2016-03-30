using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using iq.mnl.beertap.ApiServices.Helper;
using iq.mnl.beertap.Model;
using iq.mnl.beertap.Repository;
using IQ.Platform.Framework.WebApi;

namespace iq.mnl.beertap.ApiServices
{
    public class BeerTapApiService : IApiApplicationServiceAsync<BeerTap, int>
    {
        private readonly IBeerTapRepository _repository;

        public BeerTapApiService(IBeerTapRepository repository)
        {
            _repository = repository;
        }

        public Task<ResourceCreationResult<BeerTap, int>> CreateAsync(BeerTap resource, IRequestContext context, CancellationToken cancellation)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<BeerTap>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            try
            {
                context.SetLinkParameter<BeerTap>(0);
                var officeId = context.LinkParameters.Get<LinksParametersSource>().Value.OfficeId;

                return Task.FromResult(_repository.GetAllByOfficeId(officeId).ToBeerTapsResource());
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        public Task<BeerTap> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            try
            {
                if (context == null) throw new ArgumentNullException(nameof(context));
                context.SetLinkParameter<BeerTap>(id);
                return Task.FromResult(_repository.Get(id).ToBeerTapResource());
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public Task<BeerTap> UpdateAsync(BeerTap resource, IRequestContext context, CancellationToken cancellation)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(ResourceOrIdentifier<BeerTap, int> input, IRequestContext context, CancellationToken cancellation)
        {
            try
            {
                return Task.FromResult(_repository.Delete(input.Id));
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
