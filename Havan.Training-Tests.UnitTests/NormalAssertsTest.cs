using Havan.CaixaEletronico.Domain;
using Xunit;

namespace Havan.Training_Tests.UnitTests
{
    public class NormalAssertsTest
    {
        private readonly Caixa caixa = new Caixa();

        [Fact]
        public void SaqueContemMenorNumeroDeCedulas()
        {
            int quantidadeDeCedulas = 3;
            int valorDoSaque = 80;

            var resultadoCedulas = caixa.Saque(valorDoSaque);

            Assert.Equal(quantidadeDeCedulas, resultadoCedulas.Count);
        }

        [Fact]
        public void SaqueComCedulasIndisponiveis()
        {
            int valorDoSaque = 45;

            bool saqueEhValido = caixa.ValidaCedulasDisponiveis(valorDoSaque);

            Assert.False(saqueEhValido);
        }

        [Fact]
        public void SaqueValido()
        {
            int valorDoSaque = 510;

            bool saqueEhValido = caixa.ValidaCedulasDisponiveis(valorDoSaque);

            Assert.True(saqueEhValido);
        }
    }
}
