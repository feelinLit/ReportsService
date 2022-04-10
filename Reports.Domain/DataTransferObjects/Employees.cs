using System.ComponentModel.DataAnnotations;
using Reports.Domain.Interfaces;
using Reports.Domain.Models.Employees;

namespace Reports.Domain.DataTransferObjects;

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
