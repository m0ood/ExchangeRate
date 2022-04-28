# ExchangeRate
A web service using ASP.Net Core, based on daily data on exchange rates of the Central Bank (https://www.cbr-xml-daily.ru/daily_json.js), which implements 2 API methods:
GET /currencies - returns a list of currency rates with the possibility of pagination
GET /currency/ - returns exchange rate for the passed currency identifier
