using AutoMapper;
using ReportsBLL.DataTransferObjects.Comments;
using ReportsBLL.Models.Problems;

namespace ReportsBLL.Tools.Mapping;

public class CommentProfile : Profile
{
    public CommentProfile()
    {
        CreateMap<Comment, CommentDto>();
    }
}