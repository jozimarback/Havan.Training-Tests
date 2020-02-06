using Havan.CaixaEletronico.Domain;
using System;
using Xunit;

namespace Havan.Training_Tests.UnitTests
{
    public class NormalAssertsTest
    {
        private readonly Caixa caixa = new Caixa();

        [Fact]
        public void SaqueContemMenorNumeroDeCedulas()
        {
            //Arrange
            int quantidadeDeCedulas = 3;
            int valorDoSaque = 80;
            //Act
            var resultadoCedulas = caixa.Saque(valorDoSaque);
            //Assert
            Assert.Equal(quantidadeDeCedulas, resultadoCedulas.Count);
        }

        [Fact]
        public void Saque_Com_Cedulas_Indisponiveis()
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

        [Fact]
        public void DeveGerarExcecao()
        {
            int valorDoSaque = 5;
            Assert.Throws<Exception>(() => caixa.Saque(valorDoSaque));
        }
    }
}
