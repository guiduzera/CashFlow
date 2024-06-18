using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register;
public class RegisterExpenseUseCase
{
    public RegisterExpensesResponse Execute(RegisterExpensesRequest request)
    {
        ValidateRequest(request);

        return new RegisterExpensesResponse
        {
            Title = request.Title
        };
    }

    private void ValidateRequest(RegisterExpensesRequest request)
    {
        RegisterExpenseValidator validator = new RegisterExpenseValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            List<string> errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

            // throw new ArgumentException(errorMessages);
        }
    }
}
