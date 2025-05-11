using Microsoft.Extensions.Logging;
using Xunit;

namespace Neocra.Core.Logger.Xunit;

public class XUnitLoggerProvider : ILoggerProvider
{
    private readonly ITestOutputHelper testOutputHelper;

    public XUnitLoggerProvider(ITestOutputHelper testOutputHelper)
    {
        this.testOutputHelper = testOutputHelper;
    }

    public void Dispose()
    {
    }

    public ILogger CreateLogger(string categoryName)
    {
        return new XUnitLogger(categoryName, this.testOutputHelper);
    }
}