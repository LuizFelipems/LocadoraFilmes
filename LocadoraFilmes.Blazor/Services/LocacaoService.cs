using LocadoraFilmes.Blazor.Constants;
using LocadoraFilmes.Blazor.Models;
using LocadoraFilmes.Blazor.Responses;
using LocadoraFilmes.Blazor.Services.Interfaces;
using System.Net.Http.Json;

namespace LocadoraFilmes.Blazor.Services
{
    public class LocacaoService : ILocacaoService
    {
        private readonly HttpClient _httpClient;
        private readonly ISecurityService _securityService;

        public LocacaoService(HttpClient httpClient, ISecurityService securityService)
        {
            _httpClient = httpClient;
            _securityService = securityService;
        }
        public async Task<ResponseBase<LocacaoResponse>> LocarFilmes(LocarFilmeModel updateFilme)
        {
            var token = await _securityService.GetTokenUserAsync();
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            var response = await _httpClient.PutAsJsonAsync(APIEndpoints.PutLocarFilmes, updateFilme);

            var jsonResult = await response.Content.ReadFromJsonAsync<ResponseBase<LocacaoResponse>>()
                ?? new ResponseBase<LocacaoResponse>();

            //var jsonResult = await response.Content.ReadAsStringAsync();
            //var jsonData = JsonConvert.DeserializeObject<ResponseBase<FilmeResponse>>(jsonResult);

            return jsonResult;
        }

        public async Task<ResponseBase<List<LocacaoResponse>>> GetAllLocacoes()
        {
            var token = await _securityService.GetTokenUserAsync();
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            var response = await _httpClient.GetFromJsonAsync<ResponseBase<List<LocacaoResponse>>>(APIEndpoints.GetAllLocacoes);
            //var jsonResult = await response.Content.ReadAsStringAsync();
            //var jsonData = JsonConvert.DeserializeObject<ResponseBase<FilmeResponse>>(jsonResult);
            return response;
        }
    }
}
