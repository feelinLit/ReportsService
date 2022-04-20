using System.ComponentModel.DataAnnotations;

namespace Reports.Shared.DataTransferObjects;

public record ProblemViewModel(
    ulong Id,
    string Description,
    string State,
    ulong EmployeeId,
    DateTime CreationTime,
    IEnumerable<CommentViewModel> Comments);

public record AddProblemDto(
    [StringLength(100, MinimumLength = 3)] string Description,
    ulong EmployeeId);

public record UpdateProblemDto(
        [StringLength(100, MinimumLength = 3)] string Description,
        ulong EmployeeId);