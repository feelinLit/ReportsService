using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Reports.DAL.Data;
using Xunit;

namespace Reports.Tests.IntegrationTests;

public class BasicTests
{
    [Fact]
    public async Task GetEmployees_ReturnsOK()
    {
        await using var application = new ReportsServiceApplication();
        var client = application.CreateClient();

        var response = await client.GetAsync("/api/Employee");
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetProblems_ReturnsOK()
    {
        await using var application = new ReportsServiceApplication();
        var client = application.CreateClient();

        var response = await client.GetAsync("/api/Problem");
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetSwaggerDoc_ReturnsOK()
    {
        await using var application = new ReportsServiceApplication();
        var client = application.CreateClient();

        var response = await client.GetAsync("/swagger/v1/swagger.json");
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    private class ReportsServiceApplication : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                         typeof(DbContextOptions<ReportsDbContext>));

                services.Remove(descriptor);

                services.AddDbContext<ReportsDbContext>(options =>
                    options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TestDb;Trusted_Connection=True;"));

                var sp = services.BuildServiceProvider();

                using var scope = sp.CreateScope();
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<ReportsDbContext>();

                db.Database.EnsureCreated();
            });
        }
    }
}