using ServiceStack;

namespace SHJ.ExceptionHandler;

public class BaseBusinessException : WebServiceException
{
    public BaseBusinessException(string? code, string? message = default) : base(message)
    {
        this.Code = code;
    }

    public string? Code { get; private set; } = string.Empty;



}

