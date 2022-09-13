using System.Net.Http.Json;

namespace TaskQulix.Services
{
    public class CurrencyService
    {
        List<Currency> _currencyList = new ();
        HttpClient _httpClient;

        public CurrencyService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Currency>> GetCurrency()
        {
            if (_currencyList?.Count > 0)
                return _currencyList;

            var utl = "https://www.nbrb.by/api/exrates/rates?periodicity=0&ondate=$Date";
            
            var responce = await _httpClient.GetAsync(utl);

            if(responce.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _currencyList = await responce.Content.ReadFromJsonAsync<List<Currency>>();
            }    

            return _currencyList;
        }
    }
}
