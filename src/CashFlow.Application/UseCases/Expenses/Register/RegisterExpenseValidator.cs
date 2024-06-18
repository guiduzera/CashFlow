using CashFlow.Communication.Requests;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses.Register;
internal class RegisterExpenseValidator : AbstractValidator<RegisterExpensesRequest>
{
    public RegisterExpenseValidator()
    {
        RuleFor(expense => expense.Title)
            .NotEmpty()
            .WithMessage("Title is required");
        RuleFor(expense => expense.Amount)
            .GreaterThan(0)
            .WithMessage("Amount must be greater than zero");
        RuleFor(expense => expense.Date)
            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("Expenses cannot be in the feature");
        RuleFor(expense => expense.PaymentType)
            .IsInEnum()
            .WithMessage("Payment type is invalid");
    }
}
