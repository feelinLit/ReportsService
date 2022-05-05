using Microsoft.AspNetCore.Mvc;
using Reports.Domain.Interfaces.Services;
using Reports.Shared.DataTransferObjects;

namespace Reports.API.Controllers;

public class ProblemController : BaseApiController
{
    private readonly IProblemService _problemService;

    public ProblemController(IProblemService problemService)
    {
        _problemService = problemService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProblemViewModel>>> GetAll([FromQuery] ulong? employeeId, DateTime? timeCreatedFilter)
    {
        var response = await _problemService.GetAllAsync();
        var problems = response.Resource;

        if (employeeId is not null)
            problems = problems.Where(p => p.EmployeeId == employeeId).ToList();

        if (timeCreatedFilter is not null)
            problems = problems.Where(p => p.CreationTime == timeCreatedFilter).ToList();

        return Ok(problems);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(ulong id)
    {
        var response = await _problemService.GetAsync(id);
        if (!response.Success) return BadRequest(response.ErrorMessage);

        return Ok(response.Resource);
    }

    [HttpPost]
    public async Task<IActionResult> Save([FromBody] AddProblemDto addEmployeeDto)
    {
        var response = await _problemService.SaveAsync(addEmployeeDto);
        if (!response.Success) return BadRequest(response.ErrorMessage);

        return Ok(response.Resource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(ulong id)
    {
        var response = await _problemService.DeleteAsync(id);
        return response.Success ? Ok("Problem deleted successfully") : BadRequest(response.ErrorMessage);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(ulong id, [FromBody] UpdateProblemDto updateProblemDto)
    {
        var response = await _problemService.UpdateAsync(id, updateProblemDto);
        if (!response.Success) return BadRequest(response.ErrorMessage);

        return Ok(response.Resource);
    }

    [HttpPatch("closeProblem/{id}")]
    public async Task<IActionResult> CloseProblem(ulong id)
    {
        var response = await _problemService.CloseProblem(id);
        if (!response.Success) return BadRequest(response.ErrorMessage);

        return Ok(response.Resource);
    }

    [HttpPost("{problemId}/addComment")]
    public async Task<IActionResult> AddComment(ulong problemId, AddCommentDto addCommentDto)
    {
        var response = await _problemService.AddComment(problemId, addCommentDto);
        if (!response.Success) return BadRequest(response.ErrorMessage);

        return Ok(response.Resource);
    }
}