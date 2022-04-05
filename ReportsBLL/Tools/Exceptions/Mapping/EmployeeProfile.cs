using AutoMapper;
using ReportsBLL.DataTransferObjects;
using ReportsBLL.DataTransferObjects.Employees;
using ReportsBLL.Models.Employees;

namespace ReportsBLL.Tools.Mapping;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, EmployeeViewModel>();

        ShouldUseConstructor = info => info.IsFamily || info.IsPublic;
        CreateMap<AddEmployeeDto, Employee>();
        CreateMap<UpdateEmployeeDto, Employee>();
    }
}