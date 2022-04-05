using ReportsBLL.Interfaces;

namespace ReportsBLL.DataTransferObjects.Comments;

public class CommentViewModel : IViewModel
{
    public string Content { get; set; }
    public ulong EmployeeId { get; set; }
    public DateTime CreationTime { get; set; }
}