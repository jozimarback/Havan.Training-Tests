using Havan.CaixaEletronico.Domain;
using Moq;
using NSubstitute;
using Xunit;

namespace Havan.Training_Tests.UnitTests
{
    public class MoqTests
    {
        [Fact(DisplayName ="Saque sem retorno cedulas NSubstitute")]
        public void SaqueContemNenhumaCedulasNSUb()
        {
            var caixa = Substitute.For<ICaixa>();
            int valorDoSaque = 50;
            caixa.Saque(valorDoSaque).Returns(new int[] { });
            caixa.Received(1);
        }

        [Fact(DisplayName = "Saque sem retorno cedulas Moq")]
        public void SaqueContemNenhumaCedulasMoq()
        {
            var caixa = new Mock<ICaixa>();
            int valorDoSaque = 50;
            caixa.Object.Saque(valorDoSaque);
            caixa.Verify(r => r.Saque(valorDoSaque),Times.Once);
        }
    }
}
