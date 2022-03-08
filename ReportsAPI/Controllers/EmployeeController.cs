using Microsoft.AspNetCore.Mvc;
using ReportsBLL.Services;

namespace ReportsAPI.Controllers;

public class EmployeeController : BaseApiController
{
    private readonly EmployeeService _employeeService;

    public EmployeeController(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] ulong id)
    {
        var response = await _employeeService.Get(id);
        if (!response.Success)
        {
            return BadRequest(response.ErrorMessage);
        }

        return Ok(response.DataTransferObjects);
    }
    
    
}