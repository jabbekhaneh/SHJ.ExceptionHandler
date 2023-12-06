namespace SHJ.ExceptionHandler;

public class BaseException : Exception
{
    public int StatusCode { get; set; }
    public BaseException(int StatusCode, string? message = default) : base(message)
    {
        this.StatusCode = StatusCode;
    }
}
