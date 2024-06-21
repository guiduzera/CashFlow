using CashFlow.Communication.Requests;
using CashFlow.Exception;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses.Register;
internal class RegisterExpenseValidator : AbstractValidator<RegisterExpensesRequest>
{
    public RegisterExpenseValidator()
    {
        RuleFor(expense => expense.Title)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.TITLE_REQUIRED);
        RuleFor(expense => expense.Amount)
            .GreaterThan(0)
            .WithMessage(ResourceErrorMessages.AMOUNT_MUST_BE_GREATER_THAN_ZERO);
        RuleFor(expense => expense.Date)
            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage(ResourceErrorMessages.EXPENSES_CANNOT_BE_IN_THE_FEATURE);
        RuleFor(expense => expense.PaymentType)
            .IsInEnum()
            .WithMessage(ResourceErrorMessages.PAYMENT_TYPE_INVALID);
    }
}
