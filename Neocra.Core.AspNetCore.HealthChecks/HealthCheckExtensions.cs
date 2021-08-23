using System.Reflection;
using System.Threading.Tasks;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Neocra.Core.AspNetCore.HealthChecks
{
    public static class HealthCheckExtensions
    {
        public static void MapHealthChecksUIWithVersion(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            endpointRouteBuilder.MapHealthChecks("/api/healthcheck",
                new HealthCheckOptions
                {
                    Predicate = _ => true,
                    ResponseWriter = WriteHealthCheckUiResponse
                });
        }

        public static Task WriteHealthCheckUiResponse(HttpContext context, HealthReport report)
        {
            var version = GetVersionHelper();
            context.Response.Headers.Add("version", version);
            
            return UIResponseWriter.WriteHealthCheckUIResponse(context, report);
        }

        public static string GetVersionHelper()
        {
            var version =
                Assembly.GetEntryAssembly()?.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion
                ?? Assembly.GetEntryAssembly()?.GetName().Version?.ToString();
            return version;
        }
    }
}