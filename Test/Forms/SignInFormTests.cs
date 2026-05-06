using Presentation.WebApp.Models.Authentication;
using System.ComponentModel.DataAnnotations;


namespace Tests.Forms;

public class SignInFormTests
{
    [Fact]
    public void Email_Should_Be_Required()
    {
        // Arrange
        var model = new SignInForm
        {
            Email = "",
            Password = "Password123!"
        };

        // Act
        var results = ValidateModel(model);

        // Assert
        Assert.NotEmpty(results);
    }

    [Fact]
    public void Password_Should_Be_Required()
    {
        // Arrange
        var model = new SignInForm
        {
            Email = "test@example.com",
            Password = ""
        };

        // Act
        var results = ValidateModel(model);

        // Assert
        Assert.NotEmpty(results);
    }

    [Fact]
    public void Invalid_Email_Should_Fail()
    {
        // Arrange
        var model = new SignInForm
        {
            Email = "not-an-email",
            Password = "Password123!"
        };

        // Act
        var results = ValidateModel(model);

        // Assert
        Assert.NotEmpty(results);
    }

    [Fact]
    public void Valid_Form_Should_Pass()
    {
        // Arrange
        var model = new SignInForm
        {
            Email = "test@example.com",
            Password = "Password123!"
        };

        // Act
        var results = ValidateModel(model);

        // Assert
        Assert.Empty(results);
    }

    private static List<ValidationResult> ValidateModel(object model)
    {
        // Arrange
        var results = new List<ValidationResult>();
        var context = new ValidationContext(model);

        // Act
        Validator.TryValidateObject(model, context, results, true);

        // Return
        return results;
    }
}