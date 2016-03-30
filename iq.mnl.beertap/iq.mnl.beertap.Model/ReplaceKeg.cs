using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace iq.mnl.beertap.Model
{
    /// <summary>
    /// replace keg model
    /// </summary>
    public class ReplaceKeg : IStatelessResource, IIdentifiable<int>
    {
        /// <summary>
        /// Unique id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// beer name
        /// </summary>
        public string BeerName { get; set; }
        
        /// <summary>
        /// beer volume
        /// </summary>
        public int Volume { get; set; }
    }
}
