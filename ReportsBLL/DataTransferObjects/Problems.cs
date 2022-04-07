using System.ComponentModel.DataAnnotations;
using ReportsBLL.DataTransferObjects.Comments;
using ReportsBLL.Interfaces;
using ReportsBLL.Models.Problems;

namespace ReportsBLL.DataTransferObjects.Problems;

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
