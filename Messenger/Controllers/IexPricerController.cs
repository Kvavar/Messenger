using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messenger.Entities.IexPricer;
using Messenger.Infrastructure.Configuration.Options.Pricers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Pricer.IexCloudProvider;
using Pricer.IexCloudProvider.IexReferenceData;

namespace Messenger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IexPricerController : Controller
    {
        private readonly IIexProvider _iexProvider;
        private readonly IIexReferenceDataProvider _refProvider;
        private readonly string _attributionTitle;
        private readonly string _attributionUrl;

        public IexPricerController(IIexProvider iexProvider, IIexReferenceDataProvider refProvider, IOptions<IexPricerOptions> options)
        {
            _iexProvider = iexProvider;
            _refProvider = refProvider;
            _attributionTitle = options.Value.Attribution.Title ?? throw new ArgumentNullException(nameof(_attributionTitle));
            _attributionUrl = options.Value.Attribution.Url ?? throw new ArgumentNullException(nameof(_attributionUrl));
        }

        [HttpGet("ids")]
        public async Task<ActionResult> GetAvailableIds()
        {
            var ids = await _iexProvider.GetAvailableIdsAsync();
            var container = new IexContainer<IReadOnlyList<TimeseriesId>>(ids, _attributionTitle, _attributionUrl);

            return Json(container);
        }

        [HttpGet("symbols")]
        public async Task<ActionResult> GetAvailableFxSymbols()
        {
            var symbols = await _refProvider.GetAvailableFxSymbolsAsync();
            var result = symbols.Pairs.Select(s => s.Symbol).ToList();
            var container = new IexContainer<IReadOnlyList<string>>(result, _attributionTitle, _attributionUrl);

            return Json(container);
        }
    }
}