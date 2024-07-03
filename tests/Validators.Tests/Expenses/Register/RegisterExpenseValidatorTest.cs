using CashFlow.Application.UseCases.Expenses.Register;
using CommonTestUtilities.Requests;
using FluentAssertions;

namespace Validators.Tests.Expenses.Register;
public class RegisterExpenseValidatorTest
{
    [Fact]
    public void ShouldBeSuccess()
    {
        // Arrange
        var validator = new RegisterExpenseValidator();
        var request = RegisterExpensesRequestBuilder.Build();

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.Should().BeTrue();
    }
}
