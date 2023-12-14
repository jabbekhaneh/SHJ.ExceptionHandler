SHJ.ExceptionHandler
=======

Simple SHJ.ExceptionHandler implementation in ASP.NET
Examples in the [wiki](https://github.com/jabbekhaneh/SHJ.ExceptionHandler).

<!-- ### How do I get started? -->

### Installing SHJ.ExceptionHandler
You should install [SHJ.ExceptionHandler with NuGet](https://www.nuget.org/packages/SHJ.ExceptionHandler):

```bash
> Install-Package SHJ.ExceptionHandler
```

Or via the .NET Core command line interface:
   
```bash
> dotnet add package SHJ.ExceptionHandler
```

### Registering with `IServiceCollection`

```
services.AddSHJExceptionHandler();

```

### Registering with `IApplicationBuilder`

```
app.UseSHJExceptionHandler();
```



