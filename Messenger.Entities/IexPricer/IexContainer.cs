namespace Messenger.Entities.IexPricer
{
    public class IexContainer<TPayLoad>
    {
        public IexContainer(TPayLoad payLoad, string attributionTitle, string attributionUrl)
        {
            PayLoad = payLoad;
            AttributionTitle = attributionTitle;
            AttributionUrl = attributionUrl;
        }
        public string AttributionTitle { get; }
        public string AttributionUrl { get; }
        public TPayLoad PayLoad { get; }
    }
}