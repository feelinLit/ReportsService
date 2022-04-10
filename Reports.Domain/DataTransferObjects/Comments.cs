using System.ComponentModel.DataAnnotations;
using Reports.Domain.Interfaces;
using Reports.Domain.Models.Problems;

namespace Reports.Domain.DataTransferObjects;

public record CommentViewModel(
        string Content,
        ulong EmployeeId,
        DateTime CreationTime)
    : IViewModel<Comment>;

public record AddCommentDto(
        [StringLength(100, MinimumLength = 5)] string Content)
    : IDataTransferObject<Comment>;