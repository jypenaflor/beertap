namespace iq.mnl.beertap.Model
{
    /// <summary>
    /// status of beer tap
    /// </summary>
    public enum BeerTapStatus
    {
        /// <summary>
        /// newly replaced
        /// </summary>
        New = 0,

        /// <summary>
        /// going down
        /// </summary>
        GoinDown = 1,

        /// <summary>
        /// almost empty
        /// </summary>
        AlmostEmpty = 2,

        /// <summary>
        /// no more beer
        /// </summary>
        SheIsDryMate = 3
    }
}