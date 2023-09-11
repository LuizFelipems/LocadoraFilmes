using Blazored.LocalStorage;
using LocadoraFilmes.Blazor.Constants;
using LocadoraFilmes.Blazor.Models;
using LocadoraFilmes.Blazor.Responses;
using LocadoraFilmes.Blazor.Services.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace LocadoraFilmes.Blazor.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localstorage;

        public SecurityService(HttpClient httpClient, ILocalStorageService localstorage)
        {
            _httpClient = httpClient;
            _localstorage = localstorage;
        }

        public async Task<string?> LoginUser(LoginModel loginModel)
        {
            var response = await _httpClient.PostAsJsonAsync(APIEndpoints.PostLogin, loginModel);
            response.EnsureSuccessStatusCode();
            var jsonResult = await response.Content.ReadAsStringAsync();
            var jsonData = JsonConvert.DeserializeObject<ResponseBase<LoginResponse>>(jsonResult);
            
            Console.WriteLine("Post LoginUser -> ", jsonData?.Data?.Token);

            return jsonData?.Data?.Token;
        }

        public async Task<string> GetTokenUserAsync()
            => await _localstorage.GetItemAsStringAsync("token");
    }
}
