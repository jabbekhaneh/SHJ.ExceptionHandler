namespace SHJ.ExceptionHandler;

public class BaseBusinessException : Exception
{
    public BaseBusinessException(string? message = default) : base(message)
    {

    }
    public BaseBusinessException(string code, string? message = default) : base(message)
    {
        this.Code = code;
    }

    public string? Code { get; private set; } = string.Empty;
    
    

}

