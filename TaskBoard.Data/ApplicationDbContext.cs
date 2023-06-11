using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TaskBoard.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        private bool seedDb = true;

        private User guestUser;
        private Board openBoard;
        private Board inProgressBoard;
        private Board doneBoard;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, bool seedDb = true)
            : base(options)
        {
            this.seedDb = seedDb;
            this.Database.EnsureCreated();
        }

        public DbSet<Board> Boards { get; set; }

        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            if (seedDb)
            {
                builder
                    .Entity<Task>()
                    .HasOne(t => t.Board)
                    .WithMany(b => b.Tasks)
                    .HasForeignKey(t => t.BoardId)
                    .OnDelete(DeleteBehavior.Restrict);

                SeedBoards();
                builder
                    .Entity<Board>()
                    .HasData(this.openBoard, this.inProgressBoard, this.doneBoard);

                SeedUsers();
                builder.Entity<User>()
                    .HasData(this.guestUser);

                builder
                    .Entity<Task>()
                    .HasData(new Task()
                    {
                        Id = 1,
                        Title = "Improve CSS styles",
                        Description = "Implement better styling for all public pages",
                        CreatedOn = DateTime.Now.AddDays(-200),
                        OwnerId = this.guestUser.Id,
                        BoardId = this.openBoard.Id
                    },
                    new Task()
                    {
                        Id = 2,
                        Title = "Android Client App",
                        Description = "Create Android client app for the TaskBoard RESTful API",
                        CreatedOn = DateTime.Now.AddMonths(-5),
                        OwnerId = this.guestUser.Id,
                        BoardId = this.openBoard.Id
                    },
                    new Task()
                    {
                        Id = 3,
                        Title = "Desktop Client App",
                        Description = "Create Windows Forms desktop app client for the TaskBoard RESTful API",
                        CreatedOn = DateTime.Now.AddMonths(-1),
                        OwnerId = this.guestUser.Id,
                        BoardId = this.inProgressBoard.Id
                    },
                    new Task()
                    {
                        Id = 4,
                        Title = "Create Task",
                        Description = "Implement [Create Task] page for adding new tasks",
                        CreatedOn = DateTime.Now.AddYears(-1),
                        OwnerId = this.guestUser.Id,
                        BoardId = this.doneBoard.Id
                    });
            }

            base.OnModelCreating(builder);
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<User>();

            this.guestUser = new User()
            {
                UserName = "guest",
                NormalizedUserName = "GUEST",
                Email = "guest@mail.com",
                NormalizedEmail = "GUEST@MAIL.COM",
                FirstName = "Guest",
                LastName = "User",
            };

            this.guestUser.PasswordHash = hasher.HashPassword(this.guestUser, "guest");
        }

        private void SeedBoards()
        {
            this.openBoard = new Board()
            {
                Id = 1,
                Name = "Open"
            };

            this.inProgressBoard = new Board()
            {
                Id = 2,
                Name = "In Progress"
            };

            this.doneBoard = new Board()
            {
                Id = 3,
                Name = "Done"
            };
        }
    }
}
