using Newtonsoft.Json.Linq;

namespace HandsOnTests.Client
{
    public class ProdutoClient
    {
        public async Task<JObject> ObterProduto(string baseUrl, int produtoId, HttpClient? httpClient = null)
        {
            using var client = httpClient == null ? new HttpClient() : httpClient;

            var response = await client.GetAsync(baseUrl + "/api/products/" + produtoId);

            var jsonObtido = await response.Content.ReadAsStringAsync();
            var jsonResultado = JObject.Parse(jsonObtido!);

            return jsonResultado;
        }
    }
}
