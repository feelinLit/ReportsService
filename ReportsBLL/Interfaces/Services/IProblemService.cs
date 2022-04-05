using ReportsBLL.DataTransferObjects.Problems;
using ReportsBLL.Services.Communication;

namespace ReportsBLL.Interfaces.Services;

public interface IProblemService
{
    public Task<Response<List<ProblemViewModel>>> GetAllAsync();
    public Task<Response<ProblemViewModel>> GetAsync(ulong id);
    public Task<Response<ProblemViewModel>> SaveAsync(AddProblemDto addProblemDto);
    public Task<Response<ProblemViewModel>> UpdateAsync(ulong id, UpdateProblemDto updateProblemDto);
    public Task<bool> DeleteAsync(ulong id);
    public Task<Response<ProblemViewModel>> CloseProblem(ulong id);
    public Task<Response<ProblemViewModel>> AddComment(ulong problemId, string content);
}