using iq.mnl.beertap.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace iq.mnl.beertap.WebApi.Hypermedia
{
    public class OfficeSpec : SingleStateResourceSpec<Office, int>
    {
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({id})");
        
        public override string EntrypointRelation
        {
            get { return LinkRelations.Office; }
        }

        public override IResourceStateSpec<Office, NullState, int> StateSpec
        {
            get
            {
                return
                    new SingleStateSpec<Office, int>
                    {
                        Links =
                        {
                            CreateLinkTemplate(LinkRelations.BeerTap, BeerTapSpec.Uri.Many, r => r.Id),
                            CreateLinkTemplate(LinkRelations.NewBeerTap, NewBeerTapSpec.Uri, r => r.Id),
                        },

                        Operations =
                        {
                            Get = ServiceOperations.Get,
                            InitialPost = ServiceOperations.Create,
                            Post = ServiceOperations.Update,
                            Delete = ServiceOperations.Delete,
                        },
                    };
            }
        }
    }
}