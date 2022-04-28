using ExchangeRate.Models;

namespace ExchangeRate.Services
{
    public interface ICurrencyService
    {
        ExchangeInfo GetExchangeInfo();
    }
}
