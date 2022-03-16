using ReportsAPI.Extensions;
using ReportsBLL.DataTransferObjects;
using ReportsBLL.DataTransferObjects.Comments;
using ReportsBLL.DataTransferObjects.Employees;
using ReportsBLL.DataTransferObjects.Problems;
using ReportsBLL.DataTransferObjects.Reports;
using ReportsBLL.Interfaces;
using ReportsBLL.Models.Employees;
using ReportsBLL.Services;
using ReportsDAL.Data;
using ReportsDAL.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddDatabase(builder.Configuration)
    .AddScoped<IUnitOfWork, UnitOfWork>()
    .AddScoped<IRepository<Employee>, EmployeeRepository>()
    .AddScoped<EmployeeService>()
    .AddScoped<ProblemService>()
    .AddScoped<ReportService>()
    .AddAutoMapper(typeof(EmployeeDto))
    .AddAutoMapper(typeof(ProblemDto))
    .AddAutoMapper(typeof(CommentDto))
    .AddAutoMapper(typeof(ReportDto));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider; // TODO: remove using?

    var context = services.GetRequiredService<ReportsDbContext>();
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();