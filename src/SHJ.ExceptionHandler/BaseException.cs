using ServiceStack;

namespace SHJ.ExceptionHandler;

public class BaseException : WebServiceException
{
    public BaseException(string? message = default) : base(message)
    {
        this.StatusCode = StatusCode;
    }
    public BaseException(int StatusCode, string? message = default) : base(message)
    {
        this.StatusCode = StatusCode;
    }
}
