using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Reports.Domain.DataTransferObjects;
using Reports.Domain.Interfaces;
using Reports.Domain.Models.Employees;
using Reports.Domain.Services;
using Reports.Domain.Tools.Mapping;
using Xunit;

namespace Reports.Tests.UnitTests;

public class EmployeeServiceTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly IMapper _mapper;

    public EmployeeServiceTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _unitOfWorkMock.Setup(uow => uow.SaveChangesAsync()).ReturnsAsync(null);

        _mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<EmployeeProfile>();
            cfg.AddProfile<ProblemProfile>();
            cfg.AddProfile<CommentProfile>();
            cfg.AddProfile<ReportProfile>();
        }));
    }

    [Fact]
    public async Task GetAllEmployees_ReturnsAllEmployees()
    {
        var employeeRepositoryMock = new Mock<IRepository<Employee>>();
        var expectedEmployees = CreateSomeEmployees();
        employeeRepositoryMock.Setup(er => er.GetListAsync(e => true))
            .ReturnsAsync(expectedEmployees);
        var expectedEmployeesViewModels = _mapper.Map<List<Employee>, List<EmployeeViewModel>>(expectedEmployees);
        var mapperMock = new Mock<IMapper>();
        mapperMock.Setup(m => m.Map<List<Employee>, List<EmployeeViewModel>>(expectedEmployees))
            .Returns(expectedEmployeesViewModels);
        var employeeService = new EmployeeService(employeeRepositoryMock.Object, _unitOfWorkMock.Object, mapperMock.Object);

        var response = await employeeService.GetAllAsync();
        
        Assert.Equal(expectedEmployeesViewModels, response.Resource);
    }

    [Fact]
    public async Task GetNonExistentEmployee_ReturnsErrorMessage()
    {
        var employeeRepositoryMock = new Mock<IRepository<Employee>>();
        employeeRepositoryMock.Setup(er => er.FindByIdAsync(It.IsAny<long>())).ReturnsAsync(() => null);
        var employeeService = new EmployeeService(employeeRepositoryMock.Object, _unitOfWorkMock.Object, _mapper);

        var response = await employeeService.GetAsync(It.IsAny<ulong>());
        
        Assert.False(response.Success);
        Assert.Null(response.Resource);
    }

    private List<Employee> CreateSomeEmployees()
    {
        var teamlead = new TeamLead("Lolek", null);
        var employee2 = new Employee("Kolek", teamlead);
        var employee3 = new Employee("Jojek", teamlead);
        var employee4 = new Employee("Xi", employee2);
        return new List<Employee>() { teamlead, employee2, employee3, employee4 };
    }
}