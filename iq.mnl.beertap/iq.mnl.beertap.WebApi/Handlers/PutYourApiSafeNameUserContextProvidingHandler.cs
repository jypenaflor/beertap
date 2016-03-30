using IQ.Platform.Framework.WebApi.AspNet;
using IQ.Platform.Framework.WebApi.AspNet.Handlers;
using IQ.Platform.Framework.WebApi.Services.Security;
using iq.mnl.beertap.ApiServices.Security;

namespace iq.mnl.beertap.WebApi.Handlers
{
    public class PutYourApiSafeNameUserContextProvidingHandler
            : ApiSecurityContextProvidingHandler<beertapApiUser, NullUserContext>
    {

        public PutYourApiSafeNameUserContextProvidingHandler(
            IStoreDataInHttpRequest<beertapApiUser> apiUserInRequestStore)
            : base(new beertapUserFactory(), CreateContextProvider(), apiUserInRequestStore)
        {
        }

        static ApiUserContextProvider<beertapApiUser, NullUserContext> CreateContextProvider()
        {
            return
                new ApiUserContextProvider<beertapApiUser, NullUserContext>(_ => new NullUserContext());
        }
    }
}