using iq.mnl.beertap.Model;
using IQ.Platform.Framework.WebApi;

namespace iq.mnl.beertap.ApiServices
{
    public interface ISampleApiService :
        IGetAResourceAsync<SampleResource, string>,
        IGetManyOfAResourceAsync<SampleResource, string>,
        ICreateAResourceAsync<SampleResource, string>,
        IUpdateAResourceAsync<SampleResource, string>,
        IDeleteResourceAsync<SampleResource, string>
    {
    }
}
