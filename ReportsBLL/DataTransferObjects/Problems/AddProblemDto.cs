using System.ComponentModel.DataAnnotations;

namespace ReportsBLL.DataTransferObjects.Problems;

public class AddProblemDto
{
    [StringLength(100, MinimumLength = 3)] public string Description { get; set; }

    public ulong EmployeeId { get; set; }
}