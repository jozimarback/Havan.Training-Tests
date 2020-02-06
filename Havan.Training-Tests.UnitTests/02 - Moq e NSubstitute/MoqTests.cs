using Havan.CaixaEletronico.Domain;
using Moq;
using NSubstitute;
using Xunit;

namespace Havan.Training_Tests.UnitTests
{
    public class MoqTests
    {
        [Fact(DisplayName ="Mock saque con sucesso NSubstitute")]
        public void Saque_Com_Sucesso_NSUb()
        {
            var caixa = Substitute.For<ICaixa>();
            int valorDoSaque = 50;
            caixa.Saque(valorDoSaque).Returns(new int[] { });
            caixa.Received(1);
        }

        [Fact(DisplayName = "Mock saque com sucesso Moq")]
        public void Saque_Com_Sucesso_Moq()
        {
            var caixa = new Mock<ICaixa>();
            int valorDoSaque = 50;
            caixa.Object.Saque(valorDoSaque);
            caixa.Verify(r => r.Saque(valorDoSaque),Times.Once);
        }
    }
}