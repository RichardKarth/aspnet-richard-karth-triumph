using Application.Members.Services;
using Domain.Abstractions.Repositories.Members;
using Domain.Aggregates.Members;
using Moq;

namespace Tests.Services;

public class GetMemberProfileServiceTests
{
    [Fact]
    public async Task ExecuteAsync_Should_Return_Error_When_UserId_Is_Empty()
    {
        // Arrange
        var repositoryMock = new Mock<IMemberRepository>();
        var service = new GetMemberProfileService(repositoryMock.Object);

        // Act
        var result = await service.ExecuteAsync("");

        // Assert
        Assert.False(result.Success);
        Assert.Contains("User Id must be provided", result.ErrorMessage);
    }

    [Fact]
    public async Task ExecuteAsync_Should_Return_NotFound_When_Member_Does_Not_Exist()
    {
        // Arrange
        var repositoryMock = new Mock<IMemberRepository>();

        repositoryMock
            .Setup(x => x.GetMemberByUserIdAsync("user-1", It.IsAny<CancellationToken>()))
            .ReturnsAsync((Member?)null);

        var service = new GetMemberProfileService(repositoryMock.Object);

        // Act
        var result = await service.ExecuteAsync("user-1");

        // Assert
        Assert.False(result.Success);
        Assert.Contains("not found", result.ErrorMessage);
    }

    [Fact]
    public async Task ExecuteAsync_Should_Return_Member_When_Member_Exists()
    {
        // Arrange
        var member = Member.Create("user-1");

        var repositoryMock = new Mock<IMemberRepository>();

        repositoryMock
            .Setup(x => x.GetMemberByUserIdAsync("user-1", It.IsAny<CancellationToken>()))
            .ReturnsAsync(member);

        var service = new GetMemberProfileService(repositoryMock.Object);

        // Act
        var result = await service.ExecuteAsync("user-1");

        // Assert
        Assert.True(result.Success);
        Assert.NotNull(result.Value);
        Assert.Equal("user-1", result.Value.UserId);
    }
}