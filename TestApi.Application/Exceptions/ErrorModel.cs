namespace TestApi.Domain.Exceptions;

public class ErrorModel
{
    public ErrorModel(int status, string message)
    {
        StatusCode = status;
        Message = message;
    }

    private int StatusCode { get; }
    private string Message { get; }

    public new string ToString() => $"{{ \"StatusCode\": {StatusCode}, \"Message\": \"{Message}\" }}";
}