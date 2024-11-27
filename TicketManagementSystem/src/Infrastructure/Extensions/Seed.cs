using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Extensions;

public static class Seed
{
    private const string _user1 = "BA0488F2-E952-491B-A41B-640E3A88B37B";

    public static void GenerateSeed(this ModelBuilder modelBuilder)
    {
        string USER_EMAIL = "test@gmail.com";

        // Create User
        var appUser = new User
        {
            Id = _user1,
            Email = USER_EMAIL,
            EmailConfirmed = true,
            UserName = USER_EMAIL,
            NormalizedEmail = USER_EMAIL.ToUpper(),
            NormalizedUserName = USER_EMAIL.ToUpper()
        };

        // Set User Password
        PasswordHasher<User> ph = new PasswordHasher<User>();
        appUser.PasswordHash = ph.HashPassword(appUser, "Qwert#12345");

        // Seed User
        modelBuilder.Entity<User>().HasData(appUser);

        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                CategoryId = 1,
                CategoryName = "Application Bug"
            },
            new Category
            {
                CategoryId = 2,
                CategoryName = "Network Issue"
            },
            new Category
            {
                CategoryId = 3,
                CategoryName = "User Issue"
            }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                ProductId = 1,
                ProductName = "Product 1"
            },
            new Product
            {
                ProductId = 2,
                ProductName = "Product 2"
            }
        );

        modelBuilder.Entity<Priority>().HasData(
            new Priority
            {
                PriorityId = 1,
                PriorityName = "Low",
                ExpectedDays = 14
            },
            new Priority
            {
                PriorityId = 2,
                PriorityName = "Medium",
                ExpectedDays = 7
            },
            new Priority
            {
                PriorityId = 3,
                PriorityName = "High",
                ExpectedDays = 1
            }
        );

        Ticket(modelBuilder);
    }

    public static void Ticket(ModelBuilder modelBuilder)
    {
        var tickets = new[]
        {
            new Ticket { TicketId = 1, RaisedBy = _user1, ProductId = 1, CategoryId = 1, PriorityId = 1, Status = "NEW", Summary = "Sample Ticket 1", Description = "Sample Ticket 1" }
        };
    }
}