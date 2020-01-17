using Havan.CaixaEletronico.Domain;
using Xunit;

namespace Havan.Training_Tests.UnitTests
{
    public class TheoriesTest
    {
        private readonly Caixa caixa = new Caixa();

        [Theory(DisplayName= "Saque contém menor número de cedulas")]
        [InlineData(3,80)]
        [InlineData(3,300)]
        [InlineData(5,500)]
        public void SaqueContemMenorNumeroDeCedulas(int quantidadeDeCedulas,int valorDoSaque)
        {
            var resultadoCedulas = caixa.Saque(valorDoSaque);
            Assert.Equal(quantidadeDeCedulas, resultadoCedulas.Count);
        }
    }
}
