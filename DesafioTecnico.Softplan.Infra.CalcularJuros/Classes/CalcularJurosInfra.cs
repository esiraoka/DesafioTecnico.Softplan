using DesafioTecnico.Softplan.Infra.CalcularJuros.Interfaces;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace DesafioTecnico.Softplan.Infra.CalcularJuros.Classes
{
    public class CalcularJurosInfra : ICalcularJurosInfra
    {
        private readonly IHttpClientFactory _ClientFactory;
        private const string ENDERECO_API_JUROS = "/api/v1/juros/taxaJuros";

        public CalcularJurosInfra(IHttpClientFactory clientFactory)
        {
            _ClientFactory = clientFactory;
        }

        public async Task<decimal> BuscarJuros()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, ENDERECO_API_JUROS);
            var client = _ClientFactory.CreateClient("buscarJuros");
            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
                throw new SystemException("Erro inesperado ao recuperar o juros da API de cadastro.");

            string juros = await response.Content.ReadAsStringAsync();
            return await Task.FromResult(Convert.ToDecimal(juros, new NumberFormatInfo() { NumberDecimalSeparator = "." }));
        }
    }
}
