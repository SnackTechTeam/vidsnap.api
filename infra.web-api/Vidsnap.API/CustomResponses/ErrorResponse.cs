﻿namespace Vidsnap.API.CustomResponses;

public record ErrorResponse(string Message, ExceptionResponse? Exception);

public class ExceptionResponse
{
    public ExceptionResponse(Exception exception)
    {
        Type = exception.GetType().FullName;
        Stack = exception.StackTrace;
        TargetSite = exception.TargetSite?.ToString();
    }

    public string? Type { get; private set; }
    public string? Stack { get; private set; }
    public string? TargetSite { get; private set; }
}