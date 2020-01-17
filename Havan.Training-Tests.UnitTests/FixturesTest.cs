using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Havan.Training_Tests.UnitTests
{
    public class FixturesTest : IClassFixture<IntegrationTestFixture>
    {
        private ServiceProvider _serviceProvide;
        public FixturesTest(IntegrationTestFixture fixture)
        {
            _serviceProvide = fixture.ServiceProvider;
        }
    }
}
