using Presentation.WebApp.Models.Authentication;
using System.ComponentModel.DataAnnotations;


namespace Tests.Forms;

public class RegisterEmailFormTests
{
    [Fact]
    public void Email_Should_Be_Required()
    {
        // Arrange
        var model = new RegisterEmailForm
        {
            Email = ""
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
        var model = new RegisterEmailForm
        {
            Email = "not-an-email"
        };

        // Act
        var results = ValidateModel(model);

        // Assert
        Assert.NotEmpty(results);
    }

    [Fact]
    public void Valid_Email_Should_Pass()
    {
        // Arrange
        var model = new RegisterEmailForm
        {
            Email = "test@example.com"
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