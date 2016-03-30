using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace iq.mnl.beertap.Model
{
    /// <summary>
    /// resource for beer tap
    /// </summary>
    public class BeerTap : IIdentifiable<int>, IStatefulResource<BeerTapStatus>
    {
        /// <summary>
        /// unique id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// description
        /// </summary>
        public string BeerName { get; set; }

        /// <summary>
        /// foreign key for office id
        /// </summary>
        public int OfficeId { get; set; }

        /// <summary>
        /// volume
        /// </summary>
        public int Volume { get; set; }

        /// <summary>
        /// beer tap status
        /// </summary>
        public BeerTapStatus Status { get; set; }

    }
}
