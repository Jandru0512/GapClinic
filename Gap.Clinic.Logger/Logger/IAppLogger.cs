namespace Gap.Clinic.Logger
{

    using System;
    using Microsoft.Extensions.Logging;

    public interface IAppLogger<out T> : IAppLogger
    {
    }

    public interface IAppLogger
    {
        void Log(Level level, Exception exception, string message, params object[] parameters);
        void Log(Level level, string message, params object[] parameters);
        
        bool IsEnabled(LogLevel level);
        IDisposable BeginScope<TState>(TState state);
    }
}