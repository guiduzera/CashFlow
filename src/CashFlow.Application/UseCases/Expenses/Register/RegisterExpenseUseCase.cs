using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register;
public class RegisterExpenseUseCase
{
    public RegisterExpensesResponse Execute(RegisterExpensesRequest request)
    {
        return new RegisterExpensesResponse
        {
            Title = request.Title
        };
    }
}
