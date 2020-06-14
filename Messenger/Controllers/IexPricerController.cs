using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Messenger.Entities.IexPricer;
using Messenger.Infrastructure.Configuration.Options.Pricers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Pricer.IexCloudProvider;

namespace Messenger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IexPricerController : Controller
    {
        private readonly IIexProvider _iexProvider;
        private readonly string _attributionTitle;
        private readonly string _attributionUrl;

        public IexPricerController(IIexProvider iexProvider, IOptions<IexPricerOptions> options)
        {
            _iexProvider = iexProvider;
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
    }
}