using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using ReportsBLL.DataTransferObjects.Comments;
using ReportsBLL.DataTransferObjects.Problems;
using ReportsBLL.Services;

namespace ReportsAPI.Controllers;

public class ProblemController : BaseApiController
{
    private readonly ProblemService _problemService;

    public ProblemController(ProblemService problemService)
    {
        _problemService = problemService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] ulong? employeeId, DateTime? timeCreatedFilter)
    {
        var response = await _problemService.GetAllAsync();
        var problems = response.DataTransferObjects;

        if (employeeId is not null)
            problems = problems.Where(p => p.EmployeeId == employeeId);

        if (timeCreatedFilter is not null)
            problems = problems.Where(p => p.CreationTime == timeCreatedFilter);

        return Ok(problems);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(ulong id)
    {
        var response = await _problemService.GetAsync(id);
        if (!response.Success) return BadRequest(response.ErrorMessage);

        return Ok(response.DataTransferObject); // TODO: Change DTO -> ViewModel
    }

    [HttpPost]
    public async Task<IActionResult> Save([FromBody] AddProblemDto addEmployeeDto)
    {
        var response = await _problemService.SaveAsync(addEmployeeDto);
        if (!response.Success) return BadRequest(response.ErrorMessage);

        return Ok(response.DataTransferObject);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(ulong id)
    {
        var success = await _problemService.DeleteAsync(id);
        return success ? Ok(success) : BadRequest(success);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(ulong id, [FromBody] UpdateProblemDto updateProblemDto)
    {
        var response = await _problemService.UpdateAsync(id, updateProblemDto);
        if (!response.Success) return BadRequest(response.ErrorMessage);

        return Ok(response.DataTransferObject);
    }

    [HttpPatch("closeProblem/{id}")]
    public async Task<IActionResult> CloseProblem(ulong id)
    {
        var response = await _problemService.CloseProblem(id);
        if (!response.Success) return BadRequest(response.ErrorMessage);

        return Ok(response.DataTransferObject);
    }

    [HttpPost("{problemId}/AddComment")]
    public async Task<IActionResult> AddComment(ulong problemId, string content) // TODO: Dto
    {
        var response = await _problemService.AddComment(problemId, content);
        if (!response.Success) return BadRequest(response.ErrorMessage);

        return Ok(response.DataTransferObject);
    }
}