using System.ComponentModel.DataAnnotations;
using ReportsBLL.Interfaces;

namespace ReportsBLL.DataTransferObjects.Problems;

public class UpdateProblemDto : IDataTransferObject
{
    [StringLength(100, MinimumLength = 3)] public string Description { get; set; }

    public ulong EmployeeId { get; set; }
}