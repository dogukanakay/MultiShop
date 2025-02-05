﻿using MultiShop.DtoLayer.CatalogDtos.AboutDtos;

namespace MultiShop.WebUI.Services.CatalogServices.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly HttpClient _httpClient;

        public AboutService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateAboutDto>("abouts", createAboutDto);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> DeleteAboutAsync(string id)
        {
            var responseMessage = await _httpClient.DeleteAsync("abouts?id=" + id);
            return responseMessage;
        }



        public async Task<List<ResultAboutDto>> GetAllAboutsAsync()
        {
            var responseMessage = await _httpClient.GetAsync("abouts");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultAboutDto>>();
            return values;
        }

        public async Task<GetByIdAboutDto> GetByIdAboutAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("abouts/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdAboutDto>();
            return values;
        }

        public async Task<UpdateAboutDto> GetByIdAboutToUpdateAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("abouts/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateAboutDto>();
            return values;
        }

        public async Task<HttpResponseMessage> UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync<UpdateAboutDto>("abouts", updateAboutDto);
            return responseMessage;
        }
    }
}
