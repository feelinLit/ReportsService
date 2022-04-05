using System.ComponentModel.DataAnnotations;
using ReportsBLL.Interfaces;

namespace ReportsBLL.DataTransferObjects.Reports;

public class AddReportDto : IDataTransferObject
{
    [StringLength(100)] public string Description { get; set; }
    public ulong EmployeeId { get; set; }
}