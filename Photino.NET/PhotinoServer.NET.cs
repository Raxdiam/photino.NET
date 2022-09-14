using System;
using System.Linq;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace PhotinoNET;

/// <summary>
/// The PhotinoServer class enables users to host their web projects in
/// a static, local file server to prevent CORS and other issues.
/// </summary>
public class PhotinoServer
{
    public static WebApplication CreateStaticFileServer(
        string[] args,
        out string baseUrl)
    {
        return CreateStaticFileServer(
            args,
            startPort: 8000,
            portRange: 100,
            out baseUrl);
    }

    public static WebApplication CreateStaticFileServer(
        string[] args,
        int startPort,
        int portRange,
        out string baseUrl)
    {
        var builder = WebApplication
            .CreateBuilder(new WebApplicationOptions()
            {
                Args = args,
                WebRootPath = "wwwroot"
            });

        int port = startPort;

        // Try ports until available port is found
        while (IPGlobalProperties
            .GetIPGlobalProperties()
            .GetActiveTcpListeners()
            .Any(x => x.Port == port))
        {
            if (port > port + portRange)
            {
                throw new SystemException($"Couldn't find open port within range {port - portRange} - {port}.");
            }

            port++;
        }

        baseUrl = $"http://localhost:{port}";

        builder.WebHost.UseUrls(baseUrl);

        WebApplication app = builder.Build();
        app.UseStaticFiles(new StaticFileOptions
        {
            DefaultContentType = "text/plain"
        });

        return app;
    }
}