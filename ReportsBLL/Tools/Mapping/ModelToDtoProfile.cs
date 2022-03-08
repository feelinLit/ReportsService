using AutoMapper;
using ReportsBLL.DataTransferObjects;
using ReportsBLL.Models.Employees;

namespace ReportsBLL.Tools.Mapping;

public class ModelToDtoProfile : Profile
{
    public ModelToDtoProfile()
    {
        CreateMap<Employee, EmployeeDto>()
            .ReverseMap();
    }
}