using System.ComponentModel.DataAnnotations;

namespace Reports.Shared.DataTransferObjects;

public record EmployeeViewModel(
    ulong Id,
    string Username,
    ulong? SupervisorId,
    IEnumerable<ProblemViewModel> Problems);

public record AddEmployeeDto(
    [StringLength(20, MinimumLength = 1)] string Username,
    ulong? SupervisorId);

public record UpdateEmployeeDto(
        [StringLength(20, MinimumLength = 1)] string Username,
        ulong? SupervisorId);