using Havan.CaixaEletronico.Api;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Havan.Training_Tests.IntegrationTests
{
    [Collection(nameof(IntegrationApiTestFixtureCollection))]
    public class FixturesTest
    {
        private readonly IntegrationTestFixture<StartupApiTests> _integrationTestFixture;
        public FixturesTest(IntegrationTestFixture<StartupApiTests> integrationTestFixture)
        {
            _integrationTestFixture = integrationTestFixture;
        }

        [Theory(DisplayName = "Efetua Saque via api")]
        [InlineData(80)]
        [InlineData(300)]
        [InlineData(500)]
        public async Task Efetua_Saque_Via_Api(int valorSaque)
        {
            var requisicao = await _integrationTestFixture.Client.PostAsJsonAsync($"/api/CaixaEletronico/saque/{valorSaque}",new { });
            var resposta = await requisicao.Content.ReadAsStringAsync();
            
            Assert.True(requisicao.IsSuccessStatusCode);
            Assert.Contains("Receba seu saque",resposta);
        }

        [Theory(DisplayName = "NÂO Efetua Saque via api")]
        [InlineData(5)]
        [InlineData(15)]
        [InlineData(38)]
        public async Task Nao_Efetua_Saque_Via_Api(int valorSaque)
        {
            var requisicao = await _integrationTestFixture.Client.PostAsJsonAsync($"/api/CaixaEletronico/saque/{valorSaque}", new { });
            var resposta = await requisicao.Content.ReadAsStringAsync();

            Assert.False(requisicao.IsSuccessStatusCode);
            Assert.Contains("Valor não válido para saque", resposta);
            Assert.Equal(HttpStatusCode.BadRequest, requisicao.StatusCode);
        }
    }
}
