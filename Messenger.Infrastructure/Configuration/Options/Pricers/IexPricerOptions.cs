namespace Messenger.Infrastructure.Configuration.Options.Pricers
{
    public class IexPricerOptions
    {
        public readonly string SectionName = "IexPricer";
        public IexPricerOptions()
        {

        }

        public IexPricerAttributionOptions Attribution { get; set; }
        public IexPricerApiOptions Api { get; set; }
    }

    public class IexPricerApiOptions
    {
        public string BaseUrl { get; set; }
        public string ApiVersion { get; set; }
        public string PublicToken { get; set; }
    }

    public class IexPricerAttributionOptions
    {
        public string Title { get; set; }
        public string Url { get; set; }
    }
}