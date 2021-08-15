using DesafioTecnico.Softplan.API.Juros;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DesafioTecnico.Softplan.Test.Juros.APIs.V1
{
    public class JurosControllerAPITest
    {
        private readonly HttpClient _Client;
        private const string ROTA_PADRAO_JUROS_API = "/api/v1/juros/taxajuros";

        public JurosControllerAPITest()
        {
            var server = new TestServer(new WebHostBuilder()
                                        .UseEnvironment("Development")
                                        .UseStartup<StartupTest>());
            _Client = server.CreateClient();
        }

        #region Metodo: CadastarJuros

        [Theory]
        [InlineData(100)]
        public async Task JurosController_CadastrarJuros_RetornarCodigoSucesso(decimal taxaJuros)
        {
            //Arrange
            StringContent httpContent = new StringContent(taxaJuros.ToString(), System.Text.Encoding.UTF8, "application/json");

            //Act
            var response = await _Client.PostAsync(ROTA_PADRAO_JUROS_API, httpContent);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData(0)]
        public async Task JurosController_CadastrarJuros_ForaDoIntervaloEsperado(decimal taxaJuros)
        {
            //Arrange
            StringContent httpContent = new StringContent(taxaJuros.ToString(), System.Text.Encoding.UTF8, "application/json");

            //Act
            var response = await _Client.PostAsync(ROTA_PADRAO_JUROS_API, httpContent);

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        #endregion

        #region BuscarUltimoJurosCadastrado

        [Theory]
        [InlineData("GET")]
        public async Task JurosController_BuscarUltimoJurosCadastrado_RetornarUltimoJurosCadastradoComSucesso(string tipoRequisicaoHttp)
        {
            //Arrange
            var request = new HttpRequestMessage(new HttpMethod(tipoRequisicaoHttp), $"{ROTA_PADRAO_JUROS_API}");

            //Act
            var response = await _Client.SendAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("PUT")]
        public async Task JurosController_BuscarUltimoJurosCadastrado_VerboHttpInexistente(string tipoRequisicaoHttp)
        {
            //Arrange
            var request = new HttpRequestMessage(new HttpMethod(tipoRequisicaoHttp), $"{ROTA_PADRAO_JUROS_API}");

            //Act
            var response = await _Client.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.MethodNotAllowed, response.StatusCode);
        }

        #endregion
    }
}
