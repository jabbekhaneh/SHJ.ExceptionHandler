using System.Net;

namespace SHJ.ExceptionHandler.Exceptions;

public sealed class BaseBadRequestException : BaseBusinessException
{
    public BaseBadRequestException(string? message) : base(message)
    {
        this.StatusCode = (int)HttpStatusCode.BadRequest;
    }
}
