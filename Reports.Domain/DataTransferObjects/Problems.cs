using System.ComponentModel.DataAnnotations;
using Reports.Domain.Interfaces;
using Reports.Domain.Models.Problems;

namespace Reports.Domain.DataTransferObjects;

public record ProblemViewModel(
        ulong Id,
        string Description,
        string State,
        ulong EmployeeId,
        DateTime CreationTime,
        IEnumerable<CommentViewModel> Comments)
    : IViewModel<Problem>;

public record AddProblemDto(
        [StringLength(100, MinimumLength = 3)] string Description,
        ulong EmployeeId)
    : IDataTransferObject<Problem>;

public record UpdateProblemDto(
        [StringLength(100, MinimumLength = 3)] string Description,
        ulong EmployeeId)
    : IDataTransferObject<Problem>;
