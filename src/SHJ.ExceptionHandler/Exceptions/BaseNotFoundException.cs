using System.Net;

namespace SHJ.ExceptionHandler.Exceptions;

public sealed class BaseNotFoundException : BaseBusinessException
{
    public BaseNotFoundException(string? message):base(message)
    {
        this.StatusCode = (int)HttpStatusCode.NotFound;
    }
}
