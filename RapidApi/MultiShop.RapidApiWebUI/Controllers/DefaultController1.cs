using Microsoft.AspNetCore.Mvc;
using MultiShop.RapidApiWebUI.Models;
using Newtonsoft.Json;

namespace MultiShop.RapidApiWebUI.Controllers
{
    public class DefaultController1 : Controller
    {
        public async Task<IActionResult> Weather()
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://the-weather-api.p.rapidapi.com/api/weather/izmir"),
                Headers =
                        {
                            { "x-rapidapi-key", "e2ec5e67a2msh1f7ff38dc18f908p1deed9jsn394014e8d2b7" },
                            { "x-rapidapi-host", "the-weather-api.p.rapidapi.com" },
                        },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<WeatherViewModel.Rootobject>(body);
                ViewBag.CityTemp = values.data.temp;
                return View(values);
            }

        }


        public async Task<IActionResult> GetExchange()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=USD&language=EN&to_symbol=TRY"),
                Headers =
                        {
                            { "x-rapidapi-key", "e2ec5e67a2msh1f7ff38dc18f908p1deed9jsn394014e8d2b7" },
                            { "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
                        },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ExchangeViewModel.Rootobject>(body);
                ViewBag.ExchangeRate = values.data.exchange_rate;
                return View(values);
            }
   
        }
    }
}
