using Microsoft.Extensions.Logging;
using Xunit;

namespace Neocra.Core.Logger.Xunit;

public static class XUnitLoggerExtensions
{
    public static ILoggingBuilder AddXUnitLogger(
        this ILoggingBuilder builder, 
        ITestOutputHelper testOutputHelper)
    {
        builder.AddProvider(new XUnitLoggerProvider(testOutputHelper))
            .AddFilter<XUnitLoggerProvider>(null, LogLevel.Trace);
        return builder;
    }
}