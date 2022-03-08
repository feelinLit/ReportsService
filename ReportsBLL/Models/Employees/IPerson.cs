using System.ComponentModel.DataAnnotations;

namespace ReportsBLL.Models.Employees;

public interface IPerson : IEntity
{
    [Required] [MaxLength(30)] public string Username { get; } // TODO: Make it primary key?
}