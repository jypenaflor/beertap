using System.Collections.Generic;
using iq.mnl.beertap.ApiServices;
using iq.mnl.beertap.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace iq.mnl.beertap.WebApi.Hypermedia
{
    public class BeerTapSpec : ResourceSpec<BeerTap, BeerTapStatus, int>
    {

        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({officeId})/BeerTaps({id})");

        protected override IEnumerable<ResourceLinkTemplate<BeerTap>> Links()
        {
            yield return CreateLinkTemplate<LinksParametersSource>(CommonLinkRelations.Self, Uri, x => x.Parameters.OfficeId, x => x.Resource.Id);

        }
        
        protected override IEnumerable<IResourceStateSpec<BeerTap, BeerTapStatus, int>> GetStateSpecs()
        {
            yield return new ResourceStateSpec<BeerTap, BeerTapStatus, int>(BeerTapStatus.New)
            {
                Links =
                    {
                        CreateLinkTemplate<LinksParametersSource>(LinkRelations.Office, OfficeSpec.Uri, x => x.Parameters.OfficeId),
                        CreateLinkTemplate<LinksParametersSource>(LinkRelations.PourBeer, PourBeerSpec.Uri, x => x.Parameters.OfficeId, x => x.Resource.Id),
                    },

                Operations = new StateSpecOperationsSource<BeerTap, int>()
                {
                    Get = ServiceOperations.Get,
                    Delete = ServiceOperations.Delete,
                }
            };

            yield return new ResourceStateSpec<BeerTap, BeerTapStatus, int>(BeerTapStatus.GoinDown)
            {
                Links =
                    {
                        CreateLinkTemplate<LinksParametersSource>(LinkRelations.Office, OfficeSpec.Uri, x => x.Parameters.OfficeId),
                        CreateLinkTemplate<LinksParametersSource>(LinkRelations.PourBeer, PourBeerSpec.Uri, x => x.Parameters.OfficeId, x => x.Resource.Id),
                    },

                Operations = new StateSpecOperationsSource<BeerTap, int>()
                {
                    Get = ServiceOperations.Get,
                    Delete = ServiceOperations.Delete,
                }
            };

            yield return new ResourceStateSpec<BeerTap, BeerTapStatus, int>(BeerTapStatus.AlmostEmpty)
            {
                Links =
                    {
                        CreateLinkTemplate<LinksParametersSource>(LinkRelations.Office, OfficeSpec.Uri, x => x.Parameters.OfficeId),
                        CreateLinkTemplate<LinksParametersSource>(LinkRelations.PourBeer, PourBeerSpec.Uri, x => x.Parameters.OfficeId, x => x.Resource.Id),
                        CreateLinkTemplate<LinksParametersSource>(LinkRelations.ReplaceKeg, ReplaceKegSpec.Uri, x => x.Parameters.OfficeId, x => x.Resource.Id),
                    },

                Operations = new StateSpecOperationsSource<BeerTap, int>()
                {
                    Get = ServiceOperations.Get,
                    Delete = ServiceOperations.Delete,
                }
            };

            yield return new ResourceStateSpec<BeerTap, BeerTapStatus, int>(BeerTapStatus.SheIsDryMate)
            {
                Links =
                    {
                        CreateLinkTemplate<LinksParametersSource>(LinkRelations.Office, OfficeSpec.Uri, x => x.Parameters.OfficeId),
                        CreateLinkTemplate<LinksParametersSource>(LinkRelations.ReplaceKeg, ReplaceKegSpec.Uri, x => x.Parameters.OfficeId, x => x.Resource.Id),

                    },

                Operations = new StateSpecOperationsSource<BeerTap, int>()
                {
                    Get = ServiceOperations.Get,
                    Delete = ServiceOperations.Delete,
                }
            };

        }
    }
}