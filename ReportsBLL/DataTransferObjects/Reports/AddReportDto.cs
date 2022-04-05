using System.ComponentModel.DataAnnotations;
using ReportsBLL.Interfaces;
using ReportsBLL.Models.Reports;

namespace ReportsBLL.DataTransferObjects.Reports;

public class AddReportDto : IDataTransferObject<Report>
{
    [StringLength(100)] public string Description { get; set; }
    public ulong EmployeeId { get; set; }
}