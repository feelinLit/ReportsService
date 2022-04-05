using ReportsBLL.DataTransferObjects.Comments;
using ReportsBLL.Interfaces;
using ReportsBLL.Models.Problems;

namespace ReportsBLL.DataTransferObjects.Problems;

public class ProblemViewModel : IViewModel<Problem>
{
    public ulong Id { get; set; }
    public string Description { get; set; }
    public string State { get; set; }
    public ulong EmployeeId { get; set; }
    public DateTime CreationTime { get; set; }
    public IEnumerable<CommentViewModel> Comments { get; set; }
}