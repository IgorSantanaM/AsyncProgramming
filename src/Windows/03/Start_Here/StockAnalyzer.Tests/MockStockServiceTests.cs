using StockAnalyzer.Core.Services;

namespace StockAnalyzer.Tests
{
    public class MockStockServiceTests
    {
        [Fact]
        public async Task GetStockPricesFor_ShouldReturnAllMSFT_WhenQueryIsPassed()
        {
            var service = new MockStockService();

            var stocks = await service.GetStockPricesFor("MSFT", CancellationToken.None);

            Assert.Equal(3, stocks.Count());    
        }
    }
}
