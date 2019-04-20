namespace Gap.Clinic.Logger
{
    using System;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions.Internal;

    public class AppLogger<T> : IAppLogger
    {
        #region Constructor
        public AppLogger(ILoggerFactory factory)
        {
            if (factory==null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            _logger = factory.CreateLogger(TypeNameHelper.GetTypeDisplayName(typeof(T)));
        }
        #endregion

        #region Private Attributes
        private readonly ILogger _logger;
        #endregion

        #region Public Methods
        public void Log(Level level, string message, params object[] parameters)
        {
            switch (level)
            {
                case Level.Information:
                    _logger.LogInformation(message, parameters);
                    break;
                case Level.Warning:
                    _logger.LogWarning(message, parameters);
                    break;
                default:
                    break;
            }
        }

        public void Log(Level level, Exception exception, string message, params object[] parameters)
        {
            switch (level)
            {
                case Level.Error:
                    _logger.LogError(exception, message, parameters);
                    break;
                case Level.Critical:
                    _logger.LogCritical(exception, message, parameters);
                    break;
                default:
                    break;
            }
        }
        #endregion
        
        IDisposable IAppLogger.BeginScope<TState>(TState state)
        {
            return _logger.BeginScope(state);
        }

        bool IAppLogger.IsEnabled(LogLevel level)
        {
            return _logger.IsEnabled(level);
        }
    }
}
