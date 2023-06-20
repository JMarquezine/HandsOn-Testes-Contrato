using HandsOn;
using HandsOnTests.Client;
using HandsOnTests.Utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json.Schema;

namespace HandsOnTests;

public class ProdutoTest : IDisposable
{
    private readonly IWebHost _webHost;
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public ProdutoTest()
    {
        // Inicializar o servidor real da aplicação
        _webHost = new TestServer(new WebHostBuilder().UseStartup<Startup>()).Host;
        _httpClient = _webHost.GetTestClient();
        _baseUrl = "http://localhost";
    }

    [Fact]
    public async Task ObterProduto_QuandoSolicitadoExistente_RetornaProdutoAsync()
    {
        // Arrange
        var jsonSchema = SchemaUtils.ObterSchemaAsync("produto");
        var produtoClient = new ProdutoClient();

        // Act
        // Fazer chamadas reais para a API para obter os resultados
        var response = await produtoClient.ObterProduto(_baseUrl, 1, _httpClient);

        // Assert 
        // Valida se o retorno está válido de acordo com o schema
        Assert.True(response.IsValid(jsonSchema));
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        // Encerrar o servidor real da aplicação
        _webHost?.Dispose();
    }
}