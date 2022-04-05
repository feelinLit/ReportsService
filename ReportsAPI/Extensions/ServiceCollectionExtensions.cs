using Microsoft.EntityFrameworkCore;
using ReportsBLL.DataTransferObjects.Comments;
using ReportsBLL.DataTransferObjects.Employees;
using ReportsBLL.DataTransferObjects.Problems;
using ReportsBLL.DataTransferObjects.Reports;
using ReportsBLL.Interfaces;
using ReportsBLL.Models.Employees;
using ReportsBLL.Services;
using ReportsDAL.Data;
using ReportsDAL.Data.Repositories;

namespace ReportsAPI.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<ReportsDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")))
            .AddDatabaseDeveloperPageExceptionFilter();

    public static IServiceCollection AddServices(this IServiceCollection services) =>
        services.AddScoped<IUnitOfWork, UnitOfWork>()
            .AddScoped<IRepository<Employee>, EmployeeRepository>()
            .AddScoped<EmployeeService>()
            .AddScoped<ProblemService>()
            .AddScoped<ReportService>();

    public static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services) =>
        services.AddAutoMapper(typeof(EmployeeViewModel))
            .AddAutoMapper(typeof(ProblemViewModel))
            .AddAutoMapper(typeof(CommentViewModel))
            .AddAutoMapper(typeof(ReportViewModel));
}