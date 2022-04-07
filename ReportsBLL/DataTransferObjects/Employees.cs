using System.ComponentModel.DataAnnotations;
using ReportsBLL.DataTransferObjects.Problems;
using ReportsBLL.Interfaces;
using ReportsBLL.Models.Employees;

namespace ReportsBLL.DataTransferObjects.Employees;

public record EmployeeViewModel(
        ulong Id,
        string Username,
        ulong? SupervisorId,
        IEnumerable<ProblemViewModel> Problems)
    : IViewModel<Employee>;

public record AddEmployeeDto(
        [StringLength(20, MinimumLength = 1)] string Username,
        ulong? SupervisorId)
    : IDataTransferObject<Employee>;

public record UpdateEmployeeDto(
        [StringLength(20, MinimumLength = 1)] string Username,
        ulong? SupervisorId)
    : IDataTransferObject<Employee>;
