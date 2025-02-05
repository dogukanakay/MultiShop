﻿
namespace MultiShop.WebUI.Services.StatisticServices.UserStatisticServices
{
    public class UserStatisticService : IUserStatisticService
    {
        private readonly HttpClient _httpClient;

        public UserStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetUserCount()
        {
            var responseMessage = await _httpClient.GetAsync("statistics/GetUserCount");
            var userCount = await responseMessage.Content.ReadFromJsonAsync<int>();
            return userCount;
        }
    }
}
