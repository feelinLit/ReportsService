using System.ComponentModel.DataAnnotations;
using ReportsBLL.Interfaces;
using ReportsBLL.Models.Problems;

namespace ReportsBLL.DataTransferObjects.Problems;

public class UpdateProblemDto : IDataTransferObject<Problem>
{
    [StringLength(100, MinimumLength = 3)] public string Description { get; set; }

    public ulong EmployeeId { get; set; }
}