namespace CashFlow.Exception.ExceptionsBase;
public class ErrorValidationException : CashFlowException
{
    public List<string> ErrorMessages { get; set; }

    public ErrorValidationException(List<string> erroMessages)
    {
        ErrorMessages = erroMessages;
    }
}
