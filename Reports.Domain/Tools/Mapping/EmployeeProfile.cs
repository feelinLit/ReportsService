using AutoMapper;
using Reports.Domain.Models.Employees;
using Reports.Shared.DataTransferObjects;

namespace Reports.Domain.Tools.Mapping;

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