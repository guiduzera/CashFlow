using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(RegisterExpensesResponse), StatusCodes.Status201Created)]
    public IActionResult Register([FromBody] RegisterExpensesRequest request)
    {
        RegisterExpensesResponse useCase = new RegisterExpenseUseCase().Execute(request);

        return Created(string.Empty, useCase);
    }
}
