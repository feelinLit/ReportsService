using ReportsBLL.Interfaces;

namespace ReportsBLL.DataTransferObjects;

public class EmployeeDto : IViewModel
{
    public ulong Id { get; set; }
    public string Username { get; set; }
    public uint? SupervisorId { get; set; }
}