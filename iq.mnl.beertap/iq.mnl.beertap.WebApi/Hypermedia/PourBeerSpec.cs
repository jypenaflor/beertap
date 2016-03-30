using System.Collections.Generic;
using iq.mnl.beertap.ApiServices;
using iq.mnl.beertap.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace iq.mnl.beertap.WebApi.Hypermedia
{
    public class PourBeerSpec : SingleStateResourceSpec<PourBeer, int>
    {
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({officeId})/BeerTaps({beertapId})/PourBeer");

        protected override IEnumerable<ResourceLinkTemplate<PourBeer>> Links()
        {
            yield return CreateLinkTemplate<LinksParametersSource>(CommonLinkRelations.Self, Uri, x => x.Parameters.OfficeId, x => x.Parameters.BeerTapId);
        }

        public override IResourceStateSpec<PourBeer, NullState, int> StateSpec
        {
            get
            {
                return
                    new SingleStateSpec<PourBeer, int>
                    {
                        Links =
                            {
                                CreateLinkTemplate<LinksParametersSource>(LinkRelations.BeerTap, BeerTapSpec.Uri, i => i.Parameters.OfficeId, i => i.Parameters.BeerTapId),
                            },

                        Operations =
                            {
                                InitialPost = ServiceOperations.Create,
                            },
                    };
            }
        }
    }
}