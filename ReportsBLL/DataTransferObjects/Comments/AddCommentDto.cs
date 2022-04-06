using System.ComponentModel.DataAnnotations;
using ReportsBLL.Interfaces;
using ReportsBLL.Models.Problems;

namespace ReportsBLL.DataTransferObjects.Comments;

public class AddCommentDto : IDataTransferObject<Comment>
{
    [StringLength(100, MinimumLength = 1)] public string Content { get; set; }
}