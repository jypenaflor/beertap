using System.Collections.Generic;
using iq.mnl.beertap.ApiServices;
using iq.mnl.beertap.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace iq.mnl.beertap.WebApi.Hypermedia
{
    public class NewBeerTapSpec : SingleStateResourceSpec<NewBeerTap, int>
    {
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({officeId})/NewBeerTap");

        protected override IEnumerable<ResourceLinkTemplate<NewBeerTap>> Links()
        {
            yield return CreateLinkTemplate<LinksParametersSource>(CommonLinkRelations.Self, Uri, x => x.Parameters.OfficeId);
        }

        public override IResourceStateSpec<NewBeerTap, NullState, int> StateSpec
        {
            get
            {
                return
                    new SingleStateSpec<NewBeerTap, int>
                    {
                        Links =
                            {
                                CreateLinkTemplate<LinksParametersSource>(LinkRelations.Office, OfficeSpec.Uri, i => i.Parameters.OfficeId),
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