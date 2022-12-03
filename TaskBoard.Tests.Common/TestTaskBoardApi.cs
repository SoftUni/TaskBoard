using Microsoft.AspNetCore.Mvc.Testing;

namespace TaskBoard.Tests.Common
{
    public class TestTaskBoardApi<TEntryPoint> : TestTaskBoardBase<TEntryPoint>
        where TEntryPoint : class
    {
        private WebApplicationFactory<TEntryPoint> factory;

        public TestTaskBoardApi(TestDb testDb)
            : base(testDb)
        {
        }

        public WebApplicationFactory<TEntryPoint> CreateFactory()
        {
            this.factory = new WebApplicationFactory<TEntryPoint>()
                .WithWebHostBuilder(webHostBuilder =>
                    ConfigureServices(webHostBuilder));

            return this.factory;
        }

        public void Dispose() => this.factory.Dispose();
    }
}
