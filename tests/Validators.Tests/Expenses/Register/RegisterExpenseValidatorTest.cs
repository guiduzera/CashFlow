using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Enums;
using CashFlow.Exception;
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

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("      ")]
    public void ShouldBeFailWhenTitleIsEmpty(string title)
    {
        // Arrange
        var validator = new RegisterExpenseValidator();
        var request = RegisterExpensesRequestBuilder.Build();
        request.Title = title;

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.TITLE_REQUIRED));
    }

    [Fact]
    public void ShouldBeFailWhenDateIsInTheFuture()
    {
        // Arrange
        var validator = new RegisterExpenseValidator();
        var request = RegisterExpensesRequestBuilder.Build();
        request.Date = DateTime.UtcNow.AddDays(1);

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.EXPENSES_CANNOT_BE_IN_THE_FEATURE));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void ShouldBeFailWhenAmountIsLessOrEqualThanZero(decimal amount)
    {
        // Arrange
        var validator = new RegisterExpenseValidator();
        var request = RegisterExpensesRequestBuilder.Build();
        request.Amount = amount;

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.AMOUNT_MUST_BE_GREATER_THAN_ZERO));
    }

    [Fact]
    public void ShouldBeFailWhenPaymentTypeIsInvalid()
    {
        // Arrange
        var validator = new RegisterExpenseValidator();
        var request = RegisterExpensesRequestBuilder.Build();
        request.PaymentType = (PaymentType)10;

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.PAYMENT_TYPE_INVALID));
    }
}
