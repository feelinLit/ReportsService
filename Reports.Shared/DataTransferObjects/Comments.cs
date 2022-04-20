using System.ComponentModel.DataAnnotations;

namespace Reports.Shared.DataTransferObjects;

public record CommentViewModel(
    string Content,
    ulong EmployeeId,
    DateTime CreationTime);

public record AddCommentDto(
    [StringLength(100, MinimumLength = 5)] string Content);
