using System.ComponentModel.DataAnnotations;

namespace ReportsBLL.DataTransferObjects.Reports;

public class AddReportDto
{
    [StringLength(100)] public string Description { get; set; }
    public ulong EmployeeId { get; set; }
}