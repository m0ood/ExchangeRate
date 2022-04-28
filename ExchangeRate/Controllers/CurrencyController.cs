using ExchangeRate.Models;
using Microsoft.AspNetCore.Mvc;
using ExchangeRate.Services;

namespace ExchangeRate.Controllers
{   
    [Route("")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {

        private readonly ICurrencyService _currencyService;
        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }
        // GET /Currencies?PageNumber=1&PageSize=5
        [HttpGet("Currencies")]
        public List<KeyValuePair<String,Currency>> Currencies([FromQuery] OwnerParameters ownerParameters)
        {
            return _currencyService.GetExchangeInfo().Valute
                .Skip((ownerParameters.PageNumber-1)*ownerParameters.PageSize)
                .Take(ownerParameters.PageSize)
                .ToList();
        }
        // GET /Currency?identifier=AUD
        [HttpGet("Currency")]
        public Dictionary<string, Currency> Currency(string identifier)
        {
            ExchangeInfo exchangeInfo = _currencyService.GetExchangeInfo();
            Dictionary<string, Currency> result = new Dictionary<string, Currency>();
            try
            {
                result.Add(identifier, exchangeInfo.Valute[identifier]);
                return result;
            }
            catch (KeyNotFoundException)
            {
                return result;
            }
        }
    }
}
