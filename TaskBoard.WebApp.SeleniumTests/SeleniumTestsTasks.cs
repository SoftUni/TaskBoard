using System;

using NUnit.Framework;
using OpenQA.Selenium;

namespace TaskBoard.WebApp.SeleniumTests
{
    public class SeleniumTestsTasks : SeleniumTestsBase
    {
        [OneTimeSetUp]
        public void SetupUser()
        {
            this.RegisterUserForTesting();
        }   

        [Test]
        public void Test_CreateTask_ValidData()
        {
        }

        [Test]
        public void Test_CreateTask_InvalidData()
        {
        }

        [Test]
        public void Test_DeleteTask()
        {
        }

        [Test]
        public void Test_EditTask_ValidData()
        {
        }

        private void RegisterUserForTesting()
        {
        }

        private void CreateTask(out string taskTitle, out string taskDescription)
        {
        }
    }
}
