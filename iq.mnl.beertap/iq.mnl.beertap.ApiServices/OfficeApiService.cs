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
    public class OfficeApiService : IApiApplicationServiceAsync<Office, int>
    {
        private readonly IOfficeRepository _repository;

        public OfficeApiService(IOfficeRepository repository)
        {
            _repository = repository;
        }

        public Task<ResourceCreationResult<Office, int>> CreateAsync(Office resource, IRequestContext context, CancellationToken cancellation)
        {
            try
            {
                var result = _repository.Save(resource.ToOfficeDto());
                return Task.FromResult(new ResourceCreationResult<Office, int>(result.Id));
            }
            catch (Exception)
            {
                throw;
            }
                
            
        }

        public Task<IEnumerable<Office>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            try
            {
                return Task.FromResult(_repository.GetAll().ToOfficesResource());
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public Task<Office> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            try
            {
                return Task.FromResult(_repository.Get(id).ToOfficeResource());
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        public Task<Office> UpdateAsync(Office resource, IRequestContext context, CancellationToken cancellation)
        {
            try
            {
                var result = _repository.Save(resource.ToOfficeDto());
                return Task.FromResult(result.ToOfficeResource());
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public Task DeleteAsync(ResourceOrIdentifier<Office, int> input, IRequestContext context, CancellationToken cancellation)
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
