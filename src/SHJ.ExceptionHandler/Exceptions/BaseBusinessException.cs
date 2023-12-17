using ServiceStack;

namespace SHJ.ExceptionHandler.Exceptions;

public class BaseBusinessException : WebServiceException
{
    public BaseBusinessException(string? code, string? message = default) : base(message)
    {
        Code = code;
    }

    public string? Code { get; private set; } = string.Empty;



}

