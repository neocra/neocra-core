using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace Neocra.Core.Logger.Xunit;

public class XUnitLogger : ILogger, IDisposable
{
    private readonly string categoryName;
    private readonly ITestOutputHelper testOutputHelper;

    public XUnitLogger(string categoryName, ITestOutputHelper testOutputHelper)
    {
        this.categoryName = categoryName;
        this.testOutputHelper = testOutputHelper;
    }

    public IDisposable BeginScope<TState>(TState state)
    {
        return this;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return true;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        this.testOutputHelper.WriteLine(
            "{0}:{1}", 
            this.categoryName, 
            formatter(state, exception));
    }

    public void Dispose()
    {
        
    }
}