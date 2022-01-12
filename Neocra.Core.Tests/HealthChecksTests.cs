using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Neocra.Core.AspNetCore.HealthChecks;
using Neocra.Xunit.Extensions;
using Xunit;

namespace Neocra.Core.Tests
{
    public class HealthChecksTests
    {
        [NamedFact]
        public async Task Should_get_version_When_generate_response()
        {
            var defaultHttpContext = new DefaultHttpContext();
            await HealthCheckExtensions.WriteHealthCheckUiResponse(defaultHttpContext,
                new HealthReport(new Dictionary<string, HealthReportEntry>(), HealthStatus.Healthy, TimeSpan.Zero));
            
            Assert.True(defaultHttpContext.Response.Headers.ContainsKey("version"));
        }
    }
}