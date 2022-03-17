using System.ComponentModel.DataAnnotations;

namespace ReportsBLL.DataTransferObjects.Problems;

public class UpdateProblemDto
{
    [StringLength(100, MinimumLength = 3)] public string Description { get; set; }

    public ulong EmployeeId { get; set; }
}