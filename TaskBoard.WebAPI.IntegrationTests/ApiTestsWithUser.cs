using System;
using System.Text;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using TaskBoard.WebAPI.Models.Task;
using TaskBoard.WebAPI.Models.Response;

using NUnit.Framework;
using Newtonsoft.Json;

namespace TaskBoard.WebAPI.IntegrationTests
{
    public class ApiTestsWithUser : ApiTestsBase
    {
        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            await base.AuthenticateAsync();
        }

        [Test]
        public async Task Test_Tasks_GetTaskById_ValidId()
        {
        }

        [Test]
        public async Task Test_Tasks_CreateTask_ValidData()
        {
        }

        [Test]
        public async Task Test_Tasks_EditTask_ValidId()
        {
        }

        [Test]
        public async Task Test_Tasks_EditTask_InvalidId()
        {
        }

        [Test]
        public async Task Test_Tasks_PartialEditTask_ValidId()
        {
        }

        [Test]
        public async Task Test_Tasks_DeleteTask_ValidId()
        {
        }
    }
}
