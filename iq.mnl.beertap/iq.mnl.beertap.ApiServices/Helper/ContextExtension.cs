using System.Net;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi;

namespace iq.mnl.beertap.ApiServices.Helper
{
    public static class ContextExtension
    {
        public static void SetLinkParameter<T>(this IRequestContext context, int? beertapId = null) where T : class
        {
            var officeId = context.UriParameters.GetByName<int>("officeId")
                    .EnsureValue(() => context.CreateHttpResponseException<T>(
                        "The OfficeId must be supplied in the URI", HttpStatusCode.BadRequest));


            var localBeerTapId = beertapId ?? context.UriParameters.GetByName<int>("beertapId")
                .EnsureValue(() => context.CreateHttpResponseException<T>(
                    "The BeerTapId must be supplied in the URI", HttpStatusCode.BadRequest));

            context.LinkParameters.Set(new LinksParametersSource(officeId, localBeerTapId));
            
        }
    }
}
