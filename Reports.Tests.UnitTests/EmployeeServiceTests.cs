using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Reports.Domain.Interfaces;
using Reports.Domain.Models.Employees;
using Reports.Domain.Services;
using Reports.Domain.Tools.Mapping;
using Reports.Shared.DataTransferObjects;
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
        var repositoryMock = new Mock<IRepository<Employee>>();
        var expectedEmployees = CreateSomeEmployees();
        repositoryMock.Setup(er => er.GetListAsync(e => true))
            .ReturnsAsync(expectedEmployees);
        var expectedEmployeesViewModels = _mapper.Map<List<Employee>, List<EmployeeViewModel>>(expectedEmployees);
        var mapperMock = new Mock<IMapper>();
        mapperMock.Setup(m => m.Map<List<Employee>, List<EmployeeViewModel>>(expectedEmployees))
            .Returns(expectedEmployeesViewModels);
        var employeeService = new EmployeeService(repositoryMock.Object, _unitOfWorkMock.Object, mapperMock.Object);

        var response = await employeeService.GetAllAsync();
        
        Assert.Equal(expectedEmployeesViewModels, response.Resource);
    }

    [Fact]
    public async Task GetNonExistentEmployee_ReturnsErrorMessage()
    {
        var repositoryMock = new Mock<IRepository<Employee>>();
        repositoryMock.Setup(er => er.FindByIdAsync(It.IsAny<ulong>())).ReturnsAsync(() => null);
        var employeeService = new EmployeeService(repositoryMock.Object, _unitOfWorkMock.Object, _mapper);

        var response = await employeeService.GetAsync(It.IsAny<ulong>());
        
        Assert.False(response.Success);
        Assert.Null(response.Resource);
        Assert.NotEmpty(response.ErrorMessage);
    }

    [Fact]
    public async Task GetEmployee_ReturnsEmployee()
    {
        const ulong employeeId = 22;
        var employeeExpected = new Employee("funny-username", null);
        var repositoryMock = new Mock<IRepository<Employee>>();
        repositoryMock.Setup(er => er.FindByIdAsync(employeeId)).ReturnsAsync(employeeExpected);
        var employeeExpectedViewModel = _mapper.Map<Employee, EmployeeViewModel>(employeeExpected);
        var mapperMock = new Mock<IMapper>();
        mapperMock.Setup(m => m.Map<Employee, EmployeeViewModel>(employeeExpected)).Returns(employeeExpectedViewModel);
        var service = new EmployeeService(repositoryMock.Object, _unitOfWorkMock.Object, mapperMock.Object);

        var response = await service.GetAsync(employeeId);
        
        Assert.Equal(employeeExpectedViewModel, response.Resource);
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