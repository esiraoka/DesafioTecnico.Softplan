using DesafioTecnico.Softplan.Domain.CalculaJuros.Classes;
using DesafioTecnico.Softplan.Domain.CalculaJuros.Interfaces;
using System.Threading.Tasks;
using Xunit;

namespace DesafioTecnico.Softplan.TestUnidade.CalculaJuros.Services
{
    public class CalculaJurosServiceTest
    {
        private readonly ICalculaJurosService _CalculaJurosService;
       

        public CalculaJurosServiceTest()
        {
            _CalculaJurosService = new CalculaJurosService();
        }

        [Fact]
        public async Task CalculaJurosService_CalcularJuros_CalculaJurosComSucesso()
        {
            //Arrange
            const decimal VALOR_INICIAL = 100.00m;
            const int MESES = 5;
            const decimal TAXA_JUROS = 0.01m;
            const decimal VALOR_FINAL = 105.10m;

            //Act
            var valorCalculadoJurosCompostos = await _CalculaJurosService.CalcularJuros(TAXA_JUROS, VALOR_INICIAL, MESES);

            //Assert
            Assert.Equal(VALOR_FINAL, valorCalculadoJurosCompostos);
        }

        [Theory]
        [InlineData(150.00, 3, 0.05, 173.64)]
        [InlineData(200.00, 2, 0.10, 242.00)]
        [InlineData(155.60, 6, 0.07, 233.51)]
        [InlineData(215.00, 8, 0.09, 428.40)]
        [InlineData(100.00, 1, 0.05, 105.00)]
        public async Task CalculaJurosService_CalcularJuros_CalculaJurosComSucessoMultiplosValoresMeses(decimal valorInicial,
                                                                                                        int meses,
                                                                                                        decimal taxaJuros,
                                                                                                        decimal resultadoEsperado)
        {
            //Act
            var valorCalculadoJurosCompostos = await _CalculaJurosService.CalcularJuros(taxaJuros, valorInicial, meses);

            //Assert
            Assert.Equal(resultadoEsperado, valorCalculadoJurosCompostos);
        }
    }
}
