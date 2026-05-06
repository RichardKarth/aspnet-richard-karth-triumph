using Infrastructure.Persistance.Contexts;
using Infrastructure.Persistance.Entities.Members;
using Infrastructure.Persistance.Repositories.Members;
using Microsoft.EntityFrameworkCore;

namespace Tests.Repositories;

public class MemberRepositoryTests
{
    [Fact]
    public async Task GetMemberByUserIdAsync_Should_Return_Member_When_UserId_Exists()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        await using var context = new DataContext(options);

        var entity = new MemberEntity
        {
            Id = Guid.NewGuid().ToString(),
            UserId = "user-1",
            FirstName = "Richard",
            LastName = "Test",
            PhoneNumber = "0701234567",
            ProfileImageUrl = null,
            MembershipId = null,
            CreatedAt = DateTime.UtcNow,
            ModifiedAt = DateTime.UtcNow
        };

        context.Members.Add(entity);
        await context.SaveChangesAsync();

        var repository = new MemberRepository(context);

        // Act
        var result = await repository.GetMemberByUserIdAsync("user-1");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("user-1", result.UserId);
        Assert.Equal("Richard", result.FirstName);
        Assert.Equal("Test", result.LastName);
        Assert.Equal("0701234567", result.PhoneNumber);
    }

    [Fact]
    public async Task GetMemberByUserIdAsync_Should_Return_Null_When_UserId_Does_Not_Exist()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        await using var context = new DataContext(options);

        var repository = new MemberRepository(context);

        // Act
        var result = await repository.GetMemberByUserIdAsync("missing-user");

        // Assert
        Assert.Null(result);
    }
}