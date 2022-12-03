using System.Linq;

using TaskBoard.Data;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace TaskBoard.Tests.Common
{
    public class TestTaskBoardBase<TEntryPoint> : WebApplicationFactory<TEntryPoint>
        where TEntryPoint : class
    {
        protected TestDb TestDb { get; set; }

        protected TestTaskBoardBase(TestDb testDb) 
            => this.TestDb = testDb;

        protected IWebHostBuilder ConfigureServices(IWebHostBuilder webHostBuilder)
            => webHostBuilder.ConfigureServices(services =>
            {
                ServiceDescriptor? oldDbContext = services.SingleOrDefault(
                        descr => descr.ServiceType == typeof(ApplicationDbContext));
                services.Remove(oldDbContext);
                services.AddScoped<ApplicationDbContext>(
                    provider => this.TestDb.CreateDbContext());
            });
    }
}
