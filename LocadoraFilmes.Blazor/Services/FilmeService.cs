using LocadoraFilmes.Blazor.Constants;
using LocadoraFilmes.Blazor.Models;
using LocadoraFilmes.Blazor.Responses;
using LocadoraFilmes.Blazor.Services.Interfaces;
using System.Net.Http.Json;

namespace LocadoraFilmes.Blazor.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly HttpClient _httpClient;
        private readonly ISecurityService _securityService;

        public FilmeService(HttpClient httpClient, ISecurityService securityService)
        {
            _httpClient = httpClient;
            _securityService = securityService;
        }

        public async Task<ResponseBase<FilmeResponse>> CreateFilme(CreateFilmeModel createFilme)
        {
            var token = await _securityService.GetTokenUserAsync();
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            var response = await _httpClient.PostAsJsonAsync(APIEndpoints.PostCreateFilme, createFilme);

            var jsonResult = await response.Content.ReadFromJsonAsync<ResponseBase<FilmeResponse>>()
                ?? new ResponseBase<FilmeResponse>();

            return jsonResult;
        }

        public async Task<ResponseBase<FilmeResponse>> UpdateFilme(Guid id, UpdateFilmeModel updateFilme)
        {
            var token = await _securityService.GetTokenUserAsync();
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            var response = await _httpClient.PutAsJsonAsync(APIEndpoints.PutUpdateFilme(id), updateFilme);

            var jsonResult = await response.Content.ReadFromJsonAsync<ResponseBase<FilmeResponse>>() 
                ?? new ResponseBase<FilmeResponse>();

            return jsonResult;
        }

        public async Task<ResponseBase<List<FilmeResponse>>> GetAllFilmes()
        {
            var token = await _securityService.GetTokenUserAsync();
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            Console.WriteLine("GetAllFilmes-> ", token);
            var response = await _httpClient.GetFromJsonAsync<ResponseBase<List<FilmeResponse>>>(APIEndpoints.GetAllFilmes)
                    ?? new ResponseBase<List<FilmeResponse>>();
            
            return response;
        }
        
        public async Task<ResponseBase<FilmeResponse>> GetByIdFilme(Guid id)
        {
            var token = await _securityService.GetTokenUserAsync();
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            var response = await _httpClient.GetFromJsonAsync<ResponseBase<FilmeResponse>>(APIEndpoints.GetByIdFilme(id));
            
            return response;
        }

        public async Task<ResponseBase<DeleteFilmeResponse>> DeleteFilme(Guid id)
        {
            var token = await _securityService.GetTokenUserAsync();
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            var response = await _httpClient.DeleteAsync(APIEndpoints.DeleteFilme(id));

            var jsonResult = await response.Content.ReadFromJsonAsync<ResponseBase<DeleteFilmeResponse>>()
                ?? new ResponseBase<DeleteFilmeResponse>();
            
            return jsonResult;
        }

        public async Task<ResponseBase<DeleteFilmeResponse>> DeleteFilmes(Guid id)
        {
            var token = await _securityService.GetTokenUserAsync();
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            var response = await _httpClient.DeleteAsync(APIEndpoints.DeleteFilme(id));

            var jsonResult = await response.Content.ReadFromJsonAsync<ResponseBase<DeleteFilmeResponse>>()
                ?? new ResponseBase<DeleteFilmeResponse>();

            return jsonResult;
        }

        public List<GeneroModel> GetAllGeneros()
            => new List<GeneroModel>()
            {
                new GeneroModel { Id = Guid.Parse("d9b1e988-7366-41e5-a845-3fef66acf0b2"), Nome = "Ação" },
                new GeneroModel { Id = Guid.Parse("4e378b57-3f46-4552-8442-4dc4ff06bfb2"), Nome = "Aventura" },
                new GeneroModel { Id = Guid.Parse("fcb9988e-a87f-42e2-a7ea-f8b37dc4e65a"), Nome = "Drama" },
                new GeneroModel { Id = Guid.Parse("8514a6c6-c958-4dd7-950b-ce058b921225"), Nome = "Comédia" },
                new GeneroModel { Id = Guid.Parse("64437865-abc3-4566-a7c0-a6d8a38fdf1d"), Nome = "Terror" }
            };
    }
}
