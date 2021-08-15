using DesafioTecnico.Softplan.Application.Interfaces;
using DesafioTecnico.Softplan.Domain.Classes;
using DesafioTecnico.Softplan.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnico.Softplan.Application.Classes
{
    public class JurosApplication : IJurosApplication
    {
        private readonly IJurosRepository _JurosRepository;
        private const int DIVISOR_PORCENTAGEM = 100;

        public JurosApplication(IJurosRepository jurosRepository)
        {
            _JurosRepository = jurosRepository;
        }

        public async Task Inserir(decimal juros)
        {
            Juros jurosEntity = new Juros()
            {
                Porcentagem = juros,
                DataCadastro = DateTime.Now
            };
            await _JurosRepository.Inserir(jurosEntity);
        }

        public async Task<decimal> ListarValorUltimoJuros()
        {
            Juros juros = await _JurosRepository.BuscarUltimoJuros();
            return juros?.Porcentagem / DIVISOR_PORCENTAGEM ?? decimal.Zero;
        }
    }
}
