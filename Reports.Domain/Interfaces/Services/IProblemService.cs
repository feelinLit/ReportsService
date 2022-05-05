using Reports.Domain.Services.Communication;
using Reports.Shared.DataTransferObjects;

namespace Reports.Domain.Interfaces.Services;

public interface IProblemService
{
    public Task<Response<List<ProblemViewModel>>> GetAllAsync();
    public Task<Response<ProblemViewModel>> GetAsync(ulong id);
    public Task<Response<ProblemViewModel>> SaveAsync(AddProblemDto addProblemDto);
    public Task<Response<ProblemViewModel>> UpdateAsync(ulong id, UpdateProblemDto updateProblemDto);
    public Task<Response<ProblemViewModel>> DeleteAsync(ulong id);
    public Task<Response<ProblemViewModel>> CloseProblem(ulong id);
    public Task<Response<ProblemViewModel>> AddComment(ulong problemId, AddCommentDto addCommentDto);
}