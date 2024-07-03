using Bogus;
using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;

namespace CommonTestUtilities.Requests;
public class RegisterExpensesRequestBuilder
{
    public static RegisterExpensesRequest Build()
    {
        Faker<RegisterExpensesRequest> fakeRegisterExpensesRequest = new Faker<RegisterExpensesRequest>()
            .RuleFor(x => x.Title, f => f.Lorem.Sentence())
            .RuleFor(x => x.Description, f => f.Lorem.Paragraph())
            .RuleFor(x => x.Date, f => f.Date.Past())
            .RuleFor(x => x.Amount, f => f.Finance.Amount())
            .RuleFor(x => x.PaymentType, f => f.PickRandom<PaymentType>());

        return fakeRegisterExpensesRequest;
    }
}
