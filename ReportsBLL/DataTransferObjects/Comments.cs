using System.ComponentModel.DataAnnotations;
using ReportsBLL.Interfaces;
using ReportsBLL.Models.Problems;

namespace ReportsBLL.DataTransferObjects.Comments;

public record CommentViewModel(
        string Content,
        ulong EmployeeId,
        DateTime CreationTime)
    : IViewModel<Comment>;

public record AddCommentDto(
        [StringLength(100, MinimumLength = 5)] string Content)
    : IDataTransferObject<Comment>;