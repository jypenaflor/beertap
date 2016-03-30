using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace iq.mnl.beertap.Model
{
    /// <summary>
    /// IQMetrix office
    /// </summary>
    public class Office : IIdentifiable<int>, IStatelessResource
    {
        /// <summary>
        /// Unique Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// office name
        /// </summary>
        public string Name { get; set; }
    }
}
