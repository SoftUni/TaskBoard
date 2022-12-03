using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using NUnit.Framework;

using TaskBoard.Data;
using TaskBoard.Tests.Common;
using TaskBoard.WebAPI.Models.Response;
using TaskBoard.WebAPI.Models.User;

namespace TaskBoard.WebAPI.IntegrationTests
{
    public class ApiTestsBase
    {
        protected TestDb testDb;
        protected ApplicationDbContext dbContext;
        protected TestTaskBoardApi<Program> testTaskBoardApi;
        protected HttpClient httpClient;

        [OneTimeSetUp]
        public void OneTimeSetUpBase()
        {
            this.testDb = new TestDb();
            this.dbContext = this.testDb.CreateDbContext();
            this.testTaskBoardApi = new TestTaskBoardApi<Program>(this.testDb);
            this.httpClient = this.testTaskBoardApi.CreateFactory().CreateClient();
        }

        public async System.Threading.Tasks.Task AuthenticateAsync()
        {
            this.httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", await this.GetJWTAsync());
        }

        private async Task<string> GetJWTAsync()
        {
            var userMaria = this.testDb.UserMaria;
            var response = await this.httpClient.PostAsJsonAsync("api/users/login",
                new LoginModel
                {
                    Username = userMaria.UserName,
                    Password = userMaria.UserName
                });

            var loginResponse = await response.Content.ReadAsAsync<ResponseWithToken>();

            return loginResponse.Token;
        }

        [OneTimeTearDown]
        public void OneTimeTearDownBase()
        {
            // Stop and dispose the local Web API server
            this.testTaskBoardApi.Dispose();
        }
    }
}
