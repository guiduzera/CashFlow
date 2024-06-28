using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;

namespace Validators.Tests.Expenses.Register;
public class RegisterExpenseValidatorTest
{
    [Fact]
    public void ShouldBeSuccess()
    {
        // Arrange
        var validator = new RegisterExpenseValidator();
        var request = new RegisterExpensesRequest
        {
            Title = "Test1",
            Description = "Test",
            Amount = 200,
            PaymentType = CashFlow.Communication.Enums.PaymentType.CreditCard,
            Date = DateTime.UtcNow.AddDays(-1),
        };

        // Act
        var result = validator.Validate(request);

        // Assert
        Assert.True(result.IsValid);
    }
}
