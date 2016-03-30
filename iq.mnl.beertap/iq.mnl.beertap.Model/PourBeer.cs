using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace iq.mnl.beertap.Model
{
    /// <summary>
    /// pourbeer model
    /// </summary>
    public class PourBeer : IStatelessResource, IIdentifiable<int>
    {
        /// <summary>
        /// Unique Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// amount of beer to deduct in beer tap
        /// </summary>
        public int Volume { get; set; }
    }
}
