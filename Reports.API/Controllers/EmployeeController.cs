using Microsoft.AspNetCore.Mvc;
using Reports.API.Tools;
using Reports.Domain.Interfaces.Services;
using Reports.Shared.DataTransferObjects;

namespace Reports.API.Controllers;

public class EmployeeController : BaseApiController
{
    private readonly IEmployeeService _employeeService;
    private string previousUsernameFilter;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string? usernameFilter, int? pageSize, int? pageIndex)
    {
        if (usernameFilter != previousUsernameFilter)
            pageIndex = 1;

        previousUsernameFilter = usernameFilter;

        var response = await _employeeService.GetAllAsync();
        var employees = response.Resource;

        if (!string.IsNullOrEmpty(usernameFilter))
            employees = employees.Where(e => e.Username == usernameFilter).ToList();

        var paginatedList =
            new PaginatedList<EmployeeViewModel>(employees.ToList(), pageIndex ?? 1, pageSize ?? employees.Count);
        HttpContext.Response.Headers.Add("Page-Index", $"{paginatedList.PageIndex}");
        HttpContext.Response.Headers.Add("Page-Size", $"{paginatedList.PageSize}");
        HttpContext.Response.Headers.Add("Page-Total-Number", $"{paginatedList.TotalPages}");
        HttpContext.Response.Headers.Add("Rows-Total-Number", $"{employees.Count}");
        return Ok(paginatedList);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(ulong id)
    {
        var response = await _employeeService.GetAsync(id);
        if (!response.Success) return BadRequest(response.ErrorMessage);

        return Ok(response.Resource);
    }

    [HttpPost]
    public async Task<IActionResult> Save([FromBody] AddEmployeeDto addEmployeeDto)
    {
        var response = await _employeeService.SaveAsync(addEmployeeDto);
        if (!response.Success) return BadRequest(response.ErrorMessage);

        return Ok(response.Resource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(ulong id)
    {
        var response = await _employeeService.DeleteAsync(id);
        return response.Success ? Ok("Employee deleted successfully") : BadRequest(response.ErrorMessage);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(ulong id, [FromBody] UpdateEmployeeDto updateEmployeeDto)
    {
        var response = await _employeeService.UpdateAsync(id, updateEmployeeDto);
        if (!response.Success) return BadRequest(response.ErrorMessage);

        return Ok(response.Resource);
    }
}