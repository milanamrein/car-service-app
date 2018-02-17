using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Admin.Infrastructure.Services
{
    /// <summary>
    /// Base Persistence Service
    /// </summary>
    public class CarServicePersistence : ICarServicePersistence
    {
        private HttpClient _httpClient;

        public CarServicePersistence()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:53175/api/");
        }

        public HttpClient Client => _httpClient;

        public async Task<T> GetAsync<T>(string url, string argToken = "")
        {
            if(!argToken.Equals(string.Empty))
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", argToken);
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsAsync<string>());

            return await response.Content.ReadAsAsync<T>();
        }

        public async Task<TResult> CreateAsync<TDTO, TResult>(string url, TDTO dTO, string argToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", argToken);
            HttpResponseMessage response =
                await _httpClient.PostAsJsonAsync<TDTO>(url, dTO);
            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsAsync<string>());

            return await response.Content.ReadAsAsync<TResult>();
        }

        public async Task<bool> UpdateAsync<TDTO>(string url, object argId, TDTO dTO, string argToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", argToken);
            HttpResponseMessage response =
                await _httpClient.PutAsJsonAsync<TDTO>($"{url}{argId}", dTO);
            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsAsync<string>());

            return true;
        }

        public async Task<T> DeleteAsync<T>(string url, object argId, string argToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", argToken);
            HttpResponseMessage response = await _httpClient.DeleteAsync($"{url}{argId}");
            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsAsync<string>());

            return await response.Content.ReadAsAsync<T>();
        }
    }
}
