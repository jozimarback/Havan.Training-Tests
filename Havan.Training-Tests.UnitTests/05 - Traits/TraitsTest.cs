using Havan.CaixaEletronico.Domain;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Havan.Training_Tests.UnitTests
{
    public class TraitsTest : IClassFixture<IntegrationTestFixture>
    {
        private ICaixa _caixa;
        public TraitsTest(IntegrationTestFixture fixture)
        {
            _caixa = fixture.ServiceProvider.GetRequiredService<ICaixa>();
        }
        [Fact]
        [Trait("Categoria","Saque")]
        public void SaqueContemMenorNumeroDeCedulas()
        {
            //Arrange
            int quantidadeDeCedulas = 3;
            int valorDoSaque = 80;
            //Act
            var resultadoCedulas = _caixa.Saque(valorDoSaque);
            //Assert
            Assert.Equal(quantidadeDeCedulas, resultadoCedulas.Count);
        }
    }
}
