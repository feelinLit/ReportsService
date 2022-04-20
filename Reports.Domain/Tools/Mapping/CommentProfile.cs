using AutoMapper;
using Reports.Domain.Models.Problems;
using Reports.Shared.DataTransferObjects;

namespace Reports.Domain.Tools.Mapping;

public class CommentProfile : Profile
{
    public CommentProfile()
    {
        CreateMap<Comment, CommentViewModel>();
    }
}