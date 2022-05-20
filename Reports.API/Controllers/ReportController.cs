using Microsoft.AspNetCore.Mvc;
using Reports.Domain.Interfaces.Services;
using Reports.Shared.DataTransferObjects;

namespace Reports.API.Controllers;

public class ReportController : BaseApiController
{
    private readonly IReportService _reportService;

    public ReportController(IReportService reportService)
    {
        _reportService = reportService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _reportService.GetAllAsync();
        if (!response.Success) return BadRequest(response.ErrorMessage);

        return Ok(response.Resource);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(ulong id)
    {
        var response = await _reportService.GetAsync(id);
        if (!response.Success) return BadRequest(response.ErrorMessage);

        return Ok(response.Resource);
    }

    [HttpPost]
    public async Task<IActionResult> Save([FromBody] AddReportDto addReportDto)
    {
        var response = await _reportService.SaveAsync(addReportDto);
        if (!response.Success) return BadRequest(response.ErrorMessage);

        return Ok(response.Resource);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(ulong id, UpdateReportDto updateReportDto)
    {
        var response = await _reportService.UpdateAsync(id, updateReportDto.Description);
        if (!response.Success) return BadRequest(response.ErrorMessage);

        return Ok(response.Resource);
    }

    [HttpPatch("complete/{id}")]
    public async Task<IActionResult> Complete(ulong id)
    {
        var response = await _reportService.CompleteAsync(id);
        if (!response.Success) return BadRequest(response.ErrorMessage);

        return Ok(response.Resource);
    }

    [HttpGet("getAllFromSubordinates/{supervisorId}")]
    public async Task<IActionResult> GetFromSubordinates(ulong supervisorId)
    {
        var response = await _reportService.GetAllFromSubordinatesAsync(supervisorId);
        if (!response.Success) return BadRequest(response.ErrorMessage);

        return Ok(response.Resource);
    }
}