using ReportsBLL.DataTransferObjects.Comments;
using ReportsBLL.Interfaces;

namespace ReportsBLL.DataTransferObjects.Problems;

public class ProblemViewModel : IViewModel
{
    public ulong Id { get; set; }
    public string Description { get; set; }
    public string State { get; set; }
    public ulong EmployeeId { get; set; }
    public DateTime CreationTime { get; set; }
    public IEnumerable<CommentViewModel> Comments { get; set; }
}