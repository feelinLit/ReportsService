using System.ComponentModel.DataAnnotations;
using ReportsBLL.Interfaces;

namespace ReportsBLL.Models.Employees;

public interface IPerson : IEntity
{
    [Required] [MaxLength(20)] string Username { get; } // TODO: Make it primary key?
}