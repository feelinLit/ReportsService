using System.ComponentModel.DataAnnotations;
using ReportsBLL.Interfaces;
using ReportsBLL.Models.Employees;

namespace ReportsBLL.DataTransferObjects.Employees;

public class AddEmployeeDto : IDataTransferObject<Employee>
{
    [StringLength(20, MinimumLength = 1)] public string Username { get; set; }

    public ulong? SupervisorId { get; set; }
}