namespace SHJ.ExceptionHandler;

public class BaseErrorResposne
{
    public BaseErrorResposne(long statusCode, string message)
    {
        StatusCode = statusCode;
        Message = message;
    }

    public long StatusCode { get; private set; }
    public string Message { get; private set; } = string.Empty;
}
