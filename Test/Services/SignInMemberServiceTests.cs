using Application.Abstractions.Identity;
using Application.Common.Results;
using Application.Members.Inputs;
using Application.Members.Services;
using Moq;

namespace Tests.Services;

public class SignInMemberServiceTests
{
    [Fact]
    public async Task ExecuteAsync_Should_Return_Error_When_Input_Is_Null()
    {
        // Arrange
        var identityMock = new Mock<IIdentityService>();
        var service = new SignInMemberService(identityMock.Object);

        // Act
        var result = await service.ExecuteAsync(null!);

        // Assert
        Assert.False(result.Success);
        Assert.Contains("input must be provided", result.ErrorMessage);
    }

    [Fact]
    public async Task ExecuteAsync_Should_Return_Error_When_Login_Fails()
    {
        // Arrange
        var input = new SignInInput(
            "test@example.com",
            "wrong-password",
            false
        );

        var identityMock = new Mock<IIdentityService>();

        identityMock
            .Setup(x => x.PasswordSignInAsync(
                input.Email,
                input.Password,
                input.RememberMe,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(Result<string?>.Error("Invalid email or password"));

        var service = new SignInMemberService(identityMock.Object);

        // Act
        var result = await service.ExecuteAsync(input);

        // Assert
        Assert.False(result.Success);
        Assert.Equal("Invalid email or password", result.ErrorMessage);
    }

    [Fact]
    public async Task ExecuteAsync_Should_Return_Ok_When_Login_Succeeds()
    {
        // Arrange
        var input = new SignInInput(
            "test@example.com",
            "Password123!",
            true
        );

        var identityMock = new Mock<IIdentityService>();

        identityMock
            .Setup(x => x.PasswordSignInAsync(
                input.Email,
                input.Password,
                input.RememberMe,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(Result<string?>.Ok("Success"));

        var service = new SignInMemberService(identityMock.Object);

        // Act
        var result = await service.ExecuteAsync(input);

        // Assert
        Assert.True(result.Success);
    }
}