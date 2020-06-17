using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Messenger.Entities.IexPricer;
using Messenger.Entities.IexStock;
using Messenger.Infrastructure.Configuration.Options.Pricers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Pricer.IexCloudProvider;
using Pricer.IexCloudProvider.IexReferenceData;
using Pricer.IexCloudProvider.IexStock;

namespace Messenger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IexPricerController : Controller
    {
        private readonly IIexProvider _iexProvider;
        private readonly IIexReferenceDataProvider _refProvider;
        private readonly IIexOptionProvider _stockProvider;
        private readonly string _attributionTitle;
        private readonly string _attributionUrl;

        public IexPricerController(
            IIexProvider iexProvider, 
            IIexReferenceDataProvider refProvider, 
            IIexOptionProvider stockProvider,
            IOptions<IexPricerOptions> options)
        {
            _iexProvider = iexProvider;
            _refProvider = refProvider;
            _stockProvider = stockProvider;
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

        [HttpGet("fxsymbols")]
        public async Task<ActionResult> GetAvailableFxSymbols()
        {
            var symbols = await _refProvider.GetAvailableFxSymbolsAsync();
            var result = symbols.Pairs.Select(s => s.Symbol).ToList();
            var container = new IexContainer<IReadOnlyList<string>>(result, _attributionTitle, _attributionUrl);

            return Json(container);
        }

        [HttpGet("iexsymbols")]
        public async Task<ActionResult> GetAvailableIexSymbols()
        {
            var symbols = await _refProvider.GetAvailableIexSymbolsAsync();
            var result = symbols.Select(s => s.Symbol).ToList();
            var container = new IexContainer<IReadOnlyList<string>>(result, _attributionTitle, _attributionUrl);

            return Json(container);
        }

        [HttpGet("option/{symbol}")]
        public async Task<ActionResult> GetAvailableExpirations(string symbol)
        {
            var expiries = await _stockProvider.GetAvailableExpirationsAsync(symbol);
            var container = new IexContainer<IReadOnlyList<DateTime>>(expiries, _attributionTitle, _attributionUrl);

            return Json(container);
        }


        [HttpGet("option/{symbol}/{expiration}/{side}")]
        public async Task<ActionResult> GetOption(string symbol, string expiration, string side)
        {
            var expDate = DateTime.ParseExact(expiration, "yyyyMM", CultureInfo.InvariantCulture);

            if (!Enum.TryParse(side, ignoreCase:true, out OptionSide optionSide))
            {
                return Json(new IexContainer<string>("Invalid option side.", _attributionTitle, _attributionUrl));
            }

            var options = await _stockProvider.GetOptionAsync(symbol, expDate, optionSide);
            var container = new IexContainer<IReadOnlyList<Option>>(options, _attributionTitle, _attributionUrl);

            return Json(container);
        }
    }
}