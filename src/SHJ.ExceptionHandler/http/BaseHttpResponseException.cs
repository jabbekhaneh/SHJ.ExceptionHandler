namespace SHJ.ExceptionHandler.http;

public class BaseHttpResponseException
{
    public BaseHttpResponseException(string? code, string? message)
    {
        Code = code;
        Message = message;
    }
    public string? Code { get; set; } = string.Empty;
    public string? Message { get; set; } = string.Empty;

}


