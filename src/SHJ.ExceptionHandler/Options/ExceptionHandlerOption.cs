namespace SHJ.ExceptionHandler.Options;

public class ExceptionHandlerOption
{
    public ExceptionHandlerOption(int serverError = 500)
    {
        ServerError = serverError;
    }
    public int ServerError { get; private set; }
}
