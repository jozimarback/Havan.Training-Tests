using Havan.CaixaEletronico.Api;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Havan.Training_Tests.IntegrationTests
{
    [Collection(nameof(IntegrationApiTestFixtureCollection))]
    public class SkipTest
    {
        private readonly IntegrationTestFixture<StartupApiTests> _integrationTestFixture;

        public SkipTest(IntegrationTestFixture<StartupApiTests> integrationTestFixture)
        {
            _integrationTestFixture = integrationTestFixture;

        }

        [Fact(DisplayName = "Saque com sucesso", Skip = "Teste defasado, não mais necessário")]
        public async Task Saque_com_sucesso()
        {
            var requisicao = await _integrationTestFixture.Client.PostAsJsonAsync($"/api/CaixaEletronico/saque/100", new { });
            var resposta = await requisicao.Content.ReadAsStringAsync();

            Assert.True(requisicao.IsSuccessStatusCode);
        }
    }
}
