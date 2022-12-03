using System;

using TaskBoard.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TaskBoard.Tests.Common
{
    public class TestDb
    {
        private string uniqueDbName;

        public TestDb()
        {
            this.uniqueDbName = "TaskBoard-TestDb-" + DateTime.Now.Ticks;
            this.SeedDatabase();
        }

        public ApplicationDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase(this.uniqueDbName);
            return new ApplicationDbContext(optionsBuilder.Options, false);
        }

        public Board OpenBoard { get; private set; }

        public Board InProgressBoard { get; private set; }

        public Board DoneBoard { get; private set; }

        public User GuestUser { get; private set; }

        public Task CSSTask { get; private set; }

        public User UserMaria { get; private set; }

        public Task EditTask { get; private set; }

        private void SeedDatabase()
        {
            var dbContext = this.CreateDbContext();
            var userStore = new UserStore<User>(dbContext);
            var hasher = new PasswordHasher<User>();
            var normalizer = new UpperInvariantLookupNormalizer();
            var userManager = new UserManager<User>(
                userStore, null, hasher, null, null, normalizer, null, null, null);

            // Create boards: "Open", "In Progress", "Done"
            this.OpenBoard = new Board()
            {
                Id = 1,
                Name = "Open"
            };
            dbContext.Add(this.OpenBoard);

            this.InProgressBoard = new Board()
            {
                Id = 2,
                Name = "In Progress"
            };
            dbContext.Add(this.InProgressBoard);

            this.DoneBoard = new Board()
            {
                Id = 3,
                Name = "Done"
            };
            dbContext.Add(this.DoneBoard);

            // Create GuestUser
            this.GuestUser = new User()
            {
                UserName = "guest",
                NormalizedUserName = "guest",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com",
                FirstName = "Guest",
                LastName = "User",
            };
            userManager.CreateAsync(this.GuestUser, this.GuestUser.UserName).Wait();

            // CSSTask has owner GuestUser
            this.CSSTask = new Task()
            {
                Title = "Improve CSS styles",
                Description = "Implement better styling for all public pages",
                CreatedOn = DateTime.Now.AddDays(-200),
                OwnerId = this.GuestUser.Id,
                BoardId = this.OpenBoard.Id
            };
            dbContext.Add(this.CSSTask);

            // Create UserMaria
            this.UserMaria = new User()
            {
                UserName = "maria",
                Email = "maria@gmail.com",
                FirstName = "Maria",
                LastName = "Green",
            };
            userManager.CreateAsync(this.UserMaria, this.UserMaria.UserName).Wait();

            // EditTask has owner UserMaria
            this.EditTask = new Task()
            {
                Id = 5,
                Title = "Edit functionality",
                Description = "Implement task editing functionality",
                CreatedOn = DateTime.Now.AddDays(-20),
                BoardId = this.OpenBoard.Id,
                OwnerId = this.UserMaria.Id
            };
            dbContext.Add(this.EditTask);

            dbContext.SaveChanges();
        }
    }
}
