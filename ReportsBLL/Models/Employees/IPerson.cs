using System.ComponentModel.DataAnnotations;

namespace ReportsBLL.Models.Employees;

public interface IPerson
{
    [Required, MaxLength(30)]  public string Username { get; set; }

}