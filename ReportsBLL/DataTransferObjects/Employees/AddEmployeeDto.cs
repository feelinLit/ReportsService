using System.ComponentModel.DataAnnotations;
using ReportsBLL.Interfaces;

namespace ReportsBLL.DataTransferObjects.Employees;

public class AddEmployeeDto : IDataTransferObject
{
    [StringLength(20, MinimumLength = 1)] public string Username { get; set; }

    public ulong? SupervisorId { get; set; }
}