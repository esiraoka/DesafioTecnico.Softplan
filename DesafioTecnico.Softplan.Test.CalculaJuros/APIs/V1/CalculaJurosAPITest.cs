using DesafioTecnico.Softplan.API.CalculaJuros;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DesafioTecnico.Softplan.Test.CalculaJuros.APIs.V1
{
    public class CalculaJurosAPITest
    {
        private readonly HttpClient _Client;
        private const string ROTA_PADRAO_CALCULA_JUROS_API = "/api/v1/calculajuros/calcularJuros";

        public CalculaJurosAPITest()
        {
            var server = new TestServer(new WebHostBuilder()
                                        .UseEnvironment("Development")
                                        .UseStartup<Startup>());
            _Client = server.CreateClient();
        }

        [Theory]
        [InlineData("GET", 100, 5)]
        public async Task CalculaJurosController_CalcularJuros_RetornarValorCalculadoComJurosCompostos(string tipoRequisicaoHttp,
                                                                                                      decimal valorInicial,
                                                                                                      int meses)
        {
            //Arrange
            var request = new HttpRequestMessage(new HttpMethod(tipoRequisicaoHttp), $"{ROTA_PADRAO_CALCULA_JUROS_API}/{valorInicial}/{meses}");

            //Act
            var response = await _Client.SendAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("GET", 100)]
        public async Task CalculaJurosController_CalcularJuros_FaltandoParametrosNaRota(string tipoRequisicaoHttp,
                                                                                        decimal valorInicial)
        {
            //Arrange
            var request = new HttpRequestMessage(new HttpMethod(tipoRequisicaoHttp), $"{ROTA_PADRAO_CALCULA_JUROS_API}/{valorInicial}");

            //Act
            var response = await _Client.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Theory]
        [InlineData("GET", 100, 0)]
        public async Task CalculaJurosController_CalcularJuros_ParametroMesesForaDoIntervaloEsperado(string tipoRequisicaoHttp,
                                                                                                     decimal valorInicial,
                                                                                                     int meses)
        {
            //Arrange
            var request = new HttpRequestMessage(new HttpMethod(tipoRequisicaoHttp), $"{ROTA_PADRAO_CALCULA_JUROS_API}/{valorInicial}/{meses}");

            //Act
            var response = await _Client.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
