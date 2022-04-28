using ExchangeRate.Models;
using Newtonsoft.Json;
using System.Net;

namespace ExchangeRate.Services
{
    public class CurrencyService:ICurrencyService 
    {
        public  ExchangeInfo GetExchangeInfo()
        {
            string Url = "https://www.cbr-xml-daily.ru/daily_json.js";
            HttpWebRequest _request = (HttpWebRequest)WebRequest.Create(Url);
            _request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)_request.GetResponse();
            var stream = response.GetResponseStream();
            Console.WriteLine(stream);
            return JsonConvert.DeserializeObject<ExchangeInfo>(new StreamReader(stream).ReadToEnd());
        }
    }
}
