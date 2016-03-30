using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace iq.mnl.beertap.Model
{
    /// <summary>
    /// resource for new beer tap
    /// </summary>
    public class NewBeerTap : IStatelessResource, IIdentifiable<int>
    {
        /// <summary>
        /// unique id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// BeerName
        /// </summary>
        public string BeerName { get; set; }
        
        /// <summary>
        /// volume
        /// </summary>
        public int Volume { get; set; }
    }
}
