using ReportsBLL.Interfaces;
using ReportsBLL.Models.Problems;

namespace ReportsBLL.DataTransferObjects.Comments;

public class CommentViewModel : IViewModel<Comment>
{
    public string Content { get; set; }
    public ulong EmployeeId { get; set; }
    public DateTime CreationTime { get; set; }
}