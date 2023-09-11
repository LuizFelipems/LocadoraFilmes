namespace LocadoraFilmes.Blazor.Constants
{
    public static class APIEndpoints
    {
        //private const string ServerBaseUrl = "https://localhost:5225";
        private const string ServerBaseUrl = "https://locadorafilmes-api.azurewebsites.net";

        internal const string PostLogin = $"{ServerBaseUrl}/v1/login";


        internal const string PostCreateFilme = $"{ServerBaseUrl}/v1/filme";
        internal static string PutUpdateFilme(Guid id) => $"{ServerBaseUrl}/v1/filme/{id}";
        internal const string GetAllFilmes = $"{ServerBaseUrl}/v1/filmes";
        internal static string GetByIdFilme(Guid id) => $"{ServerBaseUrl}/v1/filme/{id}";
        internal static string DeleteFilme(Guid id) => $"{ServerBaseUrl}/v1/filme/{id}";
        internal const string DeleteFilmes = $"{ServerBaseUrl}/v1/filmes";

        internal const string PutLocarFilmes = $"{ServerBaseUrl}/v1/locar";
        internal const string GetAllLocacoes = $"{ServerBaseUrl}/v1/locacoes";


    }
}
