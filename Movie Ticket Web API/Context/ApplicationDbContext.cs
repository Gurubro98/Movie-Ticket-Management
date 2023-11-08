using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Movie_Ticket_Web_API.Models;

namespace Movie_Ticket_Web_API.Context
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            this.SeedUsers(modelBuilder);
            this.SeedRoles(modelBuilder);
            this.SeedUserRoles(modelBuilder);
            this.SeedMovies(modelBuilder);
        }

        private void SeedUsers(ModelBuilder builder)
        {
            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            builder.Entity<User>().Property(p => p.Name).HasMaxLength(255).IsRequired();
            User Admin = new User()
            {
                Id = "1",
                Name = "Admin",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                LockoutEnabled = true,
                PasswordHash = passwordHasher.HashPassword(null, "Admin@123")
            };
            User user = new User()
            {
                Id = "2",
                Name = "User",
                Email = "user@gmail.com",
                NormalizedEmail = "USER@GMAIL.COM",
                UserName = "user@gmail.com",
                NormalizedUserName = "USER@GMAIL.COM",
                LockoutEnabled = true,
                PasswordHash = passwordHasher.HashPassword(null, "User@123")
            };



            builder.Entity<User>().HasData(Admin);
            builder.Entity<User>().HasData(user);
        }
        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "1", UserId = "1" },
                new IdentityUserRole<string>() { RoleId = "2", UserId = "2" }
                );
        }
        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "1", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "ADMIN" },
                new IdentityRole() { Id = "2", Name = "User", ConcurrencyStamp = "2", NormalizedName = "USER" }
                );
        }
        private void SeedMovies(ModelBuilder builder)
        {
            builder.Entity<Movie>().HasData(
                new Movie() { MovieId = 1, Name = "Sultan", Date= "2022-08-06", Genre="Action", Cast="Salman Khan",  UserId="1" },
                new Movie() { MovieId = 2, Name = "Dangal", Date = "2022-06-05", Genre = "Action", Cast = "Amir Khan", UserId = "1" }
                );
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<BookingCart> BookingCarts { get; set; }
    }
}
