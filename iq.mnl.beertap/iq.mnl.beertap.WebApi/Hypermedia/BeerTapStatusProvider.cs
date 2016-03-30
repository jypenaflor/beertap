using System.Collections.Generic;
using iq.mnl.beertap.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;

namespace iq.mnl.beertap.WebApi.Hypermedia
{
    public class BeerTapStatusProvider : ResourceStateProviderBase<BeerTap, BeerTapStatus>
    {
        public override BeerTapStatus GetFor(BeerTap resource)
        {
            return resource.Status; 
        }

        protected override IDictionary<BeerTapStatus, IEnumerable<BeerTapStatus>> GetTransitions()
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<BeerTapStatus> All { get; }
    }
}