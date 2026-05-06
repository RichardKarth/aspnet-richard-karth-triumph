using Application.Abstractions.Identity;
using Application.Common.Results;
using Application.Members.Inputs;
using Application.Members.Services;
using Domain.Abstractions.Repositories.Members;
using Domain.Aggregates.Members;
using Moq;

namespace Tests.Services;

public class RegisterMemberServiceTests
{
    [Fact]
    public async Task ExecuteAsync_Should_Return_Error_When_Input_Is_Null()
    {
        // Arrange
        var identityMock = new Mock<IIdentityService>();
        var repositoryMock = new Mock<IMemberRepository>();

        var service = new RegisterMemberService(
            identityMock.Object,
            repositoryMock.Object);

        // Act
        var result = await service.ExecuteAsync(null!);

        // Assert
        Assert.False(result.Success);
        Assert.Contains("input must be provided", result.ErrorMessage);
    }

    [Fact]
    public async Task ExecuteAsync_Should_Return_BadRequest_When_User_Creation_Fails()
    {
        // Arrange
        var input = new RegisterMemberInput(
            "test@example.com",
            "Password123!"
        );

        var identityMock = new Mock<IIdentityService>();
        var repositoryMock = new Mock<IMemberRepository>();

        identityMock
            .Setup(x => x.CreateUserAsync(
                input.Email,
                input.Password,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(Result<string?>.BadRequest("Failed to create user"));

        var service = new RegisterMemberService(
            identityMock.Object,
            repositoryMock.Object);

        // Act
        var result = await service.ExecuteAsync(input);

        // Assert
        Assert.False(result.Success);
        Assert.Equal("Failed to create user", result.ErrorMessage);
    }

    [Fact]
    public async Task ExecuteAsync_Should_Create_Member_When_User_Creation_Succeeds()
    {
        // Arrange
        var input = new RegisterMemberInput(
            "test@example.com",
            "Password123!"
        );

        var identityMock = new Mock<IIdentityService>();
        var repositoryMock = new Mock<IMemberRepository>();

        identityMock
            .Setup(x => x.CreateUserAsync(
                input.Email,
                input.Password,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(Result<string?>.Ok("user-1"));

        repositoryMock
            .Setup(x => x.AddAsync(
                It.IsAny<Member>(),
                It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var service = new RegisterMemberService(
            identityMock.Object,
            repositoryMock.Object);

        // Act
        var result = await service.ExecuteAsync(input);

        // Assert
        Assert.True(result.Success);
        Assert.Equal("user-1", result.Value);

        repositoryMock.Verify(
            x => x.AddAsync(
                It.Is<Member>(m => m.UserId == "user-1"),
                It.IsAny<CancellationToken>()),
            Times.Once);
    }
}