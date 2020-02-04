
using Xunit;

namespace Havan.Training_Tests.UnitTests
{
    public class SkipTest
    {
        [Fact(DisplayName = "Número de cedula confere",Skip ="Teste defasado, não mais necessário")]
        public void NumeroCedulaConfere()
        {
            Assert.Equal(CaixaEletronico.Domain.Cedula.Cem, 100);
        }
    }
}
