using System.ComponentModel.DataAnnotations;
using Reports.Domain.Interfaces;

namespace Reports.Domain.Models.Employees;

public interface IPerson : IEntity
{
    [Required] [MaxLength(20)] string Username { get; }
}