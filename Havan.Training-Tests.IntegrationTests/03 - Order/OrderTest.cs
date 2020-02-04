using System;
using Xunit;
using Xunit.Abstractions;

namespace Havan.Training_Tests.IntegrationTests
{
    [Collection(nameof(IntegrationApiTestFixtureCollection))]
    public class OrderTest
    {
        private readonly ITestOutputHelper output;
        public OrderTest(ITestOutputHelper outputHelper)
        {
            output = outputHelper;
        }
        [Fact(DisplayName = "Segundo teste a ser executado"), TestPriority(2)]
        public void Segundo_Teste()
        {
            var data = DateTime.Now;
            output.WriteLine("Segundo teste foi executado {0:hh:mm:ss.fff tt}", data);
            Assert.True(true);
        }

        [Fact(DisplayName = "Terceiro teste a ser executado"), TestPriority(3)]
        public void Terceiro_Teste()
        {
            var data = DateTime.Now;
            output.WriteLine("Terceiro teste foi executado {0:hh:mm:ss.fff tt}", data);
            Assert.True(true);
        }



        [Fact(DisplayName = "Primeiro teste a ser executado"), TestPriority(1)]
        public void Primeiro_Teste()
        {
            var data = DateTime.Now;
            output.WriteLine("Primeiro teste foi executado {0:hh:mm:ss.fff tt}", data);
            Assert.True(true);
        }
        
        
    }
}
