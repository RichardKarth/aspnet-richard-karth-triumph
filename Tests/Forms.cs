using Presentation.WebApp.Models.Authentication;
using System.ComponentModel.DataAnnotations;

namespace Tests.Forms;

public class RegisterEmailFormTests
{
    [Fact]
    public void Email_Should_Be_Required()
    {
        var model = new RegisterEmailForm
        {
            Email = ""
        };

        var results = ValidateModel(model);

        Assert.NotEmpty(results);
    }

    [Fact]
    public void Email_Should_Be_Valid_Email_Address()
    {
        var model = new RegisterEmailForm
        {
            Email = "not-an-email"
        };

        var results = ValidateModel(model);

        Assert.NotEmpty(results);
    }

    [Fact]
    public void Valid_Email_Should_Pass()
    {
        var model = new RegisterEmailForm
        {
            Email = "test@example.com"
        };

        var results = ValidateModel(model);

        Assert.Empty(results);
    }

    private static List<ValidationResult> ValidateModel(object model)
    {
        var results = new List<ValidationResult>();
        var context = new ValidationContext(model);

        Validator.TryValidateObject(model, context, results, true);

        return results;
    }
}