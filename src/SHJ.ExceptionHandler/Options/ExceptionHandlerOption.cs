namespace SHJ.ExceptionHandler.Options;

public class ExceptionHandlerOption
{
    public int ServerError { get; set; } = 500;
    public EnvironmentExceptionHandlerType Environment { get; set; } = EnvironmentExceptionHandlerType.IsDevelopment;
}

public enum EnvironmentExceptionHandlerType
{
    IsDevelopment,
    IsProduction,
    IsStaging,
}
