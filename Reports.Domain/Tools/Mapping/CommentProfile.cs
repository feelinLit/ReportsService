using AutoMapper;
using Reports.Domain.DataTransferObjects;
using Reports.Domain.Models.Problems;

namespace Reports.Domain.Tools.Mapping;

public class CommentProfile : Profile
{
    public CommentProfile()
    {
        CreateMap<Comment, CommentViewModel>();
    }
}